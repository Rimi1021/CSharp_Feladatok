using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace snooker
{
    class Snookerclass
    {
        public int helyezes;
        public string nev;
        public string orszag;
        public double nyeremeny;

        public Snookerclass(int hely, string nev, string orszag, double nyer) 
        {
            this.helyezes = hely;
            this.nev = nev;
            this.orszag = orszag;
            this.nyeremeny = nyer;
        }
    }
    class Program 
    {
        static void Main(string[] args)
        {
            List<Snookerclass> snookerlista = new List<Snookerclass>();
            StreamReader Olvas = new StreamReader("snooker.txt",Encoding.UTF8);
            string fejlec = Olvas.ReadLine();
            while (!Olvas.EndOfStream)
            {
                string sor = Olvas.ReadLine();
                string[] sorelem = sor.Split(';');
                snookerlista.Add(new Snookerclass(Convert.ToInt32(sorelem[0]), sorelem[1], sorelem[2], Convert.ToDouble(sorelem[3])));
            }
            Olvas.Close();
            
            //2.
            Console.WriteLine("3.feladat");
            Console.WriteLine(snookerlista.Count);

            
            //3
            Console.WriteLine("4.feladat");
            double db = 0;
            double ossz = 0;
            for (int i = 0; i < snookerlista.Count; i++)
            {
                ossz += snookerlista[i].nyeremeny;
                db++; 
            }
            double atlag = Math.Round(ossz / db,2);
            Console.WriteLine("A nyeremények atlaga: "+atlag);
           
            
            //5
            Console.WriteLine("5.feladat");
            int kinaiindex = 0;
            double legnagyobbkinainyeremeny = 0;
            for (int i = 0; i < snookerlista.Count; i++)
            {
                if (snookerlista[i].orszag.Contains("Kína"))
                {
                    if (snookerlista[i].nyeremeny > legnagyobbkinainyeremeny)
                    {
                        legnagyobbkinainyeremeny = snookerlista[i].nyeremeny;
                        kinaiindex = i;
                    }
                }
            }
            Console.WriteLine("\t Helyezés "+snookerlista[kinaiindex].helyezes);
            Console.WriteLine("\tA legnagyobb nyereménnyel rendelkező kina: "+ snookerlista[kinaiindex].nev+"  "+snookerlista[kinaiindex].nyeremeny*380+" Ft");


            //6
            bool vanenorveg = false;
            for (int i = 0; i < snookerlista.Count; i++)
            {
                if (snookerlista[i].orszag.Contains("Norv"))
                {
                    vanenorveg = true;
                }
            }
            if (vanenorveg == true)
            {
                Console.WriteLine("Van norveg");
            }
            else
            {
                Console.WriteLine("Nincs norveg");
            }
            

            //7
            Console.WriteLine("7.feladat");
            //8.Feladat
            /*Console.WriteLine("8.Feladat");
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
            }*/

            List<string> orszagok = new List<string>();
            for (int i = 0; i < snookerlista.Count; i++)
            {
                bool vane = false;
                for (int j = 0; j < orszagok.Count; j++)
                {
                    if (snookerlista[i].orszag == orszagok[j])
                    {
                        vane = true;
                    }
                }
                if (vane == false)
                {
                    orszagok.Add(snookerlista[i].orszag);
                }

            }

            int[] Segedtomb = new int[orszagok.Count];
            for (int i = 0; i < snookerlista.Count; i++)
            {
                for (int j = 0; j < orszagok.Count; j++)
                {
                    if (snookerlista[i].orszag == orszagok[j])
                    {
                        Segedtomb[j]++;
                    }
                }
                
            }
            for (int i = 0; i < Segedtomb.Length; i++)
            {
                if (Segedtomb[i] > 4)
                {
                    Console.WriteLine($"\t{orszagok[i]} {Segedtomb[i]}");
                }
            }


            Console.ReadLine();
        }
    }
}
