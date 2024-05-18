using System;
using System.Collections.Generic;
using System.Threading;

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
        public static List<Karta> UstawReke(List<Karta> list)
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

        public static bool Wynik(List<Karta> list)
        {
            Random r = new Random();
            int suma = 0;
            bool wygrana = false;
            int krupier = 0;
            for (int i = 0; i < 2; i++)
            {
                krupier += r.Next(1, 11);
            }
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
            Console.WriteLine("Witaj w Black Jack'u!");
            Console.WriteLine("Wcisnij coś by iść dalej!");
            int kasa = 500;
            Console.ReadKey();
            Console.Clear();
            List<Karta> karty = new List<Karta>();
            UstawReke(karty);
            bool gra = true;
            do
            {
                Console.WriteLine("Więc trzeba coś postawić!");
                Console.WriteLine($"Mamy do dyspozycji : {kasa} PLN");
                
                int stawione = 0;
                bool inputcik = false;

                while (!inpucik)
                {
                    Console.Write("Podaj kwotę do postawienia: ");
                    string input = Console.ReadLine();
                    try
                    {
                        stawione = int.Parse(input);
                        if (stawione > kasa)
                        {
                            Console.WriteLine("Brak pieniędzy!");
                        }
                        else if (stawione <= 0)
                        {
                            Console.WriteLine("Kwota musi być większa niż 0!");
                        }
                        else
                        {
                            inpucik = true;
                        }
                    }
                    catch (FormatException)
                    {
                        Console.WriteLine("Niepoprawny format danych. Proszę wprowadzić liczbę.");
                    }
                    catch (OverflowException)
                    {
                        Console.WriteLine("Wow Gratulujemy wyniku tak potężnego, że int go nie obsługuje!");
                    }
                }

                Console.WriteLine("Twoje karty : ");
                foreach (var element in karty)
                {
                    Console.Write($"{element.Wartosc} {element.Kolor} ");
                }

                if (Wynik(karty))
                {
                    Console.WriteLine("Wygrałeś!");
                    kasa += stawione;
                }
                else
                {
                    Console.WriteLine("Przegrałeś!");
                    Thread.Sleep(1000);
                    kasa -= stawione;
                }

                if (kasa != 0)
                {
                    bool podp = false;
                    {
                        Console.WriteLine("Gramy dalej? [Y/N]");
                        string odp = Console.ReadLine();
                        if (odp == "Y" || odp == "N")
                        {
                            podp = true;
                            if (odp == "N")
                            {
                                gra = false;
                            }
                        }
                        else
                        {
                            Console.WriteLine("Niepoprawny wybór. Proszę wprowadzić Y lub N.");
                        }
                    }
                }
                if (kasa <= 0)
                {
                    Console.WriteLine("Zbankrutowałeś koniec gry!");
                    gra = false;
                }
                Console.Clear();
            } while (gra);
        }
    }
}
