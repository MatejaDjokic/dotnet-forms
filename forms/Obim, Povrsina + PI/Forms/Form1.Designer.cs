namespace Forms
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
            groupBox1 = new GroupBox();
            tby1 = new TextBox();
            tbx1 = new TextBox();
            groupBox2 = new GroupBox();
            tby2 = new TextBox();
            tbx2 = new TextBox();
            dugme = new Button();
            obim = new TextBox();
            clear = new Button();
            izadji = new Button();
            groupBox3 = new GroupBox();
            povrsina = new TextBox();
            pi_comboBox = new ComboBox();
            pi_group = new GroupBox();
            timer1 = new System.Windows.Forms.Timer(components);
            timer2 = new System.Windows.Forms.Timer(components);
            timer3 = new System.Windows.Forms.Timer(components);
            timer4 = new System.Windows.Forms.Timer(components);
            pi_broj = new TextBox();
            groupBox1.SuspendLayout();
            groupBox2.SuspendLayout();
            groupBox3.SuspendLayout();
            pi_group.SuspendLayout();
            SuspendLayout();
            // 
            // groupBox1
            // 
            groupBox1.Controls.Add(tby1);
            groupBox1.Controls.Add(tbx1);
            groupBox1.Location = new Point(31, 93);
            groupBox1.Name = "groupBox1";
            groupBox1.Size = new Size(200, 100);
            groupBox1.TabIndex = 0;
            groupBox1.TabStop = false;
            groupBox1.Text = "Kordinate centra kruznice";
            // 
            // tby1
            // 
            tby1.Location = new Point(100, 43);
            tby1.Name = "tby1";
            tby1.PlaceholderText = "y1";
            tby1.Size = new Size(75, 23);
            tby1.TabIndex = 1;
            // 
            // tbx1
            // 
            tbx1.Location = new Point(19, 43);
            tbx1.Name = "tbx1";
            tbx1.PlaceholderText = "x1";
            tbx1.Size = new Size(75, 23);
            tbx1.TabIndex = 0;
            tbx1.TextChanged += textBox1_TextChanged;
            // 
            // groupBox2
            // 
            groupBox2.Controls.Add(tby2);
            groupBox2.Controls.Add(tbx2);
            groupBox2.Location = new Point(31, 199);
            groupBox2.Name = "groupBox2";
            groupBox2.Size = new Size(200, 100);
            groupBox2.TabIndex = 1;
            groupBox2.TabStop = false;
            groupBox2.Text = "Kordinate tacke na kruznici";
            // 
            // tby2
            // 
            tby2.Location = new Point(100, 40);
            tby2.Name = "tby2";
            tby2.PlaceholderText = "y2";
            tby2.Size = new Size(75, 23);
            tby2.TabIndex = 3;
            // 
            // tbx2
            // 
            tbx2.Location = new Point(19, 40);
            tbx2.Name = "tbx2";
            tbx2.PlaceholderText = "x2";
            tbx2.Size = new Size(75, 23);
            tbx2.TabIndex = 2;
            // 
            // dugme
            // 
            dugme.Location = new Point(246, 209);
            dugme.Name = "dugme";
            dugme.Size = new Size(200, 42);
            dugme.TabIndex = 2;
            dugme.Text = "Izracunaj";
            dugme.UseVisualStyleBackColor = true;
            dugme.Click += button1_Click;
            // 
            // obim
            // 
            obim.Location = new Point(6, 22);
            obim.Name = "obim";
            obim.Size = new Size(188, 23);
            obim.TabIndex = 4;
            // 
            // clear
            // 
            clear.Location = new Point(246, 257);
            clear.Name = "clear";
            clear.Size = new Size(200, 42);
            clear.TabIndex = 5;
            clear.Text = "Obrisi";
            clear.UseVisualStyleBackColor = true;
            clear.Click += clear_Click;
            // 
            // izadji
            // 
            izadji.Location = new Point(570, 388);
            izadji.Name = "izadji";
            izadji.Size = new Size(50, 50);
            izadji.TabIndex = 6;
            izadji.Text = "X";
            izadji.UseVisualStyleBackColor = true;
            izadji.Click += izadji_Click;
            // 
            // groupBox3
            // 
            groupBox3.Controls.Add(povrsina);
            groupBox3.Controls.Add(obim);
            groupBox3.Location = new Point(246, 93);
            groupBox3.Name = "groupBox3";
            groupBox3.Size = new Size(200, 100);
            groupBox3.TabIndex = 7;
            groupBox3.TabStop = false;
            groupBox3.Text = "Obim/Povrsina";
            // 
            // povrsina
            // 
            povrsina.Location = new Point(6, 62);
            povrsina.Name = "povrsina";
            povrsina.Size = new Size(188, 23);
            povrsina.TabIndex = 5;
            povrsina.TextChanged += povrsina_TextChanged;
            // 
            // pi_comboBox
            // 
            pi_comboBox.FormattingEnabled = true;
            pi_comboBox.Items.AddRange(new object[] { "arhimedov", "milu", "biblioteka" });
            pi_comboBox.Location = new Point(6, 22);
            pi_comboBox.Name = "pi_comboBox";
            pi_comboBox.Size = new Size(131, 23);
            pi_comboBox.TabIndex = 8;
            pi_comboBox.SelectedIndexChanged += pi_comboBox_SelectedIndexChanged;
            // 
            // pi_group
            // 
            pi_group.Controls.Add(pi_broj);
            pi_group.Controls.Add(pi_comboBox);
            pi_group.Location = new Point(452, 93);
            pi_group.Name = "pi_group";
            pi_group.Size = new Size(143, 100);
            pi_group.TabIndex = 9;
            pi_group.TabStop = false;
            pi_group.Text = "PI";
            // 
            // timer1
            // 
            timer1.Tick += timer1_Tick;
            // 
            // timer3
            // 
            timer3.Tick += timer3_Tick;
            // 
            // timer4
            // 
            timer4.Tick += timer4_Tick;
            // 
            // pi_broj
            // 
            pi_broj.Location = new Point(6, 62);
            pi_broj.Name = "pi_broj";
            pi_broj.Size = new Size(131, 23);
            pi_broj.TabIndex = 9;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(632, 450);
            Controls.Add(pi_group);
            Controls.Add(groupBox3);
            Controls.Add(izadji);
            Controls.Add(clear);
            Controls.Add(dugme);
            Controls.Add(groupBox2);
            Controls.Add(groupBox1);
            Name = "Form1";
            Text = "Form1";
            Load += Form1_Load;
            groupBox1.ResumeLayout(false);
            groupBox1.PerformLayout();
            groupBox2.ResumeLayout(false);
            groupBox2.PerformLayout();
            groupBox3.ResumeLayout(false);
            groupBox3.PerformLayout();
            pi_group.ResumeLayout(false);
            pi_group.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private GroupBox groupBox1;
        private TextBox tby1;
        private TextBox tbx1;
        private GroupBox groupBox2;
        private TextBox tby2;
        private TextBox tbx2;
        private Button dugme;
        private TextBox obim;
        private Button clear;
        private Button izadji;
        private GroupBox groupBox3;
        private TextBox povrsina;
        private ComboBox pi_comboBox;
        private GroupBox pi_group;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.Timer timer2;
        private System.Windows.Forms.Timer timer3;
        private System.Windows.Forms.Timer timer4;
        private TextBox pi_broj;
    }
}