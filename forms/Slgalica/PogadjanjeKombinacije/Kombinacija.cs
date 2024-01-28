using System;
using System.CodeDom.Compiler;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PogadjanjeKombinacije
{
    class Kombinacija
    {
        private int _broj_karaktera;
        public int broj_karaktera { get => _broj_karaktera; }
        public char[] _mogucnosti;
        public char[] mogucnosti { get => _mogucnosti; }
        private string _kombinacija;
        public string kombinacijica { get => _kombinacija; }
        public Kombinacija(int broj_karaktera, int broj_mogucnosti)
        {
            _mogucnosti = new char[broj_mogucnosti];
            for (int i = 1; i <= broj_mogucnosti; i++)
                _mogucnosti[i - 1] = i.ToString().First();

            Random rnd = new Random();
            for (int i = 0; i < broj_karaktera; i++)
            {
                _kombinacija += rnd.Next(1, broj_mogucnosti).ToString();
            }
        }

        public Kombinacija(string kombinacija, int broj_mogucnosti)
        {
            _kombinacija = kombinacija;
            _broj_karaktera = kombinacija.Length;

            _mogucnosti = new char[broj_mogucnosti];
            for (int i = 1; i <= broj_mogucnosti; i++)
                _mogucnosti[i - 1] = i.ToString().First();
        }

        public string odgovor1(string pitanje)
        {
            List<char> podudarni = new List<char>();
            char[] pitanje_chars = pitanje.ToCharArray();
            char[] odgovor_chars = kombinacijica.ToCharArray();

            for (int i = 0; i < pitanje.Length; i++)
            {
                char dodavanje = pitanje_chars[i] == odgovor_chars[i] ? pitanje[i] : '_';
                podudarni.Add(dodavanje);
            }
            return podudarni.Count > 0 ? string.Join("", podudarni) : "Nema podudaranja";
        }

        public string odgovor2(string pitanje)
        {
            int podudarni = 0;
            int nisu_na_mestu = 0;
            char[] pitanje_chars = pitanje.ToCharArray();
            char[] odgovor_chars = kombinacijica.ToCharArray();
            List<char> odgovor_chars_2 = new List<char>();

            foreach (char c in odgovor_chars)
                if (!odgovor_chars_2.Contains(c))
                    odgovor_chars_2.Add(c);

            for (int i = 0; i < pitanje.Length; i++)
            {
                bool bul = pitanje_chars[i] == odgovor_chars[i];
                podudarni = bul ? podudarni + 1 : podudarni;

                string t = string.Join("", odgovor_chars_2);

                int p = 0;
                while ((p = t.IndexOf(pitanje[i], p)) != -1)
                {
                    nisu_na_mestu++;
                    p++;
                }
            }


            return $"{podudarni}, {nisu_na_mestu}";
        }
    }
}
