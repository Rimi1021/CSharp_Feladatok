using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace EU
{
    class EU 
    {
        public string Orszagok;
        public string Datum;

        public EU(string orszag, string datum)
        {
            Orszagok = orszag;
            Datum = datum;
        }
    }
   
    class Program
    {
        static void Main(string[] args)
        {
            StreamReader Olvas = new StreamReader("EUcsatlakozas.txt",Encoding.Default);
            List<EU> Csati = new List<EU>();

            while (!Olvas.EndOfStream)
            {
                string Sor = Olvas.ReadLine();
                string[] SorElemek = Sor.Split(';');
                Csati.Add(new EU( SorElemek[0], SorElemek[1]));
            }
            Olvas.Close();
            //3.Feladat
            Console.WriteLine("3.Feladat");
            Console.WriteLine(Csati.Count+ "Tagállama volt az EU-nak 2018 ig");

            //4.Feladat
            Console.WriteLine("4.Feladat");
            int osszes = 0;
            for (int i = 0; i < Csati.Count; i++)
            {
                if (Csati[i].Datum.Contains("2007."))
                {
                    osszes++;
                }
            }
            Console.WriteLine(osszes + " Ország csatlakozott 2017-ben");

            //5.Feladat
            Console.WriteLine("5.Feladat");
            for (int i = 0; i < Csati.Count; i++)
            {
                if (Csati[i].Orszagok.Contains("Magyarország"))
                {
                    Console.WriteLine($"Magyarország Csatlakozási dátuma {Csati[i].Datum}");
                }
            }
            //6.Feladat
            Console.WriteLine("6.Feladat");
            bool volt = false;
            for (int i = 0; i < Csati.Count; i++)
            {
                if (Csati[i].Datum.Contains(".05."))
                {
                    volt = true;
                }
            }
            if (volt == false)
            {
                Console.WriteLine("Nem volt csatlakozas majusban");
            }
            else
            {
                Console.WriteLine("Volt csatlakozás majusban");
            }
            //7.Feladat

            int Utccso = 0;
            int Legnagyobb = 0;
            for (int i = 0; i < Csati.Count; i++)
            {
                int Aktev = Convert.ToInt32(Csati[i].Datum.Substring(0,4));
                if (Aktev > Legnagyobb)
                {
                    Legnagyobb = Aktev;
                    Utccso = i;
                }
            }
            Console.WriteLine($" Utoljára csatlakozott { Csati[Utccso].Orszagok} { Csati[Utccso].Datum}-ban");
            //8.feladat
            List<int> ListaPista = new List<int>();
            for (int i = 0; i < Csati.Count; i++)
            {
                int aktev = Convert.ToInt32(Csati[i].Datum.Substring(0,4));
                bool Vuute = false;
                for (int j = 0; j < ListaPista.Count; j++)
                {
                    if (ListaPista[j] == aktev)
                    {
                        Vuute = true;
                    }
                }
                if (Vuute == false)
                {
                    ListaPista.Add(aktev);
                }
            }
            int[] Segedlista = new int[ListaPista.Count];
            for (int i = 0; i < Csati.Count; i++)
            {
                int aktev = Convert.ToInt32(Csati[i].Datum.Substring(0, 4));
                for (int j = 0; j < ListaPista.Count; j++)
                {
                    if (ListaPista[j] == aktev)
                    {
                        Segedlista[j]++;
                    }
                }
            }
            for (int i = 0; i < ListaPista.Count; i++)
            {
                Console.WriteLine($"{ListaPista[i]} - {Segedlista[i]} ország");
            }
            





            Console.ReadLine();
        }
    }
}
