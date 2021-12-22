using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace Proje
{
    public partial class Admin : Form
    {
        public Admin()
        {
            InitializeComponent();
        }
       
        private void Admin_Load(object sender, EventArgs e)
        {
            

        }

        private void button1_Click(object sender, EventArgs e)
        {
            Controls c = new Controls();
            c.usertype = "admin";
            SqlConnection con = new SqlConnection(@"Data Source=.;Initial Catalog=PDatabase;Integrated Security=True");
            SqlCommand cmd = new SqlCommand("Select * from admin where username=@username and password=@password", con);
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
                MessageBox.Show("Username or password is incorrect !","Error",MessageBoxButtons.OK,MessageBoxIcon.Error);
            }

        }
    }
}
