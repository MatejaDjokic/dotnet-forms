using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SudokulicaDzons
{
    public partial class Btn : Button
    {
        int _x;
        int _y;
        int _q;
        int _val;
        bool _is_fixed;
        public int x => _x;
        public int y => _y;
        public int q => _q;
        public int val => _val;
        public bool is_fixed => _is_fixed;
        public Btn(int x, int y, bool is_fixed)
        {
            _x = x;
            _y = y;
            _q = get_q(x, y);
            _is_fixed = is_fixed;
            Enabled = _is_fixed;
            InitializeComponent();
        }
        private int get_q(int x, int y)
        {
            int qx = x / 3;
            int qy = y / 3;
            return qy * 3 + qx;
        }
        public void set(int val)
        {
            _val = val;
            this.Text = val == 0 ? "" : $"{val}";
        }
        protected override void OnPaint(PaintEventArgs pe)
        {
            base.OnPaint(pe);
        }
    }
}
