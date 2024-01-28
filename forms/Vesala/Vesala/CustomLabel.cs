using System;
namespace Vesala
{
    public partial class CustomLabel : Label
    {
        private string _value;
        private bool _opened;
        public string value
        {
            get => _value;
        }

        public bool opened
        {
            get => _opened;
        }
        public CustomLabel(string value)
        {
            InitializeComponent();
            this._value = value;
            this._opened = false;
        }

        public void show()
        {
            this.Text = this._value.ToUpper();
            this._opened = true;
        }
    }
}
