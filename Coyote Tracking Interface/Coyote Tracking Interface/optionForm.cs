using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Coyote_Tracking_Interface
{
    public partial class optionForm : Form
    {

        int caseNumber;
        public optionForm()
        {
            InitializeComponent();
        }

        private Form2 pForm = null;
        public optionForm(Form callingForm, int commandCase)
        {
            pForm = callingForm as Form2;
            caseNumber = commandCase;
            InitializeComponent();
            switch (commandCase)
            {
                case 0://Interval
                    Width = 268;
                    this.Text = "Set Interval";
                    label1.Text = "Interval:";
                    label1.Visible = true;
                    textBox1.Visible = true;
                    label2.Text = "Times:";
                    textBox2.Visible = true;
                    label2.Visible = true;
                    label3.Text = "Distance:";
                    textBox3.Visible = true;
                    label3.Visible = true;
                    label4.Visible = false;
                    textBox4.Visible = false;
                    label5.Visible = false;
                    textBox5.Visible = false;
                    label6.Visible = false;
                    textBox6.Visible = false;
                    label7.Visible = false;
                    textBox7.Visible = false;
                    label8.Visible = false;
                    textBox8.Visible = false;
                    break;
                case 1://Authorize
                    Width = 536;
                    this.Text = "Authorize Numbers";
                    label1.Text = "1=";
                    label1.Visible = true;
                    textBox1.Visible = true;
                    label2.Text = "2=";
                    textBox2.Visible = true;
                    label2.Visible = true;
                    label3.Text = "3=";
                    textBox3.Visible = true;
                    label3.Visible = true;
                    label4.Visible = false;
                    textBox4.Visible = false;
                    label5.Visible = true;
                    label5.Text = "4=";
                    textBox5.Visible = true;
                    label6.Visible = true;
                    label6.Text = "5=";
                    textBox6.Visible = true;
                    label7.Visible = false;
                    textBox7.Visible = false;
                    label8.Visible = false;
                    textBox8.Visible = false;
                    break;
                default: //TODO: CHANGE THIS
                    Width = 268;
                    this.Text = "Set Interval";
                    label1.Text = "Interval:";
                    label1.Visible = true;
                    textBox1.Visible = true;
                    label2.Text = "Times:";
                    textBox2.Visible = true;
                    label2.Visible = true;
                    label3.Text = "Distance:";
                    textBox3.Visible = true;
                    label3.Visible = true;
                    label4.Visible = false;
                    textBox4.Visible = false;
                    label5.Visible = false;
                    textBox5.Visible = false;
                    label6.Visible = false;
                    textBox6.Visible = false;
                    label7.Visible = false;
                    textBox7.Visible = false;
                    label8.Visible = false;
                    textBox8.Visible = false;
                    break;

            }
            
        }

        private void intForm_Load(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e){ //This processes the message 
        

            if (this.Text == "Set Interval" && textBox1.Text != null && textBox2.Text != null && textBox3.Text != null )
            {
                try
                {
                    if (Convert.ToInt32(textBox1.Text) < 65535 && Convert.ToInt32(textBox2.Text) < 999
                        && Convert.ToInt32(textBox3.Text) < 65535)
                    {
                        this.pForm.option1 = Convert.ToInt32(textBox1.Text);
                        this.pForm.option2 = Convert.ToInt32(textBox2.Text);
                        this.pForm.option3 = Convert.ToInt32(textBox3.Text);
                    }
                    else
                    {
                        MessageBox.Show("One or more of the interger values are outside of the limit. Please try again \n(Interval and Distance must be less than 65535 and times must be less than 999).");
                        pForm.option1 = "";
                        pForm.option2 = "";
                        pForm.option3 = "";
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
           
            }
            else if (this.Text == "Authorize Numbers" && textBox1.Text != "")
            {
                this.pForm.option1 = "1=" + textBox1.Text;
                if (textBox2.Text != "")
                {
                    this.pForm.option1 += ",2=" + textBox2.Text;
                    if (textBox3.Text != "")
                    {
                        this.pForm.option1 += ",3=" + textBox3.Text;
                        if (textBox5.Text != "")
                        {
                            this.pForm.option1 += ",4=" + textBox5.Text;
                            if (textBox6.Text != "")
                            {
                                this.pForm.option1 += ",5=" + textBox6.Text;
                            }
                        }
                    }
                }
            }
            else
            {
                MessageBox.Show("Invalid Command");
            }

            this.Hide();
        }
        private void button2_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }

        
    }
}
