
namespace mata
{
    static class Mata
    {
        private static double _arhimedov = 22.0 / 7.0;
        private static double _milu = 355.0 / 113.0;
        private static double _biblioteka = Math.PI;
        private static double _PI;

        public static double PI { get { return _PI; }  }

        public static void GetPi(String tipPi)
        {
           switch (tipPi)
           {
                case "arhimedov": _PI = _arhimedov; break;
                case "milu": _PI = _milu; break;
                case "biblioteka": _PI =  _biblioteka; break;
                default: _PI = _biblioteka; break;
           }
        }
    }
}
