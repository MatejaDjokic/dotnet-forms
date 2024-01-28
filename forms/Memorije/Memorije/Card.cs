namespace Memorije
{
    public partial class Card : Button
    {
        private char _value;
        private int _id;
        private bool _found;
        public int id
        {
            get { return _id; }
        }
        public char value
        {
            get { return _value; }
        }
        public bool found
        {
            get { return _found; }
            set { _found = value; }
        }
        public Card(char value, int id)
        {
            InitializeComponent();
            this._value = value;
            this._id = id;
        }

        protected override void OnPaint(PaintEventArgs pe)
        {
            base.OnPaint(pe);
        }
    }
}
