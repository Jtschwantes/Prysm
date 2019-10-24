using System;
using static Prysm.Pym;
using static Prysm.Colors;
using static Prysm.ColorSets;

namespace Prysm
{
    class Program
    {
        static void Main(string[] args)
        {
            Initialize();
            Console.WriteLine();

            Gradient("Test number 1: Gradient", Green, Yellow);
            Console.WriteLine();
            
            Gradient("Test number 2: Pass/Warn/Fail", Yellow, Red);
            Pass("Pass");
            Warn("Warn");
            Error("Error");
            Console.WriteLine();

            Gradient("Test number 3: WriteLine and Write", Red, Magenta);
            WriteLine("WriteLine with LightCoral", LightCoral);
            Console.WriteLine("Console inbetween");
            WriteLine("WriteLine with Maroon and Olive", LightCoral, Olive);
            Write("Write with pink ", Pink);
            Console.WriteLine("Console inbetween");
            Write("Write with peru", Peru, Lime);
            Console.WriteLine();
            Console.WriteLine();

            Gradient("Test number 4: ColorGetters (HEX, RGB)", Magenta, Blue);
            var myColor1 = RGB(50, 50, 50);
            var myColor2 = HEX("999999");
            var myColor3 = HEX("#555555");
            WriteLine("First WriteLine", myColor1);
            WriteLine("Second WriteLine", myColor2, myColor3);
            Console.WriteLine();

            Gradient("Test number 5: Style and Reset", Blue, Cyan);
            WriteLine("Pym Before Style Set", Cyan);
            Console.WriteLine("Console Before Style Set");
            Style(Black, White);
            Console.Write("Console after style");
            Reset();
            Console.WriteLine();
            Console.WriteLine("Console after reset");
            Console.WriteLine();

            Gradient("Test number 6: String Painting", Cyan, Green);
            var str1 = Paint("Paint1", Purple);
            var str2 = Paint("Paint2", MediumPurple);
            var str3 = Paint("Paint3", DarkRed, White);
            Console.WriteLine($"Written in console: {str1}, {str2}, {str3}");
            Console.WriteLine();

            Gradient("Test number 7: AlternateCharacters", Green, Yellow);
            AlternateCharacters("Alternate Characters 1", Rainbow, 2);
            AlternateCharacters("Alternate Characters 2", Rainbow, 3);
            Console.WriteLine();
        }
    }
}
