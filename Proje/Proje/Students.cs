using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Proje
{
    public partial class Students : Form
    {
        public string usertype;
        public string username;
        SqlConnection con = new SqlConnection(@"Data Source=.;Initial Catalog=PDatabase;Integrated Security=True");
        public int StudentID;
        public Students()
        {
            InitializeComponent();
        }

        private void Users_Load(object sender, EventArgs e)
        {

            usersLoad();

            if (usertype == "teacher")
            {
                
                delete.Enabled = false;
            }

        }

        private void usersLoad()
        {
            SqlCommand cmd = new SqlCommand("Select * from students ", con);
            DataTable dt = new DataTable();

            con.Open();
            SqlDataReader sdr = cmd.ExecuteReader();
            dt.Load(sdr);
            con.Close();
            txtpassword.Text = "";
            txtusername.Text = "";
            dataGridView1.DataSource = dt;
        }

        private void button1_Click(object sender, EventArgs e)
        {

            if (this.Controls.OfType<TextBox>().Any(t => string.IsNullOrEmpty(t.Text)))
            {
                MessageBox.Show("Please fill all fields !", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {


                SqlCommand cmd = new SqlCommand("INSERT INTO students VALUES(@username, @password,@usertype )", con);
                cmd.CommandType = CommandType.Text;

                string utype = "student";
                cmd.Parameters.AddWithValue("@username", txtusername.Text);
                cmd.Parameters.AddWithValue("@password", txtpassword.Text);
                cmd.Parameters.AddWithValue("@usertype", utype);

                con.Open();
                cmd.ExecuteNonQuery();
                con.Close();

                MessageBox.Show("Succes !", "Saved", MessageBoxButtons.OK, MessageBoxIcon.Information);
                usersLoad();
                StudentID = 0;
            }

        }

        private void update_Click(object sender, EventArgs e)
        {
            if (this.Controls.OfType<TextBox>().Any(t => string.IsNullOrEmpty(t.Text)))
            {
                MessageBox.Show("Please fill all fields !", "Error", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                if (StudentID > 0)
                {
                    SqlCommand cmd = new SqlCommand("UPDATE students SET username = @username ,password = @password ,usertype=@usertype WHERE id = @id", con); ;
                    cmd.CommandType = CommandType.Text;

                    string utype = "student";
                    cmd.Parameters.AddWithValue("@username", txtusername.Text);
                    cmd.Parameters.AddWithValue("@password", txtpassword.Text);
                    cmd.Parameters.AddWithValue("@usertype", utype);
                    cmd.Parameters.AddWithValue("@id", this.StudentID);


                    con.Open();
                    cmd.ExecuteNonQuery();
                    con.Close();

                    MessageBox.Show("Succes !", "Saved", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    usersLoad();

                    StudentID = 0;
                }
                else
                {
                    MessageBox.Show("Please Select Student !", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }


            }
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            {

                DataGridViewRow row = dataGridView1.Rows[e.RowIndex];
                txtusername.Text = row.Cells[1].Value.ToString();
                txtpassword.Text = row.Cells[2].Value.ToString();

                StudentID = Convert.ToInt32(row.Cells[0].Value);

                MessageBox.Show("Selected Student ID :" + StudentID, "Warning !", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void delete_Click(object sender, EventArgs e)
        {
            
            
                if (StudentID > 0)
                {
                    SqlCommand cmd = new SqlCommand("DELETE from students WHERE id = @StudentID", con);
                    cmd.CommandType = CommandType.Text;


                    cmd.Parameters.AddWithValue("@StudentID", this.StudentID);
                    con.Open();
                    cmd.ExecuteNonQuery();
                    con.Close();

                    MessageBox.Show("Succes !", "Deleted", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    usersLoad();

                    StudentID = 0;
                }
                else
                {
                    MessageBox.Show("Please Select Student !", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            
        }
    }
}

