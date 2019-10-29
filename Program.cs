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

            Gradient("Test number 7: Underline", Green, Yellow);
            WriteLineUnderscore("No color, underline");
            WriteUnderscore("With color, no newline, underline", YellowGreen);
            WriteLine("Four Chang, no underline", Green);

            var myString = Underscore("Underscore Blue", Blue);
            WriteLine("Using Pym.WriteLine: " + myString, Red);
            Console.WriteLine("Using Console.WriteLine: " + myString);
            WriteLineUnderscore("Example using WriteLineUnderscore()", Magenta);
            WriteUnderscore("Example using ", Green);
            WriteUnderscore("two WriteUnderscores", Yellow);
            Console.WriteLine();

            AlternateCharacters("Test Methods:", Rainbow, 2);
            Console.WriteLine("\x1b[10m" + "Here's my test");
            Console.WriteLine("\x1b[11m" + "Here's my test");
            Console.WriteLine("\x1b[12m" + "Here's my test");
            Console.WriteLine("\x1b[13m" + "Here's my test");
        }
    }
}
