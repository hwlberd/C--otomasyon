using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Proje
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
           
            Admin ad = new Admin();
            
            ad.Show();
            
            
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Student u = new Student();
            u.Show();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Teacher t = new Teacher();
            t.Show();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }
    }
}
