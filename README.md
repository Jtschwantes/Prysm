# <span style="color: red">S</span><span style="color: #ff8800">p</span><span style="color: #ffff00">e</span><span style="color: #00ff00">c</span><span style="color: #00ffff">t</span><span style="color: #0000ff">r</span><span style="color: #990099">u</span><span style="color: #ff00ff">m</span>

Spectrum is a CLI beutification tool that provides simple and easy manipulation of console colors.
This tool formats escape characters, which provides 256 color support to most windows command lines.

## <span style="color: red">Initialization</span>

First, download the package. (The package is in a "closed beta" state)

When you have the package, add the following using statement to permit access to the methods:
```C#
using Spectrum;
```
Or, you may include the static keyword in the using statement to avoid using the `Spec` syntax with every method and with the `Colors` static class:
```C#
using static Spectrum.Spec;
using static Spectrum.Colors;
```
Prior to usage, you must initialize the class by using the Initialize function. 
You may specify default forground and background colors as the first and second parameters, respectively. 
Spectrum will use those defaults as values anytime `Spec.Reset()` is called. 
The default forground and background colors are white and black.
```C#
Spec.Initialize();
```

## <span style="color: #00ff00">Usage</span>

Spectrum uses simple syntax to format and print lines. 
As a general rule, the writing methods provided are similar to `Console.WriteLine()` and `Console.Write()` in the sense that every call can add `Line` to add the newline character to the end of the string.

The user can use the `Pass`, `Warn`, and `Error` methods for the most basic usage. 
Spectrum will take a string as an input and write it in green, yellow, or red, respectively.

The following code lines:
```C#
Initialize();
// To avoid writing "Spec" before everything, include "using static Spectrum.Spec;"
Pass("Pass message");
Warn("Warn message");
Error("Error message");
Console.WriteLine("Normal Message (Console)");
```
Output:

![Example output of Pass, Warn, and Error lines](/images/PFEExample.png)

#### Colored WriteLine

You can also write using custom colors by using the `Spec.WriteLine()` command.
It behaves just like `Console.WriteLine()`, except it takes an additional two parameters. 
The first parameter is the string to print, the second is the color of the foreground text, and the third is the color of the background. `Spec.Write()` behaves similarly, except without the newline character. Example:

```C#
// ... Make sure to initialize Spectrum!
Console.WriteLine("This is an example using Spec.Write and WriteLine");
// WriteLine examples - including "using static Spectrum.Colors"
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

Spectrum also provides a way to use customized colors. If you don't want to use the built in colors from `Spectrum.Colors`, you can use `RGB()` or `HEX()` inside the write methods or you can save them as variables. Example:
```C#
// Colors are saved as strings
var color = RGB(100, 255, 200);
Spec.WriteLine("My string", color, HEX("#cc60cc")); // "#" char optional for HEX()
```

#### Permanent styling

The user can permanently style their console by using the `Style()` method. Style will accept two parameters, the first being the foreground color, and the second being the background color. When styled, all standard writes (whether Spectrum or Console writes) will be printed in the chosen color. You can use `Reset()` to reset the colors to the default colors set in `Initialize()`. It is important to note that new line characters will cause the background color continue for every character until the next line begins. To avoid this, place the newline character after the reset. Example:
```C#
Style(Black, White);
Console.Write("Before Reset");
Reset();
Console.WriteLine("\nAfter Reset");
```

Output:

![Example with Paint](/images/SRExample.png)

#### Coloring Strings

Spectrum provides functionality to permanently change the color of strings, even when used when writing with Console. To do so, you can use the `Paint` function. Similarly to the `Write` functions, it uses three paramters. The string to color, and the forground and background colors. 

Paint will attach the colors selected to the beginning of the string, then the default colors selected by `Initialize()` at the end of the string. If the colors were overidden with the `style()` function, it will revert to those instead. Example:

```C#
using static Spectrum.Spec;
using static Spectrum.Colors;

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
