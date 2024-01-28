using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Vesala
{
    public partial class CustomButton : Button
    {
        private string _value;
        public string value
        {
            get { return  _value; } 
        }
        public CustomButton(string value)
        {
            InitializeComponent();
            this._value = value;
        }
    }
}
