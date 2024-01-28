namespace PogadjanjeBroja
{
    public partial class CustomButton : Button
    {
        private bool _clicked;
        private int _value;
        public bool clicked
        {
            get { return _clicked; }
            set { _clicked = value; }
        }
        public int value
        {
            get { return _value; }
        }

        public CustomButton(int value)
        {
            InitializeComponent();
            this._value = value;
        }
    }
}
