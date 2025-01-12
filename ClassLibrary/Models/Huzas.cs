using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibrary.Models
{
    public class Huzas
    {
        public int Id { get; set; }
        public int Szam1 {  get; set; }
        public int Szam2 {  get; set; }
        public int Szam3 {  get; set; }
        public int Szam4 {  get; set; }
        public int Szam5 {  get; set; }
        public int Szam6 { get; set; }

        public Huzas()
        {
        }
        public Huzas(string sor)
        {
            string[] adatok = sor.Split(';');
            if (adatok.Length == 6)
            {
                int[] szamok = new int[6];
                for (int i = 0; i < 6; i++)
                {
                    try {
                        szamok[i]=int.Parse(adatok[i]);
                    }
                    catch (Exception) {
                        throw new ArgumentException("Line error", "sor");
                    }
                    if (szamok[i]<1 || szamok[i]>48 )
                        throw new ArgumentException("Line error", "sor");
                }
                HashSet<int> halmaz= new HashSet<int>(szamok);
                if (halmaz.Count()!=6) throw new ArgumentException("Line error", "sor");
                Szam1 = szamok[0];
                Szam2 = szamok[1];
                Szam3 = szamok[2];
                Szam4 = szamok[3];
                Szam5 = szamok[4];
                Szam6 = szamok[5];
            }
            else {
                throw new ArgumentException("Line error","sor");
            }
        }

        public override string? ToString()
        {
            return $"{Szam1}, {Szam2}, {Szam3}, {Szam4}, {Szam5}, {Szam6}";
        }
    }
}
