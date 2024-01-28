namespace Word4
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
            tbProizvod = new TextBox();
            novaCenaGroup = new GroupBox();
            btnPromeni = new Button();
            tbNovaCena = new TextBox();
            drugiProizvodGroup = new GroupBox();
            tbPoruka = new TextBox();
            btnKojiJeSkuplji = new Button();
            tbCena = new TextBox();
            tbProizvodjac = new TextBox();
            tbNaziv = new TextBox();
            cenaLabel = new Label();
            proizvodjacLabel = new Label();
            nazivLabel = new Label();
            novaCenaGroup.SuspendLayout();
            drugiProizvodGroup.SuspendLayout();
            SuspendLayout();
            // 
            // tbProizvod
            // 
            tbProizvod.Location = new Point(12, 12);
            tbProizvod.Name = "tbProizvod";
            tbProizvod.Size = new Size(366, 23);
            tbProizvod.TabIndex = 0;
            // 
            // novaCenaGroup
            // 
            novaCenaGroup.Controls.Add(btnPromeni);
            novaCenaGroup.Controls.Add(tbNovaCena);
            novaCenaGroup.Location = new Point(12, 57);
            novaCenaGroup.Name = "novaCenaGroup";
            novaCenaGroup.Size = new Size(366, 73);
            novaCenaGroup.TabIndex = 1;
            novaCenaGroup.TabStop = false;
            novaCenaGroup.Text = "Nova Cena";
            novaCenaGroup.Enter += groupBox1_Enter;
            // 
            // btnPromeni
            // 
            btnPromeni.Location = new Point(258, 31);
            btnPromeni.Name = "btnPromeni";
            btnPromeni.Size = new Size(102, 23);
            btnPromeni.TabIndex = 1;
            btnPromeni.Text = "Promeni";
            btnPromeni.UseVisualStyleBackColor = true;
            btnPromeni.Click += btnPromeni_Click;
            // 
            // tbNovaCena
            // 
            tbNovaCena.Location = new Point(11, 31);
            tbNovaCena.Name = "tbNovaCena";
            tbNovaCena.Size = new Size(241, 23);
            tbNovaCena.TabIndex = 0;
            // 
            // drugiProizvodGroup
            // 
            drugiProizvodGroup.Controls.Add(tbPoruka);
            drugiProizvodGroup.Controls.Add(btnKojiJeSkuplji);
            drugiProizvodGroup.Controls.Add(tbCena);
            drugiProizvodGroup.Controls.Add(tbProizvodjac);
            drugiProizvodGroup.Controls.Add(tbNaziv);
            drugiProizvodGroup.Controls.Add(cenaLabel);
            drugiProizvodGroup.Controls.Add(proizvodjacLabel);
            drugiProizvodGroup.Controls.Add(nazivLabel);
            drugiProizvodGroup.Location = new Point(12, 136);
            drugiProizvodGroup.Name = "drugiProizvodGroup";
            drugiProizvodGroup.Size = new Size(360, 302);
            drugiProizvodGroup.TabIndex = 2;
            drugiProizvodGroup.TabStop = false;
            drugiProizvodGroup.Text = "Drugi Proizvod";
            // 
            // tbPoruka
            // 
            tbPoruka.Location = new Point(146, 216);
            tbPoruka.Name = "tbPoruka";
            tbPoruka.Size = new Size(208, 23);
            tbPoruka.TabIndex = 7;
            // 
            // btnKojiJeSkuplji
            // 
            btnKojiJeSkuplji.Location = new Point(36, 176);
            btnKojiJeSkuplji.Name = "btnKojiJeSkuplji";
            btnKojiJeSkuplji.Size = new Size(90, 100);
            btnKojiJeSkuplji.TabIndex = 6;
            btnKojiJeSkuplji.Text = "Koji proizvod je skuplji?";
            btnKojiJeSkuplji.UseVisualStyleBackColor = true;
            btnKojiJeSkuplji.Click += btnKojiJeSkuplji_Click;
            // 
            // tbCena
            // 
            tbCena.Location = new Point(152, 126);
            tbCena.Name = "tbCena";
            tbCena.Size = new Size(202, 23);
            tbCena.TabIndex = 5;
            // 
            // tbProizvodjac
            // 
            tbProizvodjac.Location = new Point(152, 84);
            tbProizvodjac.Name = "tbProizvodjac";
            tbProizvodjac.Size = new Size(202, 23);
            tbProizvodjac.TabIndex = 4;
            // 
            // tbNaziv
            // 
            tbNaziv.Location = new Point(152, 39);
            tbNaziv.Name = "tbNaziv";
            tbNaziv.Size = new Size(202, 23);
            tbNaziv.TabIndex = 3;
            // 
            // cenaLabel
            // 
            cenaLabel.AutoSize = true;
            cenaLabel.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point);
            cenaLabel.Location = new Point(36, 124);
            cenaLabel.Name = "cenaLabel";
            cenaLabel.Size = new Size(45, 21);
            cenaLabel.TabIndex = 2;
            cenaLabel.Text = "Cena";
            cenaLabel.Click += cenaLabel_Click;
            // 
            // proizvodjacLabel
            // 
            proizvodjacLabel.AutoSize = true;
            proizvodjacLabel.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point);
            proizvodjacLabel.Location = new Point(36, 84);
            proizvodjacLabel.Name = "proizvodjacLabel";
            proizvodjacLabel.Size = new Size(90, 21);
            proizvodjacLabel.TabIndex = 1;
            proizvodjacLabel.Text = "Proizvodjac";
            // 
            // nazivLabel
            // 
            nazivLabel.AutoSize = true;
            nazivLabel.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point);
            nazivLabel.Location = new Point(36, 41);
            nazivLabel.Name = "nazivLabel";
            nazivLabel.Size = new Size(49, 21);
            nazivLabel.TabIndex = 0;
            nazivLabel.Text = "Naziv";
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(390, 450);
            Controls.Add(drugiProizvodGroup);
            Controls.Add(novaCenaGroup);
            Controls.Add(tbProizvod);
            Name = "Form1";
            Text = "Form1";
            Load += Form1_Load;
            novaCenaGroup.ResumeLayout(false);
            novaCenaGroup.PerformLayout();
            drugiProizvodGroup.ResumeLayout(false);
            drugiProizvodGroup.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private TextBox tbProizvod;
        private GroupBox novaCenaGroup;
        private Button btnPromeni;
        private TextBox tbNovaCena;
        private GroupBox drugiProizvodGroup;
        private Label cenaLabel;
        private Label proizvodjacLabel;
        private Label nazivLabel;
        private TextBox tbPoruka;
        private Button btnKojiJeSkuplji;
        private TextBox tbCena;
        private TextBox tbProizvodjac;
        private TextBox tbNaziv;
    }
}