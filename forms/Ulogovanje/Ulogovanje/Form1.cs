using System.Diagnostics.Eventing.Reader;
using Util;

namespace Ulogovanje
{
    public partial class Form1 : Form
    {
        String current_username = "";
        String current_password = "";
        AuthType auth_type;

        public Form1()
        {
            InitializeComponent();
            backBtn.Visible = false;
            regBtn.Visible = true;
            backBtn.Visible = false;

            tbPassword.Visible = false;
            tbUsername.Visible = false;

            usernameGroup.Visible = false;
            passwordGroup.Visible = false;

            logRegBtn.Visible = false;

            label1.Visible = false;
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            Auth.loadUsers();
        }

        private void loginBtnClick(object sender, EventArgs e)
        {
            auth_type = AuthType.Login;
            logBtn.Visible = false;
            regBtn.Visible = false;
            backBtn.Visible = true;

            tbPassword.Visible = true;
            tbUsername.Visible = true;

            usernameGroup.Visible = true;
            passwordGroup.Visible = true;

            logRegBtn.Visible = true;
            logRegBtn.Text = "ULOGUJTE SE";

            label1.Visible = true;
            label1.Text = "ULOGUJTE SE";
        }

        private void registerBtnClick(object sender, EventArgs e)
        {
            auth_type = AuthType.Register;
            logBtn.Visible = false;
            regBtn.Visible = false;
            backBtn.Visible = true;

            tbPassword.Visible = true;
            tbUsername.Visible = true;

            usernameGroup.Visible = true;
            passwordGroup.Visible = true;

            logRegBtn.Visible = true;
            logRegBtn.Text = "REGISTRUJ SE";

            label1.Visible = true;
            label1.Text = "REGISTRUJTE SE";
        }

        private void backBtnClick(object sender, EventArgs e)
        {
            auth_type = AuthType.Null;
            logBtn.Visible = true;
            regBtn.Visible = true;
            backBtn.Visible = false;

            tbPassword.Visible = false;
            tbUsername.Visible = false;

            usernameGroup.Visible = false;
            passwordGroup.Visible = false;

            logRegBtn.Visible = false;

            label1.Visible = false;
            label1.Text = "";
        }

        private void tbPasswordChanged(object sender, EventArgs e)
        {
            try
            {
                this.current_password = tbPassword.Text.Trim();
            }
            catch (Exception ex) { MessageBox.Show(ex.Message); }
        }

        private void tbUsernameChanged(object sender, EventArgs e)
        {
            try
            {
                this.current_username = tbUsername.Text.Trim();
            }
            catch (Exception ex) { MessageBox.Show(ex.Message); }
        }

        private void logRegBtnClick(object sender, EventArgs e)
        {
            if (auth_type == AuthType.Login)
                Auth.Login(current_username, current_password);
            else if (auth_type == AuthType.Register)
                Auth.Register(current_username, current_password);
        }
    }
}