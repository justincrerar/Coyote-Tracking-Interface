using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using OpenPop.Pop3;

namespace Coyote_Tracking_Interface
{
    public partial class monitorForm : Form
    {
        bool monitorOn = false;
        Timer timer = new Timer();
        public monitorForm()
        {
            InitializeComponent();
            monitorOn = false;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (button1.Text == "Monitor On")
            {
                button1.Text = "Monitor Off";
                monitorOn = false;
                timer.Stop();

            }
            else if (button1.Text == "Monitor Off")
            {
                button1.Text = "Monitor On";
                monitorOn = true;
                timer.Start();
            }
            
            

        }
        public static void MinuteElapsed(object source, ElapsedEventArgs e)
        {
            //First, check to see if any new texts..
            //if new texts, read line
            String textString = "This is where the text is received";

        //    timer.Stop();
        //    try
        //    {
        //        Pop3Client pop3c = new Pop3Client();            //Starts the POP3 Client
        //        pop3c.Connect("pop.gmail.com", 995, true);      //Uses port 995 and enabled SSL to connect to pop.gmail.com
        //        richTextBox2.Text += "-Connected\n";            //Sends to console the confirmation
        //        pop3c.Authenticate(from, p);                    //Authenticates using private fields
        //        richTextBox2.Text += "--Authenticated\n";       //Sends to console the confirmation
        //        int msgCount = pop3c.GetMessageCount();         //msgCount = number of messages on POP3 server.
        //        richTextBox2.Text += "---There are " + msgCount.ToString() + " following messages in the inbox for " + from + "\n";
        //        //Shows the msgCount
        //        bool isThereMail = checkForMail(pop3c);         //Checks msgCount for the inbox
        //        if (isThereMail)    //If there's mail
        //        {
        //            richTextBox2.Text += "----This is the email for message 1: \n" + pop3c.GetMessage(1).MessagePart.GetBodyAsText();
        //            richTextBox2.Text += "---Now there are " + (msgCount - 1).ToString() + " messages.\n";
        //        }
        //        else
        //        {
        //            label3.Text = "No Mail Yet.";           //Message to window
        //        }
        //        pop3c.Disconnect();
        //        richTextBox2.Text += "-Disconnected\n";     //Confirm to console

        //    }
        //    catch (Exception ex)
        //    {
        //        richTextBox2.Text += "-Error - See Message\n";  //Error to console
        //        label3.Text = ex.Message.ToString();        //Message to window
        //    }
        //    timer.Start();
        }
        private bool checkForMail(Pop3Client pop3Client)
        {
            if (pop3Client.GetMessageCount() == 0)
            {
                return false;
            }
            else
            {
                return true;
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Form2 form2 = new Form2();
            form2.Show();
        }
    }
}
