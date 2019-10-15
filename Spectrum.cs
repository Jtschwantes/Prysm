using System;
using System.Runtime.InteropServices;
using System.Collections.ObjectModel;

namespace Spectrum
{
    public static class Spec
    {
        [DllImport( "kernel32.dll", SetLastError = true )]
        public static extern bool SetConsoleMode( IntPtr hConsoleHandle, int mode );
        [DllImport( "kernel32.dll", SetLastError = true )]
        public static extern bool GetConsoleMode( IntPtr handle, out int mode );
        [DllImport( "kernel32.dll", SetLastError = true )]
        public static extern IntPtr GetStdHandle( int handle );

        // Initialize to implement DLL files for functionality
        public static void Initialize()
        {
            var handle = GetStdHandle( -11 );
            int mode;
            GetConsoleMode( handle, out mode );
            SetConsoleMode( handle, mode | 0x4 );

            // TODO: Don't assume that they're using black and white
            defaultFore = "\x1b[38;2;255;255;255m";
            defaultBack = "\x1b[48;2;0;0;0m";
            currentFore = defaultFore;
            currentBack = defaultBack;
        }

        // Static variables
        private static string defaultFore {get;set;}
        private static string defaultBack {get;set;}
        private static string currentFore {get;set;}
        private static string currentBack {get;set;}

        // TODO: Grab user's defaults
        public static void Reset()
        {
            Console.Write(defaultFore + defaultBack);
        }

        private static void SoftReset()
        {
            Console.Write(currentFore + currentBack);
        }

        // Writers
        public static void WriteLine(string str, string fore = "", string back = "")
        {
            Console.Write(fore.Replace(" ", "38") + back.Replace(" ", "48") + str);
            Spec.SoftReset();
            Console.WriteLine();
        }

        public static void GradientLine(string str, string frontBeginning, string frontEnd, string backBeginning = "", string backEnd = "")
        {
            var RGB1 = FormatToRGB(frontBeginning);
            var RGB2 = FormatToRGB(frontEnd);
            
            var dbl = new double[3] {(double)RGB1[0], (double)RGB1[1], (double)RGB1[2]};

            var dr = (double)(RGB2[0] - RGB1[0]);
            var dg = (double)(RGB2[1] - RGB1[1]);
            var db = (double)(RGB2[2] - RGB1[2]);

            dr = dr / str.Length;
            dg = dg / str.Length;
            db = db / str.Length;
            
            for(int i = 0; i < str.Length; i++)
            {
                string s = FormatToForeground(RGB(Convert.ToInt32(dbl[0]), Convert.ToInt32(dbl[1]), Convert.ToInt32(dbl[2])));
                Console.Write(s + str[i]);
                dbl[0] += dr;
                dbl[1] += dg;
                dbl[2] += db;
            }

            Console.WriteLine();
        }
        
        public static void Write(string str, string fore = "", string back = "")
        {
            Console.Write(fore.Replace(" ", "38") + back.Replace(" ", "48") + str);
            Spec.SoftReset();
        }

        public static string Paint(string str, string fore = "", string back = "")
        {
            return FormatToForeground(fore) + FormatToBackground(back) + str + currentFore + currentBack;
        }

        // Status Writes
        public static void Error(string str) { WriteLine(str, Colors.Red); Spec.SoftReset();}
        public static void Warn(string str) { WriteLine(str, Colors.Yellow); Spec.SoftReset();}
        public static void Pass(string str) { WriteLine(str, Colors.Green); Spec.SoftReset();}
        
        // Color Getters (Public)
        public static string RGB(int r = 0, int g = 0, int b = 0)
        {
            return "\x1b[ ;2;" + r + ";" + g + ";" + b + "m";
        }

        public static string HEX(string hex)
        {
            if(hex[0] == '#') hex = hex.Remove(0, 1);
            string r = int.Parse(hex.Substring(0, 2), System.Globalization.NumberStyles.HexNumber).ToString();
            string g = int.Parse(hex.Substring(2, 2), System.Globalization.NumberStyles.HexNumber).ToString();
            string b = int.Parse(hex.Substring(4, 2), System.Globalization.NumberStyles.HexNumber).ToString();
            return "\x1b[ ;2;" + r + ";" + g + ";" + b + "m";
        }

        public static void Style(string fore = null, string back = null)
        {
            if(fore != null) currentFore = FormatToForeground(fore);
            if(back != null) currentBack = FormatToBackground(back);
            SoftReset();
        }

        // Formatters (Private)
        private static string FormatToForeground(string str) { return str.Replace(" ", "38");}
        private static string FormatToBackground(string str) { return str.Replace(" ", "48");}
        private static int[] FormatToRGB(string str)
        {
            var strs = str.Split(";");
            return new int[] {int.Parse(strs[2]), int.Parse(strs[3]), int.Parse(strs[4].Remove(strs[4].Length - 1))};
        }
    }

    // Default Colors
    public static class Colors
    {
        public const string Black = "\x1b[ ;2;0;0;0m";
        public const string White = "\x1b[ ;2;255;255;255m";
        public const string Red = "\x1b[ ;2;255;0;0m";
        public const string Green = "\x1b[ ;2;0;255;0m";
        public const string Blue = "\x1b[ ;2;0;0;255m";
        public const string Yellow = "\x1b[ ;2;255;255;0m";
        public const string Magenta = "\x1b[ ;2;255;0;255m";
        public const string Cyan = "\x1b[ ;2;0;255;255m";
        public const string Grey = "\x1b[ ;2;100;100;100m";
        public const string DarkRed = "\x1b[ ;2;100;0;0m";
        public const string DarkGreen = "\x1b[ ;2;0;100;0m";
        public const string DarkBlue = "\x1b[ ;2;0;0;100m";
        public const string DarkYellow = "\x1b[ ;2;100;100;0m";
        public const string DarkMagenta = "\x1b[ ;2;100;0;100m";
        public const string DarkCyan = "\x1b[ ;2;0;100;100m";
    }
}