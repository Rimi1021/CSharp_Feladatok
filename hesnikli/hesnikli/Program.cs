using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace hesnikli
{
    class Hesnikli 
    {
        public string Nev;
        public string Orszagkod;
        public double Technikaipont;
        public double Komponens;
        public int Hibapont;

        public Hesnikli(string nev, string orszagkod, double technikaipont, double komponens, int hibapont) 
        {
            Nev = nev;
            Orszagkod = orszagkod;
            Technikaipont = technikaipont;
            Komponens = komponens;
            Hibapont = hibapont;
        }
   
    }

    class Eredmeny 
    {
        public string Nev;
        public string Orszag;
        public double Osszpont;

        public Eredmeny(string nev, string orszag, double osszpont)
        {       
            Nev = nev;
            Orszag = orszag;
            Osszpont = osszpont;
        }
    }
    class Program
    {
        static List<Hesnikli> rovidlist = new List<Hesnikli>();
        static List<Hesnikli> donto = new List<Hesnikli>();
        static void Main(string[] args)
        {
            
            //rovidcs beolvasas
            StreamReader Olvas = new StreamReader("rovidprogram.csv",Encoding.Default);
           // List<Hesnikli> rovidlist = new List<Hesnikli>();
            string fejlec = Olvas.ReadLine();
            while (!Olvas.EndOfStream)
            {
                string sor = Olvas.ReadLine();
                string[] sorelem = sor.Split(';');
                rovidlist.Add(new Hesnikli(sorelem[0], sorelem[1], Convert.ToDouble(sorelem[2]), Convert.ToDouble(sorelem[3]), Convert.ToInt32(sorelem[4])));
            }
            Olvas.Close();

            //dontobeolvasas
            StreamReader Olvas2 = new StreamReader("donto.csv", Encoding.Default);
            //List<Hesnikli> donto = new List<Hesnikli>();
            string fejlec2 = Olvas2.ReadLine();
            while (!Olvas2.EndOfStream)
            {
                string sor = Olvas2.ReadLine();
                string[] sorelem = sor.Split(';');
                donto.Add(new Hesnikli(sorelem[0], sorelem[1], Convert.ToDouble(sorelem[2]), Convert.ToDouble(sorelem[3]), Convert.ToInt32(sorelem[4])));
            }
            Olvas2.Close();

            //2
            Console.WriteLine($"{rovidlist.Count} a versenyzők száma");

            //3
            bool vanhun = false;
            for (int i = 0; i < donto.Count; i++)
            {
                if (donto[i].Orszagkod =="HUN")
                {
                    vanhun = true;
                }
            }
            if (vanhun == true)
            {
                Console.WriteLine("Jutott be madszar a dontobe");
            }
            else
            {
                Console.WriteLine("Nem jutott be mdzsar");
            }
            //5es
            Console.WriteLine("Adjon meg egy nevet");
            string bekertnev = Console.ReadLine();
            bool vane = false;
            for (int i = 0; i < rovidlist.Count; i++)
            {
                if (rovidlist[i].Nev.ToLower() == bekertnev.ToLower())
                {
                    vane = true;
                }
            }
            if (vane == false)
            {
                Console.WriteLine("Nincs ilyen név");
            }
            else
            {
                Console.WriteLine("Jó név");
            }
            //6
            Console.WriteLine(OsszPontszam(bekertnev)+ " Pontszámot ért el összesen");

            //7
            List<string> orszagok = new List<string>();
            for (int i = 0; i < donto.Count; i++)
            {
                bool vote = false;
                for (int j = 0; j < orszagok.Count; j++)
                {
                    if (donto[i].Orszagkod == orszagok[j])
                    {
                        vote = true;
                    }
                }
                if (vote == false)
                {
                    orszagok.Add(donto[i].Orszagkod);
                }
            }
            int[] Segedtomb = new int[orszagok.Count];
            for (int i = 0; i < donto.Count; i++)
            {
                for (int j = 0; j < orszagok.Count; j++)
                {
                    if (orszagok[j] == donto[i].Orszagkod)
                    {
                        Segedtomb[j]++;
                    }
                }
            }
            for (int i = 0; i < Segedtomb.Length; i++)
            {
                if (Segedtomb[i] > 1)
                {
                    Console.WriteLine($"{orszagok[i]} : {Segedtomb[i]}");
                }
            }
            //8
            StreamWriter Iro = new StreamWriter("vegeredmeny.csv",false);
            List<Eredmeny> vegeredmeny = new List<Eredmeny>();
            for (int i = 0; i < donto.Count; i++)
            {
                vegeredmeny.Add(new Eredmeny(donto[i].Nev, donto[i].Orszagkod, OsszPontszam(donto[i].Nev)-donto[i].Hibapont));
            }
            List<Eredmeny> RendezettVegeredmeny = vegeredmeny.OrderByDescending(item => item.Osszpont).ToList();
            for (int i = 0; i < RendezettVegeredmeny.Count; i++)
            {
                Iro.WriteLine($"{i+1}. ; {RendezettVegeredmeny[i].Nev}; {RendezettVegeredmeny[i].Orszag}; {RendezettVegeredmeny[i].Osszpont}");
            }
            Iro.Close();





            
            Console.ReadKey();
        }





        public static double OsszPontszam(string nev)
        {
            double osszpont = 0;
            for (int i = 0; i < rovidlist.Count; i++)
            {
                if (rovidlist[i].Nev.ToLower() == nev.ToLower())
                {
                    osszpont += rovidlist[i].Technikaipont + rovidlist[i].Komponens;
                }
            }
            for (int i = 0; i < donto.Count; i++)
            {
                if (donto[i].Nev.ToLower() == nev.ToLower())
                {
                    osszpont += donto[i].Technikaipont + donto[i].Komponens;
                }
            }
            return osszpont;

        }
    }
}
