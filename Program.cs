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
            Console.WriteLine(Red.Replace(" ", "38") + "Hello" + "\x1b[0mHello!!!");
        }
    }
}
