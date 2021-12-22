using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace Proje
{
    public partial class Student : Form
    {
        public Student()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Controls c = new Controls();
            c.usertype = "student";
            c.username = textBox1.Text;
            

            SqlConnection con = new SqlConnection(@"Data Source=.;Initial Catalog=PDatabase;Integrated Security=True");
            SqlCommand cmd = new SqlCommand("Select * from students where username=@username and password=@password", con);
            DataTable dt = new DataTable();

            cmd.CommandType = CommandType.Text;
            cmd.Parameters.AddWithValue("@username", textBox1.Text);
            cmd.Parameters.AddWithValue("@password", textBox2.Text);

            con.Open();
            SqlDataReader sdr = cmd.ExecuteReader();
            dt.Load(sdr);
            con.Close();

            if (dt.Rows.Count > 0)
            {
                MessageBox.Show("Success!", "YAY", MessageBoxButtons.OK, MessageBoxIcon.Information);
                
                
               
                c.Show();
                

            }
            else
            {
                MessageBox.Show("Username or password is incorrect !", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void Student_Load(object sender, EventArgs e)
        {

        }
    }
}
