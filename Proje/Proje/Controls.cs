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
    public partial class Controls : Form
    {
        public string usertype;
        public string username;
        public Controls()
        {
            InitializeComponent();
        }
        

        private void button4_Click(object sender, EventArgs e)
        {
            this.Close();
            
        }

        private void txtNotes_Click(object sender, EventArgs e)
        {
            Notes n = new Notes();
            n.usertype = usertype;
            n.username = username;
            n.Show();
           
        }

        private void Controls_Load(object sender, EventArgs e)
        {
            if (usertype == "student")
            {
                txtUsers.Enabled = false;
                
            }
            
        }

        private void txtUsers_Click(object sender, EventArgs e)
        {
            UserTypes types = new UserTypes();
            types.usertype = usertype;
            types.Show();

            Students u = new Students();
            u.usertype = usertype;
            
        }
    }
}
