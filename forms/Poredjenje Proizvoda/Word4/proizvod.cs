using System;
using System.Collections.Generic;
using System.Diagnostics.Eventing.Reader;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace proizvod
{
    class Proizvod
    {
        #region atributi
        private string _naziv, _proizvodjac;
        private double _cena;

        public string naziv { get { return _naziv; } }
        public string prozvodjac { get { return _proizvodjac; } }
        public double cena { get { return _cena; } }
        
        #endregion



        #region konstruktori
        public Proizvod(string naziv, string proizvodjac, double cena)
        {
            if (naziv.Equals(string.Empty))
                throw new Exception("Nema naziv!");
            else if (proizvodjac.Equals(string.Empty))
                throw new Exception("Nema proizvodjaca!");
            else if (cena < 0)
                throw new Exception("Cena je manja od 0!");
            else
            {
                this._naziv = naziv;
                this._proizvodjac = proizvodjac;
                this._cena = cena;
            }
        }
        public Proizvod(string naziv, string proizvodjac)
        {
            if (naziv.Equals(string.Empty)) 
                throw new Exception("Nema naziv!");
            else if (proizvodjac.Equals(string.Empty))
                throw new Exception("Nema proizvodjaca!");
            else
            {
                this._naziv = naziv;
                this._proizvodjac = proizvodjac;
                this._cena = 0;
            }
        }
        #endregion

        #region metode
        public void PromeniCenu(double novaCena)
        {
            if (novaCena < 0)
                throw new Exception("Cena je manja od 0!");
            else this._cena = novaCena;
        }
        public bool SkupljiOd(Proizvod p)
        {
            if (_cena > p._cena) return true;
            else return false;
        }
        public string Prikaz()
        {
            return $"{_naziv}, {_proizvodjac} - {_cena}RSD";
        }
        #endregion
    }
}
