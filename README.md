![Prysm](/images/CroppedBlackPrism.jpg)

Prysm is a CLI beautification tool that provides simple and easy manipulation of console colors.
This tool formats escape characters, which provides 256 color support to most windows command lines.

**Prysm is in beta, there are known bugs. Use at your own risk!**

Version 0.1.0 Changes - Added Underline functionality.

Version 0.0.2 Changes - Fixed a bug that changed default color values to a white foreground and a black background.

-----

## Initialization

First, download the package. You can download the package on nuget or you can add it to your project using the following command:
```
dotnet add package Prysm --version 0.1.0
```

When you have the package, add the following using statement to permit access to the methods:
```C#
using Prysm;
```
Or, you may include the static keyword in the using statement to avoid using the `Pym` syntax with every method and with the `Colors` static class:
```C#
using static Prysm.Pym;
using static Prysm.Colors;
```
Prior to usage, you must initialize the class by using the Initialize function. 
You may specify default forground and background colors as the first and second parameters, respectively. 
Prysm will use those defaults as values anytime `Pym.Reset()` is called. 
The default forground and background colors are white and black.
```C#
Pym.Initialize();
```

## Usage

Prysm uses simple syntax to format and print lines. 
As a general rule, the writing methods provided are similar to `Console.WriteLine()` and `Console.Write()` in the sense that every call can add `Line` to add the newline character to the end of the string.

The user can use the `Pass`, `Warn`, and `Error` methods for the most basic usage. 
Prysm will take a string as an input and write it in green, yellow, or red, respectively.

The following code lines:
```C#
Initialize();
// To avoid writing "Pym" before everything, include "using static Prysm.Pym;"
Pass("Pass message");
Warn("Warn message");
Error("Error message");
Console.WriteLine("Normal Message (Console)");
```
Output:

![Example output of Pass, Warn, and Error lines](/images/PFEExample.png)

#### Colored WriteLine

You can also write using custom colors by using the `Pym.WriteLine()` command.
It behaves just like `Console.WriteLine()`, except it takes an additional two parameters. 
The first parameter is the string to print, the second is the color of the foreground text, and the third is the color of the background. `Pym.Write()` behaves similarly, except without the newline character. Example:

```C#
// ... Make sure to initialize Prysm!
Console.WriteLine("This is an example using Pym.Write and WriteLine");
// WriteLine examples - including "using static Prysm.Colors"
WriteLine("This will print using the color chosen (magenta)", Magenta);
WriteLine("This will print using a foreground and background color!", Cyan, Grey);
// Multiple colors per line
Console.Write("This will print multiple colors: ");
Write("Red, ", Red);
Write("Green, ", Green);
Write("Blue.\n", Blue);
```

Output:

![Example output of Pass, Warn, and Error lines](/images/WLExample.png)

Prysm also provides a way to use customized colors. If you don't want to use the built in colors from `Prysm.Colors`, you can use `RGB()` or `HEX()` inside the write methods or you can save them as variables. Example:
```C#
// Colors are saved as strings
var color = RGB(100, 255, 200);
Pym.WriteLine("My string", color, HEX("#cc60cc")); // "#" char optional for HEX()
```

#### Permanent styling

The user can permanently style their console by using the `Style()` method. Style will accept two parameters, the first being the foreground color, and the second being the background color. When styled, all standard writes (whether Prysm or Console writes) will be printed in the chosen color. You can use `Reset()` to reset the colors to the default colors set in `Initialize()`. It is important to note that new line characters will cause the background color continue for every character until the next line begins. To avoid this, place the newline character after the reset. Example:
```C#
Style(Black, White);
Console.Write("Before Reset");
Reset();
Console.WriteLine("\nAfter Reset");
```

Output:

![Example with Paint](/images/SRExample.png)

#### Coloring Strings

Prysm provides functionality to permanently change the color of strings, even when used when writing with Console. To do so, you can use the `Paint` function. Similarly to the `Write` functions, it uses three paramters. The string to color, and the forground and background colors. 

Paint will attach the colors selected to the beginning of the string, then the default colors selected by `Initialize()` at the end of the string. If the colors were overidden with the `style()` function, it will revert to those instead. Example:

```C#
using static Prysm.Pym;
using static Prysm.Colors;

// ...

string r = Paint("Red", Red);
string g = Paint("Green", Green);
string b = Paint("Cyan", Cyan);
Console.WriteLine($"{r}, {g}, {b}...");
// Or, in one line:
Console.WriteLine($"{Paint("Red", Red)}, {Paint("Green", Green)}, {Paint("Cyan", Cyan)}...");
```
Output:

![Example with Paint](/images/PExample.png)

#### Gradients

The `Gradient()` method behaves just like `Write()`, except the colors gradually shade between two colors. <!--Therefore, it accepts five parameters. The first is the string to be written, the second and third are the foreground colors to gradient, and the fourth and fifth are the background colors to gradient.-->The first parameter is the string to be written, the second and third are the foreground colors in the gradient. Example:
```C#
Gradient("This string will print from magenta to red", Magenta, Red);
Gradient("This string will print from cyan to green", Cyan, Green);
Gradient("This string will print from yellow to orange", Yellow, RGB(255, 100, 0));
Gradient("This string will print from white to black", White, Black);
```

Outputs:

![Example with Paint](/images/GExample.png)

#### Alternating Colors

The `AlternatingCharacters()` function provides a way to alternate characters. It will print the first string parameter, and it will rotate through a `IEnumerable` (second parameter) of colors after every `int n` character, where `n` is the third parameter passed into the function. It will not consider spaces as characters. Example:

```C#
using static ColorSets;
// ...
var colors = new List<string>(){Red, Magenta};
AlternateCharacters("This sentance will print as a rainbow!", Rainbow, 3);
AlternateCharacters("This sentance will switch between red and purple", colors, 2);
```

Output:

![Example with AlternatingCharacters](/images/ACExample.png)

#### Underscore

There are some functions that behave similar to the `Pym.WriteLine`, `Pym.Write`, and `Paint` functions which underline text for you. You can both color and underline text at the same time. `Pym.WriteLineUnderscore` and `Pym.WriteUnderscore` are exactly the same as the `WriteLine` and `Write` functions written above, but they underline the text in addition to the color formatting. They use the same parameters. The `Underscore` function is also the same as the `Paint` function, which will return a underscored string that can be used within the `WriteLine` functions both in `Pym` and `Console`. The following is an example of underscore usage:

```C#
using static Prysm.Pym;
using static Prysm.Colors;
// ...
// Save an underline string
var myString = Underscore("Underscore Blue", Blue);
// Use it in writes
WriteLine("Using Pym.WriteLine: " + myString, Red);
Console.WriteLine("Using Console.WriteLine: " + myString);
// Without saving a string
WriteLineUnderscore("Example using WriteLineUnderscore()", Magenta);
WriteUnderscore("Example using ", Green);
WriteUnderscore("two WriteUnderscores", Yellow);
Console.WriteLine();
```

Output:

![Example with Underscore](/images/UExample.png)
