namespace minolovac
{
    partial class Minolovac
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
            restart_button = new Button();
            mark_mode_btn = new Button();
            SuspendLayout();
            // 
            // restart_button
            // 
            restart_button.Anchor = AnchorStyles.Bottom;
            restart_button.Location = new Point(10, 492);
            restart_button.Name = "restart_button";
            restart_button.Size = new Size(430, 39);
            restart_button.TabIndex = 1;
            restart_button.Text = "Restartuj";
            restart_button.UseVisualStyleBackColor = true;
            restart_button.Click += restart_button_click;
            // 
            // mark_mode_btn
            // 
            mark_mode_btn.Anchor = AnchorStyles.Left | AnchorStyles.Right;
            mark_mode_btn.Location = new Point(10, 447);
            mark_mode_btn.Name = "mark_mode_btn";
            mark_mode_btn.Size = new Size(430, 39);
            mark_mode_btn.TabIndex = 2;
            mark_mode_btn.Text = "Mod Oznacavanja";
            mark_mode_btn.UseVisualStyleBackColor = true;
            mark_mode_btn.Click += mark_mode_btn_click;
            // 
            // Minolovac
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(450, 541);
            Controls.Add(mark_mode_btn);
            Controls.Add(restart_button);
            Location = new Point(466, 540);
            MaximumSize = new Size(466, 580);
            MinimumSize = new Size(466, 580);
            Name = "Minolovac";
            Padding = new Padding(10);
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Minolovac";
            Load += form_load;
            ResumeLayout(false);
        }

        #endregion
        private Button restart_button;
        private Button mark_mode_btn;
    }
}
