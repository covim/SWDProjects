using System;

namespace Wochentage
{
    internal class Program
    {
        static void Main(string[] args)
        {
            double eingabeTag;
            double eingabeMonat;
            double eingabeJahr;
            double jahrhunderte;
            double zehnerjahre;

            int ausgabetag;



            //Console.Write("Bitte Tag eingeben 1-31: ");
            //eingabeTag = double.Parse(Console.ReadLine());

            //Console.Write("Bitte Monat eingeben 1-12: ");
            //eingabeMonat = double.Parse(Console.ReadLine());

            //Console.Write("Bitte Jahr eingeben: ");
            //eingabeJahr = double.Parse(Console.ReadLine());





            Console.WriteLine((DayOfWeek)WochentagsFormel(25, 12, 1983));
            Console.WriteLine((DayOfWeek)WochentagsFormel(5, 3, 2023));

            Console.WriteLine((DayOfWeek)WochentagsFormel(31, 12, 2022));
            Console.WriteLine((DayOfWeek)WochentagsFormel(1, 1, 2023));







        }

        public static int WochentagsFormel(int Tag, int Monat, int Jahr)
        {
            double wochentag;
            double monat;
            int jahr;
            double jahrhunderte;
            double zehnerjahre;

            monat = (Monat + 10) % 12;

            if (monat == 11 || monat == 12)
            {
                jahr = Jahr-1;
            }
            else { jahr = Jahr; }

            jahrhunderte = (Math.Floor(((double)jahr / 100)));
            zehnerjahre = jahr % 100;


            wochentag = (Tag + (int)(2.6 * monat - 0.2) + zehnerjahre + (int)(zehnerjahre / 4.0) + (int)(jahrhunderte / 4.0) - 2.0 * jahrhunderte) % 7.0;

            return (int)wochentag;
        }
    }
}