using Accessibility;
using System.Diagnostics.Eventing.Reader;

namespace Sastavi4
{
    public partial class Polje : Button
    {
        private Status _status;
        public Status status { get => _status; set => _status = value; }
        private int _red, _kolona;
        public int red { get => _red; }
        public int kolona { get => _kolona; }
        public Polje(int red, int kolona)
        {
            InitializeComponent();
            this._status = Status.Prazno;
            this._red = red;
            this._kolona = kolona;
        }

        protected override void OnPaint(PaintEventArgs pe)
        {
            base.OnPaint(pe);
        }
        public void toggle()
        {
            if (status == Status.Prazno)
                status = Status.Zuto;
            else if (status == Status.Zuto)
                status = Status.Crveno;
            else if (status == Status.Crveno)
                status = Status.Prazno;
        }
    }
}
