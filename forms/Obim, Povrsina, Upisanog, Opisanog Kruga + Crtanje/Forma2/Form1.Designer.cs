namespace Forma2
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
            nacrtaj = new Button();
            stranica = new TextBox();
            tb_ru = new TextBox();
            tb_ro = new TextBox();
            tb_Pu = new TextBox();
            tb_Po = new TextBox();
            tb_Oo = new TextBox();
            tb_Ou = new TextBox();
            timer1 = new System.Windows.Forms.Timer(components);
            SuspendLayout();
            // 
            // nacrtaj
            // 
            nacrtaj.Location = new Point(12, 397);
            nacrtaj.Name = "nacrtaj";
            nacrtaj.Size = new Size(776, 41);
            nacrtaj.TabIndex = 0;
            nacrtaj.Text = "Nacrtaj/Izracunaj";
            nacrtaj.UseVisualStyleBackColor = true;
            nacrtaj.Click += izracunajClick;
            // 
            // stranica
            // 
            stranica.Location = new Point(12, 30);
            stranica.Name = "stranica";
            stranica.Size = new Size(195, 23);
            stranica.TabIndex = 1;
            stranica.Text = "Stranica kvadrata: ";
            stranica.TextChanged += stranice_TextChanged;
            // 
            // tb_ru
            // 
            tb_ru.Location = new Point(12, 59);
            tb_ru.Name = "tb_ru";
            tb_ru.Size = new Size(195, 23);
            tb_ru.TabIndex = 2;
            // 
            // tb_ro
            // 
            tb_ro.Location = new Point(12, 88);
            tb_ro.Name = "tb_ro";
            tb_ro.Size = new Size(195, 23);
            tb_ro.TabIndex = 3;
            // 
            // tb_Pu
            // 
            tb_Pu.Location = new Point(12, 117);
            tb_Pu.Name = "tb_Pu";
            tb_Pu.Size = new Size(195, 23);
            tb_Pu.TabIndex = 4;
            // 
            // tb_Po
            // 
            tb_Po.Location = new Point(12, 146);
            tb_Po.Name = "tb_Po";
            tb_Po.Size = new Size(195, 23);
            tb_Po.TabIndex = 5;
            // 
            // tb_Oo
            // 
            tb_Oo.Location = new Point(12, 204);
            tb_Oo.Name = "tb_Oo";
            tb_Oo.Size = new Size(195, 23);
            tb_Oo.TabIndex = 6;
            // 
            // tb_Ou
            // 
            tb_Ou.Location = new Point(12, 175);
            tb_Ou.Name = "tb_Ou";
            tb_Ou.Size = new Size(195, 23);
            tb_Ou.TabIndex = 7;
            // 
            // timer1
            // 
            timer1.Enabled = true;
            timer1.Tick += tajmerKucanje;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(tb_Oo);
            Controls.Add(tb_Ou);
            Controls.Add(tb_Po);
            Controls.Add(tb_Pu);
            Controls.Add(tb_ro);
            Controls.Add(tb_ru);
            Controls.Add(stranica);
            Controls.Add(nacrtaj);
            Name = "Form1";
            Text = "Form1";
            Load += Form1_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button nacrtaj;
        private TextBox stranica;
        private TextBox tb_ru;
        private TextBox tb_ro;
        private TextBox tb_Pu;
        private TextBox tb_Po;
        private TextBox tb_Oo;
        private TextBox tb_Ou;
        private CheckBox checkBox1;
        private System.Windows.Forms.Timer timer1;
    }
}