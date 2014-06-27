using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Net.Mail;
using System.Net;
using OpenPop.Pop3;         //OpenPop library is an open source library
using OpenPop.Pop3.Exceptions;
using OpenPop.Mime;

/*
 * tcaApp (The Conservation Agency App)
 * Developed by: Justin Crerar
 * University of Rhode Island
 * The Conservation Agency - Jamestown, RI
 * 
 * This application is developed for the purpose of receiving coyote commands from multiple location transmitting devices and place them in a database. 
 * The device communicates between the Cattraq device using the SMS gateway - AT&T's mode for which SMS devices can communicate with email. This app will send commands to
 * a device using the location transmitting device's ISA. Soon, the software will implement a GUI for each instruction which to send to the Cattraq (or other location
 * transmitting device).
 * */

namespace Coyote_Tracking_Interface
{
    public partial class Form2 : Form
    {
        bool validCommand = true;
        private string from = "coyote.database@gmail.com";  //Email which will be communicating with cattraq
        private string p = "wileecoyote!";
        private string lastInput;
        public object Option1, Option2, Option3, Option4, Option5, Option6, FenceText;
        string keyword, password, command, parameters;
        public Form2()
        {
            InitializeComponent();
        }

        private void Form2_Load(object sender, EventArgs e)
        {

        }
        private void button1_Click(object sender, EventArgs e)
        {
            try
            {

                MailMessage message = new MailMessage();    //MailMessage Object which to send message as
                SmtpClient smtp = new SmtpClient();         //Simple message transmitting protocol

                message.To.Add(new MailAddress(textBox1.Text));     //Adds the location transmitting device's SMS number in the 'To' field to 
                                                                    //the MailMessage
                message.From = new MailAddress(from);               //Uses the from defined globally to communicate with the device
                message.Subject = "";                       //Empty subject for compatability
                message.Body = richTextBox1.Text;           //Copies typed text into the message's body.
                smtp.Port = 587;                            //Default SMTP port for smtp.gmail.com
                smtp.Host = "smtp.gmail.com";               //Google's free SMTP site
                smtp.EnableSsl = true;                      //Required for sending mail through Google's SMTP server
                smtp.UseDefaultCredentials = false;         //Specifies credentials
                smtp.Credentials = new NetworkCredential(from, p);      //Adds networkcredential object using private fields
                smtp.DeliveryMethod = SmtpDeliveryMethod.Network;       //Delivers mail through the network.
                smtp.Send(message);                            //Pulls exception if send fails
                label3.Text = "Message Sent!";              //Confirms send

            }
            catch (Exception ex)
            {
                label3.Text = ex.Message.ToString();        //Shows rejected send message
                
            }
        }


        private void button2_Click_1(object sender, EventArgs e)
        {
            try
            {
                Pop3Client pop3c = new Pop3Client();            //Starts the POP3 Client
                pop3c.Connect("pop.gmail.com", 995, true);      //Uses port 995 and enabled SSL to connect to pop.gmail.com
                richTextBox2.Text += "-Connected\n";            //Sends to console the confirmation
                pop3c.Authenticate(from, p);                    //Authenticates using private fields
                richTextBox2.Text += "--Authenticated\n";       //Sends to console the confirmation
                int msgCount = pop3c.GetMessageCount();         //msgCount = number of messages on POP3 server.
                richTextBox2.Text += "---There are " + msgCount.ToString() + " following messages in the inbox for " + from + "\n";
                //Shows the msgCount
                bool isThereMail = checkForMail(pop3c);         //Checks msgCount for the inbox
                if (isThereMail)    //If there's mail
                {
                    richTextBox2.Text += "----This is the email for message 1: \n" + pop3c.GetMessage(1).MessagePart.GetBodyAsText();
                    richTextBox2.Text += "---Now there are " + (msgCount - 1).ToString() + " messages.\n";
                }
                else
                {
                    label3.Text = "No Mail Yet.";           //Message to window
                }
                pop3c.Disconnect();
                richTextBox2.Text += "-Disconnected\n";     //Confirm to console

            }
            catch (Exception ex)
            {
                richTextBox2.Text += "-Error - See Message\n";  //Error to console
                label3.Text = ex.Message.ToString();        //Message to window
            }
        }
        private void button2_Click(object sender, EventArgs e)      //When the 'Grab Mail' button is pressed.
        {
            
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

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            refreshCode("");
        }
        public object option1
        {
            get { return Option1; }
            set { Option1 = value; }
        }
        public object option2
        {
            get { return Option2; }
            set { Option2 = value;}
        }
        public object option3
        {
            get { return Option3; }
            set { Option3 = value; }
        }
        public object option4
        {
            get { return Option4; }
            set { Option4 = value; }
        }
        public object option5
        {
            get { return Option5; }
            set { Option5 = value; }
        }
        public object option6
        {
            get { return Option6; }
            set { Option6 = value; }
        }

        public object fenceText
        {
            get { return FenceText; }
            set { FenceText = value;}
        }


        private void textBox2_TextChanged(object sender, EventArgs e)
        {
            keyword = textBox2.Text;
            refreshCode("Passive");
            lastInput = richTextBox1.Text;
        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {
            password = textBox3.Text;
            refreshCode("Passive");
            lastInput = richTextBox1.Text;
        }

        private void refreshCode(string type)
        {
            if (type != "Passive")
            {
                command = "";
                parameters = "";
                validCommand = true;
            }

            switch (comboBox1.SelectedIndex + 1)
            {
                case 1:
                    label3.Text = "This command requests one position from the device. \nSends an acknowledgement to the monitor";
                    command = "sms";
                    parameters = "fast";  //One Location
                    //Data Processing Here
                    break;
                case 2:
                    label3.Text = "Sets the device to default settings. \nDeactivates all currently activated devices including the monitor.";
                    parameters = "default"; //Reset Device
                    command = "";

                    break;
                case 3: //Set Interval

                    command = "loc";
                    if (type != "Passive")
                    {
                        Form optionForm = new optionForm(this, 0);
                        Option1 = "";
                        Option2 = "";
                        Option3 = "";
                        optionForm.ShowDialog();
                        if (Option1.ToString() != "" && Option2.ToString() != "" && Option3.ToString() != "")
                        {
                            label3.Text = "Sets the sample rate sent from the device. \nInterval = "
                             + Option1.ToString() + ", Number of Samples = " + Option2.ToString() + " \nMinimal Distance Traveled For a Sample to be Sent = " + Option3.ToString();


                            parameters = "i=" + Option1.ToString() + ",t=" + Option2.ToString() + ",L=" + Option3.ToString();
                        }
                        else
                        {
                            validCommand = false;
                        }
                    }

                    break;
                case 4: //Authorize User

                    command = "authorize";
                    if (type != "Passive")
                    {
                        Form optionForm = new optionForm(this, 1);
                        Option1 = "";
                        optionForm.ShowDialog();
                        if (Option1.ToString() != "")
                        {
                            if (Option1.ToString() != "")
                            {
                                parameters = Option1.ToString();
                            }
                            label3.Text = "Sets up to 5 numbers to be authorized with the cattraq device.\nThe numbers are: " + parameters;
                        }
                        else
                        {
                            validCommand = false;
                        }
                    }

                    break;
                case 5://Disable GPRS
                    command = "";
                    parameters = "gprs";
                    break;
                case 6: //Geofence
                    command = "geofence";
                    Form geoForm = new GeoForm(this);
                    geoForm.ShowDialog();
                    if (type != "Passive")
                    {
                        if (Option1 != null)
                        {
                            parameters = Option1.ToString();
                        }
                        else
                        {
                            validCommand = false;
                        }
                        label3.Text = "Sets a retangular fence from two GPS points, sent as 1=x1/y1, 2=x2/y2";
                    }
                        break;
                case 7: //Disable Geofence
                    command = "";
                    parameters = "geofence";//We place the geofence command in the parameters field
                                            //so that we do not have an extra comma
                    break;
                default:
                    break;
            }

            if (validCommand)
            {
                if (command != "")
                {
                    richTextBox1.Text = keyword + "," + password + "," + command + "," + parameters + ";";
                }
                else
                {
                    richTextBox1.Text = keyword + "," + password + "," + parameters + ";";
                }
            }
        }

        private void richTextBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (richTextBox1.ReadOnly == true)
            {
                richTextBox1.ReadOnly = false;
                button3.Text = "Disable Editing";
            }
            else
            {
                richTextBox1.ReadOnly = true;
                button3.Text = "Enable Editing";
            }
        }

       
            
    }
}
