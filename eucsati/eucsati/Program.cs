using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eucsati
{
    class EU 
    {
        public string Orszag;
        public string Csatlakozas;

        public EU(string orsz, string csati) 
        {
            Orszag = orsz;
            Csatlakozas = csati;
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            StreamReader Olvas = new StreamReader("EUcsatlakozas.txt",Encoding.Default);
            List<EU> eu = new List<EU>();
            while (!Olvas.EndOfStream)
            {
                string sor = Olvas.ReadLine();
                string[] sorelem = sor.Split(';');
                eu.Add(new EU(sorelem[0], sorelem[1]));
            }
            Olvas.Close();

            
            //3as
            Console.WriteLine("3.Feladat");
            Console.WriteLine(eu.Count+" tagállama volt 2018-ban az eunak");

            //4es
            Console.WriteLine("4.Feladat");
            int db = 0;
            for (int i = 0; i < eu.Count; i++)
            {
                if (eu[i].Csatlakozas.Contains("2007"))
                {
                    db++;
                }
            }
            Console.WriteLine($"{db} állam csatlakozott 2007-ben");

            //5os
            Console.WriteLine("5.Feladat");
            for (int i = 0; i < eu.Count; i++)
            {
                if (eu[i].Orszag.Contains("Magyarország"))
                {
                    Console.WriteLine($"Magyarország {eu[i].Csatlakozas}-én csatlakozottt");
                }
            }
            //6os
            Console.WriteLine("6.Feladat");
            bool vot = false;
            for (int i = 0; i < eu.Count; i++)
            {
                if (eu[i].Csatlakozas.Contains(".05."))
                {
                    vot = true;
                }
            }
            if (vot==true)
            {
                Console.WriteLine("vot");
            }
            else
            {
                Console.WriteLine(" nem vot");
            }

            //7es
            Console.WriteLine("7.Feladat");
            int legnagyobb = 0;
            int index = 0;
            for (int i = 0; i < eu.Count; i++)
            {
                if (legnagyobb < Convert.ToInt32(eu[i].Csatlakozas.Substring(0,4)))
                {
                    legnagyobb = Convert.ToInt32(eu[i].Csatlakozas.Substring(0, 4));
                    index = i;
                }
            }
            Console.WriteLine($"{eu[index].Orszag} csatlakozott utoljára");

           

            //8as
            Console.WriteLine("8.Feladat");
            List<int> evdatum = new List<int>();
            for (int i = 0; i < eu.Count; i++)
            {
                bool vote = false;
                for (int j = 0; j < evdatum.Count; j++)
                {
                    if (evdatum[j] == Convert.ToInt32(eu[i].Csatlakozas.Substring(0,4)))
                    {
                        vote = true;
                    }
                }
                if (vote == false)
                {
                    evdatum.Add(Convert.ToInt32(eu[i].Csatlakozas.Substring(0, 4)));
                }
            }
            //segedtomb
            int[] tomb = new int[evdatum.Count];
            for (int i = 0; i < eu.Count; i++)
            {
                for (int j = 0; j < evdatum.Count; j++)
                {
                    if (evdatum[j] == Convert.ToInt32(eu[i].Csatlakozas.Substring(0, 4)))
                    {
                        tomb[j]++;
                    }
                }
            }
            for (int i = 0; i < tomb.Length; i++)
            {
                Console.WriteLine("\t"+evdatum[i]+": "+ tomb[i]);
            }


            Console.ReadKey();
        }
    }
}
