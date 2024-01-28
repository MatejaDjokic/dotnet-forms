using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Vesala
{
    public partial class Form2 : Form
    {
        private static int MAX_LETTER_COUNT = 16;
        private string word;
        public Form2()
        {
            InitializeComponent();
            word = String.Empty;
        }

        private void Form2_Load(object sender, EventArgs e)
        {
            textBox1.TextAlign = HorizontalAlignment.Center;
            textBox1.Text = "Molim vas unesite rec!";
            textBox1.LostFocus += lost_focus!;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string w = this.word;
            if (w.Length >= MAX_LETTER_COUNT || w.Length <= 1)
                MessageBox.Show("Rec ne sme biti prazna, jedno slovo i mora da bude manja ili jednaka 20 slova!");
            else
            {
                textBox1.PasswordChar = '*';
                Form1 f = new Form1(this.word);
                f.Show();
            }
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            textBox1.PasswordChar = '\0';
            if (this.textBox1.Text.ToCharArray().Any(c => char.IsDigit(c)))
                throw new Exception("Rec ne sme da sadrzi brojeve!");
            this.word = textBox1.Text.TrimStart().TrimEnd().ToLower();
        }

        private void lost_focus(object sender, EventArgs e)
        {
            textBox1.Text = this.textBox1.Text.ToUpper();
        }


    }
}
