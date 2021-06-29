using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fuvar
{
    class Fuvarosztaly 
    {
        public int taxiazonosito;
        public string indulasido;
        public int utazasidotartalma;
        public double megtetttavolsag;
        public double viteldij;
        public double borravalo;
        public string fizetesimod;

        public Fuvarosztaly(int taxiid, string indulas, int utazasido, double megtetttavolsa, double viteldj, double borra, string ffizetesmod) 
        {
            taxiazonosito = taxiid;
            indulasido = indulas;
            utazasidotartalma = utazasido;
            megtetttavolsag = megtetttavolsa;
            viteldij = viteldj;
            borravalo = borra;
            fizetesimod = ffizetesmod;
        }

    }
    class Program
    {
        static void Main(string[] args)
        {

            StreamReader Olvas = new StreamReader("fuvar.csv",Encoding.Default);
            string fjlc = Olvas.ReadLine();
            List<Fuvarosztaly> fuvar = new List<Fuvarosztaly>();
            while (!Olvas.EndOfStream)
            {
                string sor = Olvas.ReadLine();
                string[] sorelem = sor.Split(';');
                fuvar.Add(new Fuvarosztaly(Convert.ToInt32(sorelem[0]), sorelem[1], Convert.ToInt32(sorelem[2]), Convert.ToDouble(sorelem[3]), Convert.ToDouble(sorelem[4]), Convert.ToDouble(sorelem[5]), sorelem[6]));
            }
            Olvas.Close();
            //3as
            Console.WriteLine("3. feladat");
            Console.WriteLine($"{fuvar.Count} utazás volt" );

            //4as
            Console.WriteLine("4. feladat");
            double bevetel = 0;
            int db = 0;
            for (int i = 0; i < fuvar.Count; i++)
            {
                if (fuvar[i].taxiazonosito == 6185)
                {
                    bevetel += fuvar[i].viteldij + fuvar[i].borravalo;
                    db++;
                }
            }
            Console.WriteLine($"A 6185 számu fuvarosnak {db} fuvarból {bevetel} dollár bevétele volt");
            
            
            //5as
            Console.WriteLine("5. feladat");
            List<string> fizeteslista = new List<string>();
            for (int i = 0; i < fuvar.Count; i++)
            {
                bool vote = false;
                for (int j = 0; j < fizeteslista.Count; j++)
                {
                    if (fizeteslista[j] == fuvar[i].fizetesimod)
                    {
                        vote = true;
                    }
                }
                if (vote == false)
                {
                    fizeteslista.Add(fuvar[i].fizetesimod);
                }
            }
            int[] fizuszamlalo = new int[fizeteslista.Count];
            for (int i = 0; i < fuvar.Count; i++)
            {
                for (int j = 0; j < fizeteslista.Count; j++)
                {
                    if (fizeteslista[j] == fuvar[i].fizetesimod)
                    {
                        fizuszamlalo[j]++;
                    }
                }
            }
            for (int i = 0; i < fizeteslista.Count; i++)
            {
                Console.WriteLine($"\t{fizeteslista[i]} {fizuszamlalo[i]}db");
            }
            //6as
            Console.WriteLine("6. feladat");
            double osszkm = 0;
            for (int i = 0; i < fuvar.Count; i++)
            {
                osszkm += fuvar[i].megtetttavolsag;
            }
            Console.WriteLine($"Összesen {osszkm*1,6} Km-ert tettek mög");

            //7as
            Console.WriteLine("7. feladat");
            double nagy = 0;
            for (int i = 0; i < fuvar.Count; i++)
            {
                if (fuvar[i].utazasidotartalma > nagy)
                {
                    nagy = i;
                }
            }
            Console.WriteLine($"{nagy} mp vlt a legtobb ido");

            //8as
            Console.WriteLine("8. feladat");
            StreamWriter Iro = new StreamWriter("hibak.txt",false,Encoding.UTF8);
            List<Fuvarosztaly> hibaslista = fuvar.OrderByDescending(item => item.indulasido).ToList();
            Iro.WriteLine(fjlc);
            for (int i = 0; i < fuvar.Count; i++)
            {
                if (fuvar[i].utazasidotartalma > 0 && fuvar[i].viteldij > 0 && fuvar[i].megtetttavolsag == 0)
                {
                    Iro.WriteLine($"{fuvar[i].taxiazonosito}, {fuvar[i].indulasido}; {fuvar[i].utazasidotartalma}, {fuvar[i].megtetttavolsag}; {fuvar[i].viteldij}; {fuvar[i].borravalo}; {fuvar[i].fizetesimod}");
                }
            }
            Iro.Close();
           
            
            Console.ReadLine();
        }
    }
}
