namespace WinFormsApp1
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            components = new System.ComponentModel.Container();
            timer1 = new System.Windows.Forms.Timer(components);
            timer2 = new System.Windows.Forms.Timer(components);
            pictureBox1 = new PictureBox();
            pictureBox2 = new PictureBox();
            label1 = new Label();
            label2 = new Label();
            textBox1 = new TextBox();
            label3 = new Label();
            label4 = new Label();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox2).BeginInit();
            konacno = new CButton("djak", "konacno", 0);

            a1 = new CButton("novac", "a", 1);
            a2 = new CButton("srbija", "a", 2);
            a3 = new CButton("alzir", "a", 3);
            a4 = new CButton("kuvajt", "a", 4);
            a = new CButton("dinar", "a", 0);

            b1 = new CButton("ljubavni", "b", 1);
            b2 = new CButton("raskid", "b", 2);
            b3 = new CButton("hajducki", "b", 3);
            b4 = new CButton("oprostaj", "b", 4);
            b = new CButton("rastanak", "b", 0);

            c1 = new CButton("timok", "c", 1);
            c2 = new CButton("hadzi prodan", "c", 2);
            c3 = new CButton("seljak", "c", 3);
            c4 = new CButton("reka", "c", 4);
            c = new CButton("buna", "c", 0);

            d1 = new CButton("omladina", "d", 1);
            d2 = new CButton("skupstina", "d", 2);
            d3 = new CButton("sindikat", "d", 3);
            d4 = new CButton("zdravlje", "d", 4);
            d = new CButton("dom", "d", 0);

            SuspendLayout();
            // 
            // timer1
            // 
            timer1.Tick += timer1_Tick;
            // 
            // timer2
            // 
            timer2.Tick += timer2_Tick;
            // 
            // pictureBox1
            // 
            pictureBox1.BackColor = SystemColors.ActiveCaption;
            pictureBox1.Location = new Point(12, 173);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(100, 100);
            pictureBox1.TabIndex = 0;
            pictureBox1.TabStop = false;
            // 
            // pictureBox2
            // 
            pictureBox2.BackColor = Color.FromArgb(255, 128, 128);
            pictureBox2.Location = new Point(688, 173);
            pictureBox2.Name = "pictureBox2";
            pictureBox2.Size = new Size(100, 100);
            pictureBox2.TabIndex = 1;
            pictureBox2.TabStop = false;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.BackColor = SystemColors.ActiveCaption;
            label1.Location = new Point(39, 202);
            label1.Name = "label1";
            label1.Size = new Size(38, 15);
            label1.TabIndex = 2;
            label1.Text = "label1";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.BackColor = Color.FromArgb(255, 128, 128);
            label2.Location = new Point(717, 202);
            label2.Name = "label2";
            label2.Size = new Size(38, 15);
            label2.TabIndex = 3;
            label2.Text = "label2";
            // 
            // textBox1
            // 
            textBox1.Location = new Point(292, 415);
            textBox1.Name = "textBox1";
            textBox1.Size = new Size(206, 23);
            textBox1.TabIndex = 0;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.BackColor = SystemColors.ActiveCaption;
            label3.Location = new Point(39, 231);
            label3.Name = "label3";
            label3.Size = new Size(38, 15);
            label3.TabIndex = 25;
            label3.Text = "label3";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.BackColor = Color.FromArgb(255, 128, 128);
            label4.Location = new Point(717, 231);
            label4.Name = "label4";
            label4.Size = new Size(38, 15);
            label4.TabIndex = 26;
            label4.Text = "label4";
            // 
            // konacno
            // 
            konacno.Location = new Point(292, 173);
            konacno.Name = "konacno";
            konacno.otkljucan = false;
            konacno.Size = new Size(206, 23);
            konacno.TabIndex = 14;
            konacno.Text = "KONACNO";
            konacno.Click += specijalno_polje;
            // 
            // a1
            // 
            a1.Location = new Point(167, 30);
            a1.Name = "a1";
            a1.otkljucan = false;
            a1.Size = new Size(100, 23);
            a1.TabIndex = 4;
            a1.Text = "A1";
            a1.Click += PoljeKlik;
            // 
            // a2
            // 
            a2.Location = new Point(189, 59);
            a2.Name = "a2";
            a2.otkljucan = false;
            a2.Size = new Size(100, 23);
            a2.TabIndex = 5;
            a2.Text = "A2";
            a2.Click += PoljeKlik;
            // 
            // a3
            // 
            a3.Location = new Point(225, 88);
            a3.Name = "a3";
            a3.otkljucan = false;
            a3.Size = new Size(100, 23);
            a3.TabIndex = 6;
            a3.Text = "A3";
            a3.Click += PoljeKlik;
            // 
            // a4
            // 
            a4.Location = new Point(255, 117);
            a4.Name = "a4";
            a4.otkljucan = false;
            a4.Size = new Size(100, 23);
            a4.TabIndex = 7;
            a4.Text = "A4";
            a4.Click += PoljeKlik;
            // 
            // a
            // 
            a.Location = new Point(292, 146);
            a.Name = "a";
            a.otkljucan = false;
            a.Size = new Size(100, 23);
            a.TabIndex = 8;
            a.Text = "A";
            a.Click += specijalno_polje;
            // 
            // b1
            // 
            b1.Location = new Point(520, 30);
            b1.Name = "b1";
            b1.otkljucan = false;
            b1.Size = new Size(100, 23);
            b1.TabIndex = 13;
            b1.Text = "B1";
            b1.Click += PoljeKlik;
            // 
            // b2
            // 
            b2.Location = new Point(495, 59);
            b2.Name = "b2";
            b2.otkljucan = false;
            b2.Size = new Size(100, 23);
            b2.TabIndex = 12;
            b2.Text = "B2";
            b2.Click += PoljeKlik;
            // 
            // b3
            // 
            b3.Location = new Point(466, 88);
            b3.Name = "b3";
            b3.otkljucan = false;
            b3.Size = new Size(100, 23);
            b3.TabIndex = 11;
            b3.Text = "B3";
            b3.Click += PoljeKlik;
            // 
            // b4
            // 
            b4.Location = new Point(434, 117);
            b4.Name = "b4";
            b4.otkljucan = false;
            b4.Size = new Size(100, 23);
            b4.TabIndex = 10;
            b4.Text = "B4";
            b4.Click += PoljeKlik;
            // 
            // b
            // 
            b.Location = new Point(398, 146);
            b.Name = "b";
            b.otkljucan = false;
            b.Size = new Size(100, 23);
            b.TabIndex = 9;
            b.Text = "B";
            b.Click += specijalno_polje;
            // 
            // c1
            // 
            c1.Location = new Point(167, 318);
            c1.Name = "c1";
            c1.otkljucan = false;
            c1.Size = new Size(100, 23);
            c1.TabIndex = 19;
            c1.Text = "C1";
            c1.Click += PoljeKlik;
            // 
            // c2
            // 
            c2.Location = new Point(189, 289);
            c2.Name = "c2";
            c2.otkljucan = false;
            c2.Size = new Size(100, 23);
            c2.TabIndex = 18;
            c2.Text = "C2";
            c2.Click += PoljeKlik;
            // 
            // c3
            // 
            c3.Location = new Point(225, 260);
            c3.Name = "c3";
            c3.otkljucan = false;
            c3.Size = new Size(100, 23);
            c3.TabIndex = 17;
            c3.Text = "C3";
            c3.Click += PoljeKlik;
            // 
            // c4
            // 
            c4.Location = new Point(255, 231);
            c4.Name = "c4";
            c4.otkljucan = false;
            c4.Size = new Size(100, 23);
            c4.TabIndex = 16;
            c4.Text = "C4";
            c4.Click += PoljeKlik;
            // 
            // c
            // 
            c.Location = new Point(292, 202);
            c.Name = "c";
            c.otkljucan = false;
            c.Size = new Size(100, 23);
            c.TabIndex = 15;
            c.Text = "C";
            c.Click += specijalno_polje;
            // 
            // d1
            // 
            d1.Location = new Point(520, 318);
            d1.Name = "d1";
            d1.otkljucan = false;
            d1.Size = new Size(100, 23);
            d1.TabIndex = 24;
            d1.Text = "D1";
            d1.Click += PoljeKlik;
            // 
            // d2
            // 
            d2.Location = new Point(495, 289);
            d2.Name = "d2";
            d2.otkljucan = false;
            d2.Size = new Size(100, 23);
            d2.TabIndex = 23;
            d2.Text = "D2";
            d2.Click += PoljeKlik;
            // 
            // d3
            // 
            d3.Location = new Point(466, 260);
            d3.Name = "d3";
            d3.otkljucan = false;
            d3.Size = new Size(100, 23);
            d3.TabIndex = 22;
            d3.Text = "D3";
            d3.Click += PoljeKlik;
            // 
            // d4
            // 
            d4.Location = new Point(434, 231);
            d4.Name = "d4";
            d4.otkljucan = false;
            d4.Size = new Size(100, 23);
            d4.TabIndex = 21;
            d4.Text = "D4";
            d4.Click += PoljeKlik;
            // 
            // d
            // 
            d.Location = new Point(398, 202);
            d.Name = "d";
            d.otkljucan = false;
            d.Size = new Size(100, 23);
            d.TabIndex = 20;
            d.Text = "D";
            d.Click += specijalno_polje;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(label4);
            Controls.Add(label3);
            Controls.Add(textBox1);
            Controls.Add(d1);
            Controls.Add(d2);
            Controls.Add(d3);
            Controls.Add(d4);
            Controls.Add(d);
            Controls.Add(c1);
            Controls.Add(c2);
            Controls.Add(c3);
            Controls.Add(c4);
            Controls.Add(c);
            Controls.Add(konacno);
            Controls.Add(b1);
            Controls.Add(b2);
            Controls.Add(b3);
            Controls.Add(b4);
            Controls.Add(b);
            Controls.Add(a);
            Controls.Add(a4);
            Controls.Add(a3);
            Controls.Add(a2);
            Controls.Add(a1);
            Controls.Add(label2);
            Controls.Add(label1);
            Controls.Add(pictureBox2);
            Controls.Add(pictureBox1);
            Name = "Form1";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Form1";
            Load += Form1_Load;
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox2).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.Timer timer2;
        private PictureBox pictureBox1;
        private PictureBox pictureBox2;
        private Label label1;
        private Label label2;
        private CButton a1;
        private CButton a2;
        private CButton a3;
        private CButton a4;
        private CButton a;
        private CButton b;
        private CButton b4;
        private CButton b3;
        private CButton b2;
        private CButton b1;
        private CButton konacno;
        private CButton c;
        private CButton c4;
        private CButton c3;
        private CButton c2;
        private CButton c1;
        private CButton d;
        private CButton d4;
        private CButton d3;
        private CButton d2;
        private CButton d1;
        private TextBox textBox1;
        private Label label3;
        private Label label4;
    }
}