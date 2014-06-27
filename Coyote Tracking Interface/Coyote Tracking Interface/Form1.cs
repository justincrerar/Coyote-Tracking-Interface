using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;
using System.Diagnostics;

namespace Coyote_Tracking_Interface
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Form2 form2 = new Form2(); //To Command Center
            if (form2.Visible == false)
            {
                form2.Show();
            }
            
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            //Code to open PDF here
        }

        private void button2_Click(object sender, EventArgs e)
        {
            monitorForm mForm = new monitorForm();
            if (mForm.Visible == false)
            {
                mForm.Show();
            }
        }
    }
}
