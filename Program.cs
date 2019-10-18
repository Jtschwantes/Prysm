using System;
using static Spectrum.Spec;
using static Spectrum.Colors;
using static Spectrum.ColorSets;
using System.Collections.Generic;

namespace Spectrum
{
    class Program
    {
        static void Main( string[] args )
        {
            Spec.Initialize();
            Console.WriteLine();

            var color1 = RGB(100, 255, 200);
            var color2 = HEX("#cc60cc");
            var myColor2 = RGB(10, 25, 100);
            WriteLine("You can save and use your own colors per line", color1, HEX("#cc60cc"));
            WriteLine("Blah Joe", Red);
            
            Style(RGB(155, 255), HEX("222222"));
            Console.WriteLine("This will always print your desired colors");
            Console.WriteLine("Even when you use Console.WriteLine!");
            Spec.Reset();
            
            Gradient("You can even use gradients in your text", HEX("ff0000"), HEX("00ffff"));
        
            Console.WriteLine();
            Spec.Reset();

            Gradient("This is a Pass/Warn/Fail example", Colors.Magenta, Colors.Red);
            Pass("Pass message");
            Warn("Warn message");
            Error("Error message");
            Console.WriteLine("Normal Message (Console)");
            Spec.Reset();

            Console.WriteLine();
            Style(Colors.DarkMagenta, Colors.Grey);
            Console.WriteLine("Console before Reset");
            Console.WriteLine("Console before Reset");
            Write("Spec before Reset", Colors.Green, Colors.Grey);
            Spec.Reset();
            Console.WriteLine();
            Console.WriteLine("Console after Reset");
            Console.WriteLine();

            string r = Paint("Red", Colors.Red);
            string g = Paint("Green", Colors.Green);
            string b = Paint("Cyan", Colors.Cyan);
            Console.WriteLine($"{r}, {g}, {b}...");
            // Or, in one line:
            Console.WriteLine($"{Paint("Red", Red)}, {Paint("Green", Green)}, {Paint("Cyan", Cyan)}...");
            Spec.Reset();

            Style(Black, White);
            Console.Write("Before Reset");
            Spec.Reset();
            Console.WriteLine("\nAfter Reset");

            Gradient("This string will print from magenta to red", Magenta, Red);
            Gradient("This string will print from cyan to green", Cyan, Green);
            Gradient("This string will print from yellow to orange", Yellow, RGB(255, 100, 0));
            Gradient("This string will print from white to black", White, Black);

            Console.WriteLine();

            var colors = new List<string>(){Red, Magenta};
            AlternateCharacters("This sentance will print as a rainbow!", Rainbow, 3);
            AlternateCharacters("This sentance will switch between red and purple", colors, 2);
            Reset();
        }
    }
}
