using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Humanizer;
using System.Drawing;
using Console = Colorful.Console;
using CsvHelper;

namespace NuGetTest
{
    internal class Program
    {
        public enum Enum
        {
            pomme,
            banane,
            citron,
            steak
        }

        static void Main(string[] args)
        {
            TestHumain();
            TestConsole();

            string[] words = { "the", "quick", "brown", "fox", "jumps" };

            Console.ReadLine();
        }



        public static void TestHumain()
        {
            Enum test = Enum.pomme;


            Console.WriteLine(1034.ToRoman());
            Console.WriteLine(test.Humanize());
            Console.WriteLine(TimeSpan.FromMinutes(365));
            Console.WriteLine(TimeSpan.FromSeconds(222222222).Humanize(9, maxUnit: Humanizer.Localisation.TimeUnit.Year));
            Console.WriteLine(TimeSpan.FromMinutes(365).Humanize(maxUnit: Humanizer.Localisation.TimeUnit.Second));
            Console.WriteLine("Robot".ToQuantity(5));
            Console.WriteLine("une longe liste de mots".Kebaberize().Titleize());
            Console.WriteLine("");
        }


        public static void TestConsole()
        {
            string phrase = "une longe liste de mots";
            Console.WriteLine(phrase, Color.LightCoral);
            Console.WriteLine(phrase, Color.LemonChiffon);
            Console.WriteLine(phrase, Color.Purple);
            Console.WriteLine(phrase, Color.Tomato);
            Console.WriteLine(phrase, Color.RoyalBlue);

            int R = 167;
            int G = 212;
            int B = 230;
            for (int i = 0; i < 3; i++)
            {
                Console.WriteAscii("Prog", Color.FromArgb(R, G, B));

                R -= 18;
                G -= 36;
            }

        }
    }
}
