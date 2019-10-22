using System;
using System.Runtime.InteropServices;
using System.Collections;

namespace Spectrum
{
    public static class Spec
    {
        // DLL imports - allows the console to change mode to allow the escape color characters
        [DllImport( "kernel32.dll", SetLastError = true )]
        public static extern bool SetConsoleMode( IntPtr hConsoleHandle, int mode );
        [DllImport( "kernel32.dll", SetLastError = true )]
        public static extern bool GetConsoleMode( IntPtr handle, out int mode );
        [DllImport( "kernel32.dll", SetLastError = true )]
        public static extern IntPtr GetStdHandle( int handle );

        // Initialize to implement DLL files for functionality
        public static void Initialize()
        {
            // DLL import handle and mode set
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
            // Make sure to change the current "style" too
            currentFore = defaultFore;
            currentBack = defaultBack;
            Console.Write(defaultFore);
            Console.Write(defaultBack);
        }

        // Private - Resets to current colors (affected by Style())
        private static void SoftReset()
        {
            Console.Write(currentFore + currentBack);
        }

        // Writers //
        // Wrapper for Console.WriteLine()
        public static void WriteLine(string str, string fore = "", string back = "")
        {
            Console.Write(fore.Replace(" ", "38") + back.Replace(" ", "48") + str);
            Spec.SoftReset();
            Console.WriteLine();
        }

        // Gradient - changes rgb values with each character until the end of the string
        // TODO: Add background functionality
        public static void Gradient(string str, string frontBeginning, string frontEnd)
        {
            // Make sure that the colors are in RGB
            var RGB1 = FormatToRGB(frontBeginning);
            var RGB2 = FormatToRGB(frontEnd);
            
            // Cast to array of doubles
            var dbl = new double[3] {(double)RGB1[0], (double)RGB1[1], (double)RGB1[2]};

            // Total change in each value
            var dr = (double)(RGB2[0] - RGB1[0]);
            var dg = (double)(RGB2[1] - RGB1[1]);
            var db = (double)(RGB2[2] - RGB1[2]);

            // Divide by total to create a change in r, g, and b for each character
            dr = dr / str.Length;
            dg = dg / str.Length;
            db = db / str.Length;
            
            // Loop for each character, changing the color values char by char
            for(int i = 0; i < str.Length; i++)
            {
                string s = FormatToForeground(RGB(Convert.ToInt32(dbl[0]), Convert.ToInt32(dbl[1]), Convert.ToInt32(dbl[2])));
                Console.Write(s + str[i]);
                // Make the change
                dbl[0] += dr;
                dbl[1] += dg;
                dbl[2] += db;
            }

            // Make sure that the colors don't stick, add the new line char
            SoftReset();
            Console.WriteLine();
        }

        public static void AlternateCharacters(string str, IEnumerable colors, int alternatingConcurrency = 1)
        {
            var max = alternatingConcurrency;
            var counter = 0;

            var enumerator = colors.GetEnumerator();
            enumerator.Reset();
            if(!enumerator.MoveNext()) return;
            foreach(var chr in str)
            {
                Write(Convert.ToString(chr), FormatToForeground((string)enumerator.Current));
                if(chr != ' ') counter++;
                if(counter == max)
                {
                    counter = 0;
                    if(!enumerator.MoveNext())
                    {
                        enumerator.Reset();
                        enumerator.MoveNext();
                    }
                }
            }

            SoftReset();
            Console.WriteLine();
        }
        
        //Wrapper for Console.Write(), same as WriteLine without the new line char
        public static void Write(string str, string fore = "", string back = "")
        {
            Console.Write(fore.Replace(" ", "38") + back.Replace(" ", "48") + str);
            SoftReset();
        }

        // Paints a string permanantly, adds the color escape strings to the beginning and end of the string
        public static string Paint(string str, string fore = "", string back = "")
        {
            return FormatToForeground(fore) + FormatToBackground(back) + str + currentFore + currentBack;
        }

        // Status Writes
        public static void Error(string str) { WriteLine(str, Colors.Red); Spec.SoftReset();} // Writes in Red
        public static void Warn(string str) { WriteLine(str, Colors.Yellow); Spec.SoftReset();} // Writes in Yellow
        public static void Pass(string str) { WriteLine(str, Colors.Green); Spec.SoftReset();} // Writes in Green
        
        // Color Getters (Public)
        // Takes red, green, and blue as integers
        public static string RGB(int r = 0, int g = 0, int b = 0)
        {
            return "\x1b[ ;2;" + r + ";" + g + ";" + b + "m";
        }

        // Takes the hex value and parses each into r, g, and b values
        public static string HEX(string hex)
        {
            if(hex[0] == '#') hex = hex.Remove(0, 1);
            string r = int.Parse(hex.Substring(0, 2), System.Globalization.NumberStyles.HexNumber).ToString();
            string g = int.Parse(hex.Substring(2, 2), System.Globalization.NumberStyles.HexNumber).ToString();
            string b = int.Parse(hex.Substring(4, 2), System.Globalization.NumberStyles.HexNumber).ToString();
            return "\x1b[ ;2;" + r + ";" + g + ";" + b + "m";
        }

        // Changes Current color values into different ones. Used by most write functions.
        public static void Style(string fore = null, string back = null)
        {
            if(fore != null) currentFore = FormatToForeground(fore);
            if(back != null) currentBack = FormatToBackground(back);
            SoftReset();
        }

        // Formatters (Private)
        // Formats the escape string to foreground
        private static string FormatToForeground(string str) { return str.Replace(" ", "38");}
        // Formats the escape string to background
        private static string FormatToBackground(string str) { return str.Replace(" ", "48");}
        // Formats the the escape string into RGB colors, returns an array (used by gradient)
        private static int[] FormatToRGB(string str)
        {
            var strs = str.Split(';');
            return new int[] {int.Parse(strs[2]), int.Parse(strs[3]), int.Parse(strs[4].Remove(strs[4].Length - 1))};
        }
    }
}