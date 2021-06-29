using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace Fifa
{
    class Program
    {
        static void Main(string[] args)
        {
            List<string> Csapat = new List<string>();
            List<int> Helyezes = new List<int>();
            List<int> Valtozas = new List<int>();
            List<int> Pontszam = new List<int>();

            StreamReader Olvas = new StreamReader("fifa.txt",Encoding.Default);
            string Fejlec = Olvas.ReadLine();

            while (!Olvas.EndOfStream)
            {
                string sor = Olvas.ReadLine();
                string[] SorElemek = sor.Split(';');
                Csapat.Add(SorElemek[0]);
                Helyezes.Add(Convert.ToInt32(SorElemek[1]));
                Valtozas.Add(Convert.ToInt32(SorElemek[2]));
                Pontszam.Add(Convert.ToInt32(SorElemek[3]));
            }
            Olvas.Close();

            //3
            Console.WriteLine("3. Feladat");
            Console.WriteLine($"{Csapat.Count} Csapat Szerepel.");
            //4
            Console.WriteLine("3. Feladat");
            double Osszeg = 0;
            for (int i = 0; i < Pontszam.Count; i++)
            {
                Osszeg = Pontszam[i] + Osszeg;
            }
            Console.WriteLine($"{Math.Round(Osszeg/Pontszam.Count,2)}");
            //5
            Console.WriteLine("5. Feladat");
            int MaximumIndex = 0;
            for (int i = 0; i < Valtozas.Count; i++)
            {
                if (Valtozas[MaximumIndex] < Valtozas[i])
                {
                    MaximumIndex = i;
                }
            }
            Console.WriteLine($"\t{Csapat[MaximumIndex]}");
            Console.WriteLine($"\t{Helyezes[MaximumIndex]}");
            Console.WriteLine($"\t{Pontszam[MaximumIndex]}");
            //6
            Console.WriteLine("6.Feladat");
            bool Madzsar = false;
            for (int i = 0; i < Csapat.Count; i++)
            {
                if (Csapat[i].Contains("Magyarország"))
                {
                    Madzsar = true;
                }
               
            }
            if (Madzsar == true)
            {
                Console.WriteLine("Van Magyar Csapat");
            }
            else
            {
                Console.WriteLine("Nincs Mahar sapat");
            }
            //7
            List<int> ValtozasLista = new List<int>();
            for (int i = 0; i < Valtozas.Count; i++)
            {
                bool SzerepelE = false;
                for (int j = 0; j < ValtozasLista.Count; j++)
                {
                    if (Valtozas[i]==ValtozasLista[j])
                    {
                        SzerepelE = true;
                    }
                }
                if (SzerepelE == false)
                {
                    ValtozasLista.Add(Valtozas[i]);
                }
            }
            int[] ValtozasSeged = new int[ValtozasLista.Count];
            for (int i = 0; i < Valtozas.Count; i++)
            {
                for (int j = 0; j < ValtozasLista.Count; j++)
                {
                    if (Valtozas[i] == ValtozasLista[j])
                    {
                        ValtozasSeged[j]++;
                    }
                }
            }
            for (int i = 0; i < ValtozasLista.Count; i++)
            {
                if (ValtozasSeged[i] > 1)
                {
                    Console.WriteLine($"\t{ValtozasLista[i]} Helyet valtott {ValtozasSeged[i]} csapat");
                }
            }
            Console.ReadLine();

        }
    }
}
