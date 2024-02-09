namespace minolovac
{
    partial class Pocetak
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
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
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            play_btn = new Button();
            gb_mine_number = new GroupBox();
            tb_mine_number = new TextBox();
            gb_mine_number.SuspendLayout();
            SuspendLayout();
            // 
            // play_btn
            // 
            play_btn.Location = new Point(12, 76);
            play_btn.Name = "play_btn";
            play_btn.Size = new Size(346, 34);
            play_btn.TabIndex = 1;
            play_btn.Text = "Igraj";
            play_btn.UseVisualStyleBackColor = true;
            play_btn.Click += play_btn_click;
            // 
            // gb_mine_number
            // 
            gb_mine_number.Controls.Add(tb_mine_number);
            gb_mine_number.Location = new Point(12, 12);
            gb_mine_number.Name = "gb_mine_number";
            gb_mine_number.Size = new Size(346, 58);
            gb_mine_number.TabIndex = 2;
            gb_mine_number.TabStop = false;
            gb_mine_number.Text = "Broj mina";
            // 
            // tb_mine_number
            // 
            tb_mine_number.Location = new Point(6, 22);
            tb_mine_number.Name = "tb_mine_number";
            tb_mine_number.Size = new Size(323, 23);
            tb_mine_number.TabIndex = 0;
            tb_mine_number.TextChanged += tb_mine_number_text_changed;
            // 
            // Pocetak
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(370, 122);
            Controls.Add(gb_mine_number);
            Controls.Add(play_btn);
            Name = "Pocetak";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Pocetak";
            Load += pocetak_load;
            gb_mine_number.ResumeLayout(false);
            gb_mine_number.PerformLayout();
            ResumeLayout(false);
        }

        #endregion
        private Button play_btn;
        private GroupBox gb_mine_number;
        private TextBox tb_mine_number;
    }
}