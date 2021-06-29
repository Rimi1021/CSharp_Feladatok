using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace hegy
{
    class hegy2 
    {
        public string nev;
        public string varos;
        public string orszag;
        public double magassag;
        public int emelet;
        public int epult;

        public hegy2(string sor) 
        {
            string[] Sorelem = sor.Split(';');
            this.nev = Sorelem[0];
            this.varos = Sorelem[1];
            this.orszag = Sorelem[2];
            this.magassag = Convert.ToDouble(Sorelem[3]);
            this.emelet = Convert.ToInt32(Sorelem[4]);
            this.epult = Convert.ToInt32(Sorelem[5]);
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            StreamReader olvas = new StreamReader("legmagasabb.txt",Encoding.Default);
            List<hegy2> hegyek = new List<hegy2>();
            string fejlec = olvas.ReadLine();
            while (!olvas.EndOfStream)
            {
                string Sor = olvas.ReadLine();
                hegyek.Add(new hegy2(Sor));
            }
            olvas.Close();

            //3as
            Console.WriteLine(hegyek.Count);
            //4es
            double osszemelet = 0;
            for (int i = 0; i < hegyek.Count; i++)
            {
                osszemelet += hegyek[i].emelet;
            }
            Console.WriteLine($"Összemelet = {osszemelet}m");
            //5os
            double legmagasabb = 0;
            int index = 0;
            for (int i = 0; i < hegyek.Count; i++)
            {
                if (hegyek[i].magassag > legmagasabb)
                {
                    index = i;
                    legmagasabb = hegyek[i].magassag; 
                }
            }
            Console.WriteLine($"A legmagasabb hegy adatai: {hegyek[index].nev}, {hegyek[index].orszag},{hegyek[index].varos}, {hegyek[index].magassag}, {hegyek[index].epult}");

            //6os
            bool vaneolasz = false;
            int indexnovelo = 0;
            while (vaneolasz != true)
            {
                if (hegyek[indexnovelo].orszag == "Olaszország")
                {
                    vaneolasz = true;
                }
                indexnovelo++;
            }
            if (vaneolasz == true)
            {
                Console.WriteLine("Van olasz");
            }
            else
            {
                Console.WriteLine("nincs");
            }
            //7es
            double labnelmagasabb = 3.280839895;
            int db = 0;
            for (int i = 0; i < hegyek.Count; i++)
            {
                if (hegyek[i].magassag * labnelmagasabb > 666)
                {
                    db++;
                }
            }
            Console.WriteLine($"666 magasabb epuletek száma {db}");
            //8-as
            List<string> Orszagnevek = new List<string>();
            for (int i = 0; i < hegyek.Count; i++)
            {
                bool volte = false;
                for (int j = 0; j < Orszagnevek.Count; j++)
                {
                    if (hegyek[i].orszag == Orszagnevek[j])
                    {
                        volte = true;
                    }
                }
                if (volte == false)
                {
                    Orszagnevek.Add(hegyek[i].orszag);
                }
            }
            int[] Segedtomb = new int[Orszagnevek.Count];
            for (int i = 0; i < hegyek.Count; i++)
            {
                for (int j = 0; j < Orszagnevek.Count; j++)
                {
                    if (hegyek[i].orszag == Orszagnevek[j])
                    {
                        Segedtomb[j]++;
                    }
                }
            }
            for (int i = 0; i < Orszagnevek.Count; i++)
            {
                Console.WriteLine($"\t {Orszagnevek[i]} : {Segedtomb[i]}");
            }
            //9es
            List<string> NemetVarosok = new List<string>();
            for (int i = 0; i < hegyek.Count; i++)
            {
                if (hegyek[i].orszag == "Németország")
                {
                    bool vane = false;
                    for (int j = 0; j < NemetVarosok.Count; j++)
                    {
                        if (hegyek[i].varos == NemetVarosok[j])
                        {
                            vane = true;
                        }
                    }
                    if (vane == false)
                    {
                        NemetVarosok.Add(hegyek[i].varos);
                    }
                }
            }
            StreamWriter Iro = new StreamWriter("nemet.txt",false,Encoding.Default);
            for (int i = 0; i < NemetVarosok.Count; i++)
            {
                Iro.WriteLine(NemetVarosok[i]);
            }
            Iro.Close();
            Console.ReadLine();
        }
        
    }
}
