using System;
using System.Collections.Generic;

namespace Black_Jack
{
    class Karta
    {
        public string Wartosc { get; set; }
        public string Kolor { get; set; }

        public Karta()
        {
            Wartosc = "Nie Ustawiono!";
            Kolor = "Nie Ustawiono!";
        }

        public Karta(string wartosc, string kolor)
        {
            Wartosc = wartosc;
            Kolor = kolor;
        }
    }
    internal class Program
    {
        public List<Karta> UstawReke(List<Karta> list)
        {
            string kolor = "";
            int wartosc = 0;
            Random r = new Random();
            for (int i = 0; i < 2; i++)
            {
                Karta karta = new Karta();
                kolor = r.Next(1, 5).ToString();
                if (kolor == "1")
                {
                    
                }

                if (kolor == "2")
                {
                    
                }

                if (kolor == "3")
                {
                    
                }
                if(kolor == "4")
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
                suma += int.Parse(element.Wartosc);
            }
            if (suma > 21)
            {
                wygrana = false;
            }

            if (suma == 21)
            {
                wygrana = true;
            }

            if (suma > krupier)
            {
                wygrana = true;
            }

            if (krupier > suma)
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