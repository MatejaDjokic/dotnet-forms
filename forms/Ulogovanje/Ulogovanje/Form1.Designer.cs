namespace Ulogovanje
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
            logBtn = new Button();
            regBtn = new Button();
            backBtn = new Button();
            tbUsername = new TextBox();
            tbPassword = new TextBox();
            label1 = new Label();
            usernameGroup = new GroupBox();
            passwordGroup = new GroupBox();
            logRegBtn = new Button();
            usernameGroup.SuspendLayout();
            passwordGroup.SuspendLayout();
            SuspendLayout();
            // 
            // logBtn
            // 
            logBtn.Location = new Point(130, 302);
            logBtn.Name = "logBtn";
            logBtn.Size = new Size(146, 31);
            logBtn.TabIndex = 0;
            logBtn.Text = "ULOGUJ SE";
            logBtn.UseVisualStyleBackColor = true;
            logBtn.Click += loginBtnClick;
            // 
            // regBtn
            // 
            regBtn.Location = new Point(130, 339);
            regBtn.Name = "regBtn";
            regBtn.Size = new Size(146, 31);
            regBtn.TabIndex = 1;
            regBtn.Text = "REGISTRUJ SE";
            regBtn.UseVisualStyleBackColor = true;
            regBtn.Click += registerBtnClick;
            // 
            // backBtn
            // 
            backBtn.Location = new Point(12, 12);
            backBtn.Name = "backBtn";
            backBtn.Size = new Size(40, 40);
            backBtn.TabIndex = 2;
            backBtn.Text = "<";
            backBtn.UseVisualStyleBackColor = true;
            backBtn.Click += backBtnClick;
            // 
            // tbUsername
            // 
            tbUsername.Location = new Point(6, 22);
            tbUsername.Name = "tbUsername";
            tbUsername.Size = new Size(305, 23);
            tbUsername.TabIndex = 3;
            tbUsername.TextChanged += tbUsernameChanged;
            // 
            // tbPassword
            // 
            tbPassword.Location = new Point(6, 22);
            tbPassword.Name = "tbPassword";
            tbPassword.PasswordChar = '*';
            tbPassword.Size = new Size(305, 23);
            tbPassword.TabIndex = 4;
            tbPassword.TextChanged += tbPasswordChanged;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(174, 90);
            label1.Name = "label1";
            label1.Size = new Size(38, 15);
            label1.TabIndex = 5;
            label1.Text = "label1";
            // 
            // usernameGroup
            // 
            usernameGroup.Controls.Add(tbUsername);
            usernameGroup.Location = new Point(48, 143);
            usernameGroup.Name = "usernameGroup";
            usernameGroup.Size = new Size(317, 65);
            usernameGroup.TabIndex = 6;
            usernameGroup.TabStop = false;
            usernameGroup.Text = "Korisnicko Ime";
            // 
            // passwordGroup
            // 
            passwordGroup.Controls.Add(tbPassword);
            passwordGroup.Location = new Point(48, 214);
            passwordGroup.Name = "passwordGroup";
            passwordGroup.Size = new Size(317, 65);
            passwordGroup.TabIndex = 4;
            passwordGroup.TabStop = false;
            passwordGroup.Text = "Lozinka";
            // 
            // logRegBtn
            // 
            logRegBtn.Location = new Point(48, 376);
            logRegBtn.Name = "logRegBtn";
            logRegBtn.Size = new Size(311, 31);
            logRegBtn.TabIndex = 7;
            logRegBtn.UseVisualStyleBackColor = true;
            logRegBtn.Click += logRegBtnClick;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(419, 450);
            Controls.Add(logRegBtn);
            Controls.Add(passwordGroup);
            Controls.Add(usernameGroup);
            Controls.Add(label1);
            Controls.Add(backBtn);
            Controls.Add(regBtn);
            Controls.Add(logBtn);
            Name = "Form1";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Ulogovanje";
            Load += Form1_Load;
            usernameGroup.ResumeLayout(false);
            usernameGroup.PerformLayout();
            passwordGroup.ResumeLayout(false);
            passwordGroup.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button button1;
        private Button button2;
        private Button logBtn;
        private Button regBtn;
        private Button backBtn;
        private TextBox tbUsername;
        private TextBox tbPassword;
        private Label label1;
        private GroupBox usernameGroup;
        private GroupBox passwordGroup;
        private Button logRegBtn;
    }
}