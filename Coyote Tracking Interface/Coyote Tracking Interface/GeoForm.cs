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
    public partial class GeoForm : Form
    {
        public GeoForm()
        {
            InitializeComponent();
            
        }

        private Label label1;
        private Label label2;
        private Label label3;
        private Label label4;
        private TextBox Lo1;
        private TextBox La1;
        private TextBox Lo2;
        private TextBox La2;
        private ComboBox LoDir1;
        private ComboBox LaDir1;
        private ComboBox LoDir2;
        private ComboBox LaDir2;
        private Button button1;
        private PictureBox pictureBox1;

        private Form2 pForm = null;
        public GeoForm(Form callingForm)
        {
            pForm = callingForm as Form2;
            pForm.fenceText = "";
            pForm.FenceText = "";
            InitializeComponent();
        }

        private void comboBox4_SelectedIndexChanged(object sender, EventArgs e)
        {
            
        }

        private void Form3_Load(object sender, EventArgs e)
        {

        }

        private void LaDir1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            string x1,y1,x2,y2;
            float x1f,y1f,x2f,y2f;
            if (Lo1.Text != "" || Lo2.Text != "" || La1.Text != "" || La2.Text != ""
                || Lo1.Text != null || Lo2.Text != null || La1.Text != null || La2.Text != null)
            {
                try
                {
                    x1f = Convert.ToSingle(Lo1.Text);
                    y1f = Convert.ToSingle(La1.Text);
                    x2f = Convert.ToSingle(Lo2.Text);
                    y2f = Convert.ToSingle(La2.Text);
                    x1 = Lo1.Text;
                    x2 = Lo2.Text;
                    y1 = La1.Text;
                    y2 = La2.Text;

                    if (x1f != 0 && x2f != 0 && y1f != 0 && y2f != 0)
                    {
                        if (x1f <= 180 && x1f >= 0)
                        {
                            if (y1f <= 90 && y1f >= 0)
                            {
                                if (x2f <= 180 && x2f >= 0)
                                {
                                    if (y2f <= 90 && y2f >= 0)
                                    {
                                        pForm.Option1 = "1=" + x1 + LoDir1.Text + "/" + y1 + LaDir1.Text + ",2=" + x2 + LoDir2.Text + "/" + y2 + La2.Text;
                                    }
                                }
                            }
                        }
                    }

                    

                }
                catch (Exception ex)
                {
                    MessageBox.Show("Your input is either invalid or incomplete. Please try again.");
                    Hide();
                }
                
            }
            else
            {
                MessageBox.Show("Did not receive the proper inputs");   
            }
            Hide();
        }

        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(GeoForm));
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.Lo1 = new System.Windows.Forms.TextBox();
            this.La1 = new System.Windows.Forms.TextBox();
            this.Lo2 = new System.Windows.Forms.TextBox();
            this.La2 = new System.Windows.Forms.TextBox();
            this.LoDir1 = new System.Windows.Forms.ComboBox();
            this.LaDir1 = new System.Windows.Forms.ComboBox();
            this.LoDir2 = new System.Windows.Forms.ComboBox();
            this.LaDir2 = new System.Windows.Forms.ComboBox();
            this.button1 = new System.Windows.Forms.Button();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(179, 51);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(80, 20);
            this.label1.TabIndex = 0;
            this.label1.Text = "Longitude";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(440, 51);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(67, 20);
            this.label2.TabIndex = 1;
            this.label2.Text = "Latitude";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(28, 114);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(58, 20);
            this.label3.TabIndex = 2;
            this.label3.Text = "Point 1";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(28, 180);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(58, 20);
            this.label4.TabIndex = 3;
            this.label4.Text = "Point 2";
            // 
            // Lo1
            // 
            this.Lo1.Location = new System.Drawing.Point(131, 114);
            this.Lo1.Name = "Lo1";
            this.Lo1.Size = new System.Drawing.Size(139, 26);
            this.Lo1.TabIndex = 4;
            // 
            // La1
            // 
            this.La1.Location = new System.Drawing.Point(384, 114);
            this.La1.Name = "La1";
            this.La1.Size = new System.Drawing.Size(140, 26);
            this.La1.TabIndex = 5;
            // 
            // Lo2
            // 
            this.Lo2.Location = new System.Drawing.Point(131, 174);
            this.Lo2.Name = "Lo2";
            this.Lo2.Size = new System.Drawing.Size(139, 26);
            this.Lo2.TabIndex = 6;
            // 
            // La2
            // 
            this.La2.Location = new System.Drawing.Point(384, 172);
            this.La2.Name = "La2";
            this.La2.Size = new System.Drawing.Size(140, 26);
            this.La2.TabIndex = 7;
            // 
            // LoDir1
            // 
            this.LoDir1.FormattingEnabled = true;
            this.LoDir1.Items.AddRange(new object[] {
            "n",
            "s"});
            this.LoDir1.Location = new System.Drawing.Point(277, 114);
            this.LoDir1.Name = "LoDir1";
            this.LoDir1.Size = new System.Drawing.Size(71, 28);
            this.LoDir1.TabIndex = 8;
            this.LoDir1.Text = "n";
            this.LoDir1.SelectedIndexChanged += new System.EventHandler(this.LoDir1_SelectedIndexChanged);
            // 
            // LaDir1
            // 
            this.LaDir1.FormattingEnabled = true;
            this.LaDir1.Items.AddRange(new object[] {
            "e",
            "w"});
            this.LaDir1.Location = new System.Drawing.Point(530, 114);
            this.LaDir1.Name = "LaDir1";
            this.LaDir1.Size = new System.Drawing.Size(121, 28);
            this.LaDir1.TabIndex = 9;
            this.LaDir1.Text = "e";
            // 
            // LoDir2
            // 
            this.LoDir2.FormattingEnabled = true;
            this.LoDir2.Items.AddRange(new object[] {
            "n",
            "s"});
            this.LoDir2.Location = new System.Drawing.Point(277, 172);
            this.LoDir2.Name = "LoDir2";
            this.LoDir2.Size = new System.Drawing.Size(71, 28);
            this.LoDir2.TabIndex = 10;
            this.LoDir2.Text = "n";
            // 
            // LaDir2
            // 
            this.LaDir2.FormattingEnabled = true;
            this.LaDir2.Items.AddRange(new object[] {
            "e",
            "w"});
            this.LaDir2.Location = new System.Drawing.Point(530, 172);
            this.LaDir2.Name = "LaDir2";
            this.LaDir2.Size = new System.Drawing.Size(121, 28);
            this.LaDir2.TabIndex = 11;
            this.LaDir2.Text = "e";
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(560, 422);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(90, 41);
            this.button1.TabIndex = 12;
            this.button1.Text = "OK";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click_1);
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(53, 239);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(471, 224);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
            this.pictureBox1.TabIndex = 13;
            this.pictureBox1.TabStop = false;
            // 
            // GeoForm
            // 
            this.ClientSize = new System.Drawing.Size(691, 475);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.LaDir2);
            this.Controls.Add(this.LoDir2);
            this.Controls.Add(this.LaDir1);
            this.Controls.Add(this.LoDir1);
            this.Controls.Add(this.La2);
            this.Controls.Add(this.Lo2);
            this.Controls.Add(this.La1);
            this.Controls.Add(this.Lo1);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Name = "GeoForm";
            this.Text = "Geofence Configuration";
            this.Load += new System.EventHandler(this.GeoForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        private void GeoForm_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {

        }

        private void LoDir1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}
