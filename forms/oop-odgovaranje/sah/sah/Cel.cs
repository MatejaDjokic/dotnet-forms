
namespace sah
{
    public partial class Cel : Button
    {
        private int _x;
        private int _y;
        public int x => _x;
        public int y => _y;
        public Cel(int x, int y)
        {
            _x = x;
            _y = y;
            InitializeComponent();
        }

        public void toggle()
        {
            if (this.Text == "●")
                this.Text = "";
            else
                this.Text = "●";
        }

        protected override void OnPaint(PaintEventArgs pe)
        {
            base.OnPaint(pe);
        }
    }
}
