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

            var myColor = RGB(100, 255, 200);
            var myColor2 = RGB(10, 25, 100);
            var myOtherColor = HEX("#cc60cc");
            Spec.WriteLine("You can save and use your own colors per line", myColor, myOtherColor);
            Spec.WriteLine("Blah Joe", Red);
            
            Style(RGB(155, 255), HEX("222222"));
            Console.WriteLine("This will always print your desired colors");
            Console.WriteLine("Even when you use Console.WriteLine!");
            Spec.Reset();
            
            Spec.GradientLine("You can even use gradients in your text", HEX("ff0000"), HEX("00ffff"));
        
            Console.WriteLine();

            //This is aaron's part
            Spec.Reset();
        }
    }
}
