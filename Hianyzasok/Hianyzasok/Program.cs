using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.ComponentModel.Design;

namespace Hianyzasok
{
    class Hianyzasok 
    {
        public string Nev;
        public string Osztaly;
        public int Elsonap;
        public int Uccsonap;
        public int Mulasztottorak;

        public Hianyzasok(string Nev, string Osztaly, int Elsonap, int Uccsonap, int Mulasztottorak) 
        {
            this.Nev = Nev ;
            this.Osztaly = Osztaly;
            this.Elsonap = Elsonap;
            this.Uccsonap = Uccsonap;
            this.Mulasztottorak = Mulasztottorak;
        }
    }
        
    class Program
    {
        static void Main(string[] args)
        {
            List<Hianyzasok> Hiany = new List<Hianyzasok>();
            StreamReader Olvas = new StreamReader("szeptember.csv",Encoding.Default);
            string fejlec = Olvas.ReadLine();
            while (!Olvas.EndOfStream)
            {
                string sor = Olvas.ReadLine();
                string[] sorelem = sor.Split(';');
                Hiany.Add(new Hianyzasok(sorelem[0], sorelem[1], Convert.ToInt32(sorelem[2]), Convert.ToInt32(sorelem[3]), Convert.ToInt32(sorelem[4])));
            }
            Olvas.Close();
            //2.Feladat
            Console.WriteLine("2.Feladat");
            int ossz = 0;
            for (int i = 0; i < Hiany.Count; i++)
            {
                ossz += Hiany[i].Mulasztottorak;
            }
            Console.WriteLine($"{ossz}");
            ///3.Feladat
            Console.WriteLine("3.Feldat");
            Console.WriteLine("Kérem adjon meg egy napot");
            int nap = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Kérem adjon meg egy nevet");
            string nev = Console.ReadLine();

            //4.Feldat
            Console.WriteLine("4.Feladat");
            bool Hianyzott = false;
            for (int i = 0; i < Hiany.Count; i++)
            {
                if (nev ==  Hiany[i].Nev)
                {
                        Hianyzott = true;
                }
            }
            if (Hianyzott == false)
            {
                Console.WriteLine("A tanulo Hianyzott");
            }
            else
            {
                Console.WriteLine("A tanulo nem hianyzott");
            }
            //5.Feladat
            Console.WriteLine("5.Feladat");
            bool Volte = false;
            for (int i = 0; i < Hiany.Count; i++)
            {
                if (nap >= Hiany[i].Elsonap && nap <= Hiany[i].Uccsonap)
                {
                    Console.WriteLine($"{Hiany[i].Nev}, {Hiany[i].Osztaly}, {Hiany[i].Mulasztottorak}");
                    Volte = true;
                }
            }
            if (Volte == false)
            {
                Console.WriteLine("Nemvolt hianzo");
            }


            Console.ReadLine();
        }
        
    }
}
