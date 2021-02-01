using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace akasztófa
{
    class Program
    {
        static void Main(string[] args)
        {
            FileStream fs = new FileStream("szavak.txt",FileMode.Open);
            StreamReader sr = new StreamReader(fs);
            List<String> lista = new List<string>();

            Random r = new Random();

            while (!sr.EndOfStream)
            {
             lista.Add(sr.ReadLine());
            }
            int a=r.Next(0, lista.Count);
            string szo = "";
            string allas = "";
            string ideiglenes = "";
            for (int i = 0; i < lista.Count; i++)
            {
                szo = lista[a];
                break;
            }
            for (int i = 0; i < szo.Length; i++)
            {
                allas += "_";
            }

            bool ingame = true;
            Console.WriteLine(allas);
            int proba = 0;
            while (ingame==true)
            {
                Console.WriteLine("Választott betű: ");
                char betu = Console.ReadKey().KeyChar;
                proba++;
                for (int i = 0; i < szo.Length; i++)
                {
                    if (betu==szo[i])
                    {
                        ideiglenes += szo[i];
                    }
                    else
                    {
                        ideiglenes += allas[i];
                    }
                }
                allas = ideiglenes;
                ideiglenes = "";
                if (allas.Contains("_"))
                {
                   Console.WriteLine("\n"+allas+ "(próbálkozások száma: {0})",proba);
                    int gf = szo.Length+5;
                    if (proba>=gf)
                    {
                        Console.WriteLine("\nVesztettél! Elég ramatyul játszol! Kéne egy kis gyakorlás még!");
                        ingame = false;
                    }
                }
                else
                {
                    Console.WriteLine("\nNyertél! A szó a/az {0} volt!", szo);
                    ingame = false;
                }
            }




            Console.ReadKey();
        }
    }
}
