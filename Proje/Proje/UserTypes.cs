using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace Proje
{
    public partial class UserTypes : Form
    {
        public string usertype;
        public string username;
        public UserTypes()
        {
            InitializeComponent();
        }

        private void UserTypes_Load(object sender, EventArgs e)
        {
            if(usertype == "teacher")
            {
                button1.Enabled = false ;
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Students st = new Students();
            st.username = username;
            st.usertype = usertype;
            st.Show();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Teachers tc = new Teachers();
            tc.Show();
        }
    }
}
