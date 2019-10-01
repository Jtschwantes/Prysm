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
            
            var color1 = RGB(100, 255, 200);
            //var color2 = HEX("#555555");
            Spec.WriteLine("It's lit", Blue);
            Style(RGB(255), HEX("#111111"));
            Console.WriteLine("It's not lit");
            Spec.GradientLine("It's Gradient!", HEX("ffffff"), HEX("000000"));
            Spec.WriteLine("Test", RGB(255, 0 , 0));
            Spec.WriteLine("Test", RGB(255, 0 , 55));
            Spec.WriteLine("Test", RGB(255, 0 , 100));
            Spec.WriteLine("Test", RGB(255, 0 , 155));
            Spec.WriteLine("Test", RGB(255, 0 , 200));
            Spec.WriteLine("Test", RGB(255, 0 , 255));
            Spec.WriteLine("Test", RGB(200, 0 , 255));
            Spec.WriteLine("Test", RGB(155, 0 , 255));
            Spec.WriteLine("Test", RGB(100, 0 , 255));
            Spec.WriteLine("Test", RGB(55, 0 , 255));
            Spec.WriteLine("Test", RGB(0, 0 , 255));

            Spec.WriteLine("Test", HEX("00ff00"));
            Spec.WriteLine("Test", HEX("00ee00"));
            Spec.WriteLine("Test", HEX("00dd00"));
            Spec.WriteLine("Test", HEX("00cc00"));
            Spec.WriteLine("Test", HEX("00aa00"));
            Spec.WriteLine("Test", HEX("009900"));
            Spec.WriteLine("Test", HEX("007700"));
            Spec.WriteLine("Test", HEX("006600"));
            Spec.WriteLine("Test", HEX("005500"));
            Spec.WriteLine("Test", HEX("003300"));
            Spec.WriteLine("Test", HEX("001100"));

            Spec.Reset();
        }
    }
}
