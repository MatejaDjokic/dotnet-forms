using Util;

namespace Ulogovanje
{
    public partial class Form2 : Form
    {
        private User _logged_user;
        public User logged_user
        {
            get { return _logged_user; }
        }
        public Form2(User logged_user)
        {
            InitializeComponent();
            this._logged_user = logged_user;
        }

        private void Form2_Load(object sender, EventArgs e)
        {
            label1.Text = $"First name: {this.logged_user.first_name}\n" +
                $"Last name: {this.logged_user.last_name}\n" +
                $"Email: {this.logged_user.email}\n" +
                $"Age: {this.logged_user.age}\n";
        }
    }
}
