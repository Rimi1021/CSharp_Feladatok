using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace Telekcsi
{
     class Auto 
     {
         public string Indulas;
         public string Cel;
         public string Rendszam;
         public string Telefonszam;
         public int Ferohely;

        public Auto(string indulas, string cel,string rendszam, string teloszam, int ferohely) 
         {
             Indulas = indulas;
             Cel = cel;
             Rendszam = rendszam;
             Telefonszam = teloszam;
             Ferohely = ferohely;
         }

         public Auto(string Adatsor)
         {
            string[] Sorelemek = Adatsor.Split(';');
            this.Indulas = Sorelemek[0];
            this.Cel = Sorelemek[1];
            this.Rendszam = Sorelemek[2];
            this.Telefonszam = Sorelemek[3];
            this.Ferohely = Convert.ToInt32(Sorelemek[4]);
        }

     }

    class Utvonalak 
    {
        public string Indulas;
        public string Cel;
        public int Ferohely;
        public Utvonalak(string indulas, string cel) 
        {
            Indulas = indulas;
            Cel = cel;
            Ferohely = 0;
        }
    }

     class Igenyek 
     {
         public string Azonosito;
         public string Indulas;
         public string Cel;
         public int Szemelyek;

         public Igenyek(string Adatsor) 
         {
            string[] SorElem = Adatsor.Split(';');
             Azonosito = SorElem[0];
             Indulas = SorElem[1];
             Cel = SorElem[2];
             Szemelyek= Convert.ToInt32(SorElem[3]);
         }
     }
    class Program
    {
        public static List<Auto> Hirdetok = new List<Auto>();
        public static List<Igenyek> Igeny = new List<Igenyek>();
        static void Main(string[] args)
        {

            StreamReader AutoOlvas = new StreamReader("autok.csv",Encoding.Default);
            string fejlec = AutoOlvas.ReadLine();
            while (!AutoOlvas.EndOfStream)
            {
                Hirdetok.Add(new Auto(AutoOlvas.ReadLine()));
            }
            AutoOlvas.Close();

            //////
            ///
            Console.WriteLine($"{Hirdetok.Count}");
            ///
            int BPMiskolc = 0;
            for (int i = 0; i < Hirdetok.Count; i++)
            {
                if (Hirdetok[i].Indulas == "Budapest" && Hirdetok[i].Cel == "Miskolc")
                {
                    BPMiskolc += Hirdetok[i].Ferohely;
                }
            }
            Console.WriteLine($"BPMiskolc ferohelyek szama {BPMiskolc}");
            ///4-es
            Console.WriteLine("4.Feladat");
            List<Utvonalak> Utvonallista = new List<Utvonalak>();
            for (int i = 0; i < Hirdetok.Count; i++)
            {
                bool szerepele = false;
                for (int j = 0; j < Utvonallista.Count; j++)
                {
                    if (Hirdetok[i].Indulas == Utvonallista[j].Indulas && Hirdetok[i].Cel == Utvonallista[j].Cel)
                    {
                        szerepele = true;
                    }
                }
                if (szerepele == false)
                {
                    Utvonallista.Add(new Utvonalak(Hirdetok[i].Indulas, Hirdetok[i].Cel ));
                }
            }

            for (int i = 0; i < Hirdetok.Count; i++)
            {
                for (int j = 0; j < Utvonallista.Count; j++)
                {
                    if (Hirdetok[i].Indulas == Utvonallista[j].Indulas && Hirdetok[i].Cel == Utvonallista[j].Cel)
                    {
                        Utvonallista[j].Ferohely += Hirdetok[i].Ferohely;
                    }
                }
            }
            List<Utvonalak> Rendezettlista = Utvonallista.OrderByDescending(Item => Item.Ferohely).ToList();
            // Utvonallista.IndexOf(Utvonallista.Max()); -- Ez is jóó
            Console.WriteLine($"A legtobb ferohelyet ({Rendezettlista[0].Ferohely}) a {Rendezettlista[0].Indulas}-{Rendezettlista[0].Cel} volt  ");
            //5os
            StreamReader IgenyOlvas = new StreamReader("igenyek.csv", Encoding.Default);
            string fejlec2 = IgenyOlvas.ReadLine();
            while (!IgenyOlvas.EndOfStream)
            {
                Igeny.Add(new Igenyek(IgenyOlvas.ReadLine()));
            }
            AutoOlvas.Close();
            int szam = 0;
            for (int i = 0; i < Igeny.Count; i++)
            {
                for (int j = 0; j < Hirdetok.Count; j++)
                {
                    if (Hirdetok[j].Indulas == Igeny[i].Indulas && Hirdetok[j].Cel == Igeny[i].Cel && Hirdetok[j].Ferohely >= Igeny[i].Szemelyek)
                    {
                        szam++;
                        Console.WriteLine($"{Igeny[i].Azonosito} => {Hirdetok[j].Rendszam} {szam}.");
                        Hirdetok[j].Ferohely -= Igeny[i].Szemelyek;
                    }
                }
            }
            //6
            StreamWriter Iro = new StreamWriter("Makika.csv",false,Encoding.Default);
            for (int i = 0; i < Igeny.Count; i++)
            {
                bool vanefuvar = false;
                int indexer = 0;
                for (int j = 0; j < Hirdetok.Count; j++)
                {
                    if (Hirdetok[j].Indulas == Igeny[i].Indulas && Hirdetok[j].Cel == Igeny[i].Cel && Hirdetok[j].Ferohely >= Igeny[i].Szemelyek)
                    {
                        vanefuvar = true;
                        indexer = i;
                    }
                }
                if (vanefuvar == true)
                {
                    Iro.WriteLine($"{Igeny[i].Azonosito} => {Hirdetok[indexer].Telefonszam}, {Hirdetok[indexer].Rendszam}");
                    Hirdetok[indexer].Ferohely -= Igeny[i].Szemelyek;
                }
                else
                {
                    Iro.WriteLine($"Nem sikerül kocsit talalni");
                }
            }
            Iro.Close();


            Console.ReadLine();
        }
    }
}
