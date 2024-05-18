using System;
using System.Collections.Generic;

namespace Black_Jack
{
    class Karta
    {
        public int Wartosc { get; set; }
        public string Kolor { get; set; }

        public Karta(int wartosc, string kolor)
        {
            Wartosc = wartosc;
            Kolor = kolor;
        }
    }

    internal class Program
    {
        public List<Karta> UstawReke(List<Karta> list)
        {
            string[] kolory = { "\u2665\ufe0e", "\u2666", "\u2663", "\u2660" };
            Random r = new Random();

            for (int i = 0; i < 2; i++)
            {
                int wartosc = r.Next(1, 14);
                string kolor = kolory[r.Next(0, 4)];

                if (wartosc > 10)
                {
                    wartosc = 10;
                }

                Karta karta = new Karta(wartosc, kolor);
                list.Add(karta);
            }

            return list;
        }

        public bool Wynik(List<Karta> list)
        {
            Random r = new Random();
            int suma = 0;
            bool wygrana = false;
            int krupier = r.Next(2, 22);
            foreach (var element in list)
            {
                suma += element.Wartosc;
            }
            if (suma > 21)
            {
                wygrana = false;
            }
            else if (suma == 21 || suma > krupier)
            {
                wygrana = true;
            }
            else if (krupier > suma)
            {
                wygrana = false;
            }
            return wygrana;
        }

        public static void Main(string[] args)
        {
            
        }
    }
}
