using System;
using static Spectrum.Spec;
using static Spectrum.Colors;

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
            Spec.WriteLine("You can save and use your own colors per line", color1, HEX("#cc60cc"));
            Spec.WriteLine("Blah Joe", Red);
            
            Style(RGB(155, 255), HEX("222222"));
            Console.WriteLine("This will always print your desired colors");
            Console.WriteLine("Even when you use Console.WriteLine!");
            Spec.Reset();
            
            Spec.GradientLine("You can even use gradients in your text", HEX("ff0000"), HEX("00ffff"));
        
            Console.WriteLine();
            Spec.Reset();

            Spec.GradientLine("This is a Pass/Warn/Fail example", Colors.Magenta, Colors.Red);
            Spec.Pass("Pass message");
            Spec.Warn("Warn message");
            Spec.Error("Error message");
            Console.WriteLine("Normal Message (Console)");
            Spec.Reset();

            Console.WriteLine();
            Spec.Style(Colors.DarkMagenta, Colors.Grey);
            Console.WriteLine("Console before Reset");
            Console.WriteLine("Console before Reset");
            Spec.Write("Spec before Reset", Colors.Green, Colors.Grey);
            Spec.Reset();
            Console.WriteLine();
            Console.WriteLine("Console after Reset");
            Console.WriteLine();

            string r = Paint("Red", Colors.Red);
            string g = Paint("Green", Colors.Red);
            string b = Paint("Cyan", Colors.Red);
            Console.WriteLine($"{r}{g}{b}");
        }
    }
}
