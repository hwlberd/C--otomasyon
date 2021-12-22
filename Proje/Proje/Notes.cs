using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Windows.Forms;

namespace Proje
{
   
    public partial class Notes : Form
    {
        public string usertype;
        public string username;
        
        SqlConnection con = new SqlConnection(@"Data Source=.;Initial Catalog=PDatabase;Integrated Security=True");
        public Notes()
        {
            InitializeComponent();
        }

        
        
        public void Notes_Load(object sender, EventArgs e)
        {
            getData();
          

        }

        private void getData()
        {
            if (usertype == "admin")
            {
                SqlCommand cmd = new SqlCommand("Select Note,notekey,username,usertype from notes", con);
                DataTable dt = new DataTable();

                con.Open();
                SqlDataReader sdr = cmd.ExecuteReader();
                dt.Load(sdr);
                con.Close();

                dataGridView1.DataSource = dt;
            }
            if (usertype == "teacher")
            {
                teacher.Checked = true;
                SqlCommand cmd = new SqlCommand("Select Note,notekey,username,usertype from notes", con);
                DataTable dt = new DataTable();

                con.Open();
                SqlDataReader sdr = cmd.ExecuteReader();
                dt.Load(sdr);
                con.Close();

                dataGridView1.DataSource = dt;
            }
            if (usertype == "student")
            {
                teacher.Enabled = false;
                student.Enabled = false;
                SqlCommand cmd = new SqlCommand(" SELECT Note,notekey from notes where username=@username or usertype=@usertype", con);
                DataTable dt = new DataTable();
                cmd.CommandType = CommandType.Text;
                cmd.Parameters.AddWithValue("@username", username);
                cmd.Parameters.AddWithValue("@usertype", usertype);
                con.Open();
                SqlDataReader sdr = cmd.ExecuteReader();
                dt.Load(sdr);
                con.Close();

                dataGridView1.DataSource = dt;
            }
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            DataGridViewRow row = dataGridView1.Rows[e.RowIndex];
            txtNote.Text = row.Cells[0].Value.ToString();
            txtKey.Text = row.Cells[1].Value.ToString();

           
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (usertype == "student") 
            {
                if (txtKey.Text.Length < 8)
                {
                    MessageBox.Show("Minimum 8 character for key !", "YAY", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {


                    string unencryptedString = txtNote.Text;
                    string password = txtKey.Text;
                    string encryptedString;


                    encryptedString = Encrypt(unencryptedString, password);


                   

                        
                            SqlCommand cmd = new SqlCommand("INSERT into notes VALUES(@Note,@notekey,@username,@usertype)", con);
                            cmd.CommandType = CommandType.Text;

                            
                            
                            cmd.Parameters.AddWithValue("@Note", encryptedString);
                            cmd.Parameters.AddWithValue("@notekey", password);
                            cmd.Parameters.AddWithValue("@username", username);
                            cmd.Parameters.AddWithValue("@usertype", "");

                    con.Open();
                            cmd.ExecuteNonQuery();
                            con.Close();

                            MessageBox.Show("Succes !", "Saved", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            getData();
                            txtKey.Text = "";
                            txtNote.Text = "";
                        
                }
           

                
               

            }
            else
            {
                if (txtKey.Text.Length < 8)
                {
                    MessageBox.Show("Minimum 8 character for key !", "YAY", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    if (student.Checked == true) {
                        string unencryptedString = txtNote.Text;
                        string password = txtKey.Text;
                        string encryptedString;


                        encryptedString = Encrypt(unencryptedString, password);


                        SqlCommand cmd = new SqlCommand("INSERT into notes VALUES(@Note,@notekey,@username,@usertype)", con);
                        cmd.CommandType = CommandType.Text;



                        cmd.Parameters.AddWithValue("@Note", encryptedString);
                        cmd.Parameters.AddWithValue("@notekey", password);
                        cmd.Parameters.AddWithValue("@username", "");
                        cmd.Parameters.AddWithValue("@usertype", "student");

                        con.Open();
                        cmd.ExecuteNonQuery();
                        con.Close();

                        MessageBox.Show("Succes !", "Saved", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        getData();
                        txtKey.Text = "";
                        txtNote.Text = "";
                    }

                    if (teacher.Checked == true) {
                        string unencryptedString = txtNote.Text;
                        string password = txtKey.Text;
                        string encryptedString;


                        encryptedString = Encrypt(unencryptedString, password);


                        SqlCommand cmd = new SqlCommand("INSERT into notes VALUES(@Note,@notekey,@username,@usertype)", con);
                        cmd.CommandType = CommandType.Text;



                        cmd.Parameters.AddWithValue("@Note", encryptedString);
                        cmd.Parameters.AddWithValue("@notekey", password);
                        cmd.Parameters.AddWithValue("@username", "");
                        cmd.Parameters.AddWithValue("@usertype", "teacher");

                        con.Open();
                        cmd.ExecuteNonQuery();
                        con.Close();

                        MessageBox.Show("Succes !", "Saved", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        getData();
                        txtKey.Text = "";
                        txtNote.Text = "";
                    }






                }
            }
                
        }
       

        private void button2_Click(object sender, EventArgs e)
        {
            if (txtKey.Text.Length < 8)
            {
                MessageBox.Show("Minimum 8 character for key !", "YAY", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {


                
                
                string decryptedString;
                
                decryptedString = Decrypt(txtNote.Text, txtKey.Text);

                if (this.Controls.OfType<TextBox>().Any(t => string.IsNullOrEmpty(t.Text)))
                {
                    MessageBox.Show("Please select note from table !", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else
                {


                    MessageBox.Show("Note is : "+decryptedString, "Your Note", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    txtKey.Text = "";
                    txtNote.Text = "";
                    
                }




            }
           


        }
        public static string Encrypt(string message, string password)
        {
            //Encode message and password
            byte[] messageBytes = ASCIIEncoding.ASCII.GetBytes(message);
            byte[] passwordBytes = ASCIIEncoding.ASCII.GetBytes(password);

            //Set encryption settings
            DESCryptoServiceProvider provider = new DESCryptoServiceProvider();
            ICryptoTransform transfor = provider.CreateEncryptor(passwordBytes, passwordBytes);
            CryptoStreamMode mode = CryptoStreamMode.Write;

            //Set up streams and encrypt
            MemoryStream memStream = new MemoryStream();
            CryptoStream cryptoStream = new CryptoStream(memStream, transfor, mode);
            cryptoStream.Write(messageBytes, 0, messageBytes.Length);
            cryptoStream.FlushFinalBlock();

            //Read the encrypted message from the memory stream
            byte[] encryptedMessageBytes = new byte[memStream.Length];
            memStream.Position = 0;
            memStream.Read(encryptedMessageBytes, 0, encryptedMessageBytes.Length);

            //Encode the encrypted message as base64 string
            string encryptedMessage = Convert.ToBase64String(encryptedMessageBytes);
            return encryptedMessage;

        }
        public static string Decrypt(string encryptedMessage, string password)
        {
            //Convert encrypted message and password to byte
            byte[] encryptedMessageBytes = Convert.FromBase64String(encryptedMessage);
            byte[] passwordBytes = ASCIIEncoding.ASCII.GetBytes(password);

            //Set encryption settings
            DESCryptoServiceProvider provider = new DESCryptoServiceProvider();
            ICryptoTransform transform = provider.CreateDecryptor(passwordBytes, passwordBytes);
            CryptoStreamMode mode = CryptoStreamMode.Write;

            //Set up streams and descrypt
            MemoryStream memStream = new MemoryStream();
            CryptoStream cryptoStream = new CryptoStream(memStream, transform, mode);
            cryptoStream.Write(encryptedMessageBytes, 0, encryptedMessageBytes.Length);
            cryptoStream.FlushFinalBlock();

            //Read descrypted message from memory stream
            byte[] decryptedMessageBytes = new byte[memStream.Position];
            memStream.Position = 0;
            memStream.Read(decryptedMessageBytes, 0, decryptedMessageBytes.Length);

            //Encode decrypted message to base64 string
            string message = ASCIIEncoding.ASCII.GetString(decryptedMessageBytes);
            return message;
        }

        private void student_CheckedChanged(object sender, EventArgs e)
        {
            teacher.Checked = false;
        }

        private void teacher_CheckedChanged(object sender, EventArgs e)
        {
            student.Checked = false;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            SqlCommand cmd = new SqlCommand("Delete from notes where Note=@Note", con);
            cmd.CommandType = CommandType.Text;



            cmd.Parameters.AddWithValue("@Note", txtNote.Text);
            

            con.Open();
            cmd.ExecuteNonQuery();
            con.Close();

            MessageBox.Show("Succes !", "Deleted", MessageBoxButtons.OK, MessageBoxIcon.Information);
            getData();
            txtKey.Text = "";
            txtNote.Text = "";
        }
    }
        
    }
