using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WinFormsApp1
{
    public partial class CButton : Button
    {
        private String _resenje;
        private bool _otkljucan;
        private String _klasa;
        private int _broj;
        public String resenje { get { return _resenje; } }
        public bool otkljucan { get { return _otkljucan; } set { _otkljucan = value; } }
        public String klasa { get { return _klasa; } }
        public int broj { get { return _broj; } }
        
        public CButton(String resenje, String klasa, int broj)
        {
            this._resenje = resenje;
            this._klasa = klasa;
            this._broj = broj;
            InitializeComponent();
        }

        protected override void OnPaint(PaintEventArgs pe)
        {
            base.OnPaint(pe);
        }
    }
}
