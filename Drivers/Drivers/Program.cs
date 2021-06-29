using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
namespace Drivers
{
    class Forma1 
    {
        public string PilotaNev;
        public string SzuletesiDatum;
        public string Nemzetiseg;
        public string Pilotaroviditese;

        public Forma1(string pilotanev,string szuletes, string nemzetiseg, string rovidites) 
        {
            PilotaNev = pilotanev;
            SzuletesiDatum = szuletes;
            Nemzetiseg = nemzetiseg;
            Pilotaroviditese = rovidites;
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            StreamReader Olvas = new StreamReader("drivers.csv",Encoding.Default);
            List<Forma1> Drivers = new List<Forma1>();
            string fejlec = Olvas.ReadLine();
            while (!Olvas.EndOfStream)
            {
                string sor = Olvas.ReadLine();
                string[] Sorelem = sor.Split(';');
                Drivers.Add(new Forma1(Sorelem[0], Sorelem[1], Sorelem[2], Sorelem[3]));

            }
            Olvas.Close();
            //3.Feladat
            Console.WriteLine("3.Feladat");
            Console.WriteLine($"Az állomány {Drivers.Count} adatsort tartalmaz");
            //4.Feladat
            Console.WriteLine("4.FEladat");
            int PilotaIndex=0;
            for (int i = 0; i < Drivers.Count; i++)
            {
                if (Drivers[i].Pilotaroviditese == "GLO")
                {
                    PilotaIndex = i;
                }
            }
            Console.WriteLine($"{Drivers[PilotaIndex].PilotaNev}");
            //5.Feladat
            Console.WriteLine("5.FEladat");
            for (int i = 0; i < Drivers.Count; i++)
            {
                if (Drivers[i].SzuletesiDatum.Contains("01-01"))
                {
                    Console.WriteLine($"\t{Drivers[i].PilotaNev} {Drivers[i].SzuletesiDatum.Replace('-','.')}");
                }
            }
            //6.Feladat
            Console.WriteLine("6.Feladat");
            Console.WriteLine("Kérek egy rövidítést");
            bool Eleglesz = false;
            bool Volte = false;
            int Bekertelemindex = 0;
            while (Eleglesz == false)
            {
                string BekertElem = Console.ReadLine();

                for (int i = 0; i < Drivers.Count; i++)
                {
                    if (BekertElem == Drivers[i].Pilotaroviditese)
                    {
                        Volte = true;
                        Bekertelemindex = i;
                        Console.WriteLine("bekertelem" + i);
                    }
                }
                // EXIT CODE WITH THIS
                if (BekertElem == "")
                {
                    Eleglesz = true;
                }
            }
            Console.WriteLine(Volte);
            Console.WriteLine(Bekertelemindex);
            //7.Feladat
            if (Volte == true)
            {
                Console.WriteLine($"{Drivers[Bekertelemindex].PilotaNev}");
                Console.WriteLine($"{Drivers[Bekertelemindex].Nemzetiseg}");
                Console.WriteLine($"{Drivers[Bekertelemindex].SzuletesiDatum.Replace('-','.')}");
            }
            else
            {
                Console.WriteLine("Nincs ilyen Pilóta");
            }
            //8.Feladat
            Console.WriteLine("8.Feladat");
            List<string> Orszagok = new List<string>();
            for (int i = 0; i < Drivers.Count; i++)
            {
                bool Vane = false;
                for (int j = 0; j < Orszagok.Count; j++)
                {
                    if (Drivers[i].Nemzetiseg == Orszagok[j])
                    {
                        Vane = true;
                    }
                }
                if (Vane == false)
                {
                    Orszagok.Add(Drivers[i].Nemzetiseg);
                }
            }
            int[] Segedtomb = new int[Orszagok.Count];
            for (int i = 0; i < Drivers.Count; i++)
            {
                for (int j = 0; j < Orszagok.Count; j++)
                {
                    if (Drivers[i].Nemzetiseg == Orszagok[j])
                    {
                        Segedtomb[j]++;
                    }
                }
            }
            for (int i = 0; i < Segedtomb.Length; i++)
            {
                if (Segedtomb[i] > 30)
                {
                    Console.Write($"{Orszagok[i]}, ");
                }
            }
            Console.ReadLine();

        }
    }
}
