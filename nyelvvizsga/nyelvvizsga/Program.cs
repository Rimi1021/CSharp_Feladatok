using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
namespace nyelvvizsga
{
    class SikeresEvek 
    {
        public string Nyelv;
        public int Ketezerkilenc;
        public int Ketezertiz;
        public int Ketezertizenegy;
        public int Ketezertizenketto;
        public int Ketezertizenharom;
        public int Ketezertizennegy;
        public int Ketezertizenot;
        public int Ketezertizenhat;
        public int Ketezertizenhet;
        public int Ketezertizennyolc;

        public SikeresEvek(string Adatsor) 
        {
            string[] sorelem = Adatsor.Split(';');
            Nyelv = sorelem[0];
            Ketezerkilenc =Convert.ToInt32(sorelem[1]);
            Ketezertiz=Convert.ToInt32(sorelem[2]);
            Ketezertizenegy=Convert.ToInt32(sorelem[3]);
            Ketezertizenketto = Convert.ToInt32(sorelem[4]); ;
            Ketezertizenharom = Convert.ToInt32(sorelem[5]); ;
            Ketezertizennegy = Convert.ToInt32(sorelem[6]); ;
            Ketezertizenot = Convert.ToInt32(sorelem[7]); ;
            Ketezertizenhat = Convert.ToInt32(sorelem[8]); ;
            Ketezertizenhet = Convert.ToInt32(sorelem[9]); ;
            Ketezertizennyolc = Convert.ToInt32(sorelem[10]); ;
        }
    }

    class SikertelenEvek 
    {
        public string Nyelv;
        public int Ketezerkilenc;
        public int Ketezertiz;
        public int Ketezertizenegy;
        public int Ketezertizenketto;
        public int Ketezertizenharom;
        public int Ketezertizennegy;
        public int Ketezertizenot;
        public int Ketezertizenhat;
        public int Ketezertizenhet;
        public int Ketezertizennyolc;

        public SikertelenEvek(string Adatsor)
        {
            string[] sorelem = Adatsor.Split(';');
            Nyelv = sorelem[0];
            Ketezerkilenc = Convert.ToInt32(sorelem[1]);
            Ketezertiz = Convert.ToInt32(sorelem[2]);
            Ketezertizenegy = Convert.ToInt32(sorelem[3]);
            Ketezertizenketto = Convert.ToInt32(sorelem[4]); ;
            Ketezertizenharom = Convert.ToInt32(sorelem[5]); ;
            Ketezertizennegy = Convert.ToInt32(sorelem[6]); ;
            Ketezertizenot = Convert.ToInt32(sorelem[7]); ;
            Ketezertizenhat = Convert.ToInt32(sorelem[8]); ;
            Ketezertizenhet = Convert.ToInt32(sorelem[9]); ;
            Ketezertizennyolc = Convert.ToInt32(sorelem[10]); ;
        }
    }
    class Program
    {
        public static List<SikeresEvek> Sikeres = new List<SikeresEvek>();
        public static List<SikertelenEvek> Sikertelen = new List<SikertelenEvek>();
        static void Main(string[] args)
        {
            ///////////////////////////////////////////////////////////////////////////////Beolvasas
            StreamReader SikeresOlvas = new StreamReader("Sikeres.csv",Encoding.Default);
            while (!SikeresOlvas.EndOfStream)
            {
                Sikeres.Add(new SikeresEvek(SikeresOlvas.ReadLine()));
            }
            SikeresOlvas.Close();

            StreamReader SikertelenOlvas = new StreamReader("Sikeres.csv", Encoding.Default);
            while (!SikertelenOlvas.EndOfStream)
            {
                Sikertelen.Add(new SikertelenEvek(SikertelenOlvas.ReadLine()));
            }
            SikertelenOlvas.Close();
            ////////////////////////////////////////////////////////////////////////////
            List<int> Elsoharom = new List<int>();
            int ketezerklcn = 0;
            int ketezertiz = 0;
            int ketezertizngy = 0;
            int ketezertzketto = 0;
            int ketezrtznhrm = 0;
            int ketzrtiznngy = 0;
            int ketzrtznot = 0;
            int ketezrtznhat = 0;
            int ketzrtznhet = 0;
            int ketzrtizennyolc = 0;
            for (int i = 0; i < Sikeres.Count; i++)
            {
                ketezerklcn += Sikeres[i].Ketezerkilenc;
                ketezertiz += Sikeres[i].Ketezertiz;
                ketezertizngy += Sikeres[i].Ketezertizenegy;
                ketezertzketto += Sikeres[i].Ketezertizenketto;
                ketzrtiznngy += Sikeres[i].Ketezertizenharom;
                ketezrtznhrm += Sikeres[i].Ketezertizenegy;
                ketzrtznot += Sikeres[i].Ketezertizenot;
                ketezrtznhat += Sikeres[i].Ketezertizenhat;
                ketzrtznhet += Sikeres[i].Ketezertizenhet;
                ketzrtizennyolc += Sikeres[i].Ketezertizennyolc;
            }

            Elsoharom.Add(ketezerklcn);
            Console.ReadLine();
        }
    }
}
