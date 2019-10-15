# Spectrum

Spectrum is a CLI beutification tool that provides simple and easy manipulation of console colors.
This tool formats escape characters, which provides 256 color support to most windows command lines.

## Initialization

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

## Usage

Spectrum uses simple syntax to format and print lines. 
As a general rule, the writing methods provided are similar to `Console.WriteLine()` and `Console.Write()` in the sense that every call can add `Line` to add the newline character to the end of the string.

The user can use the `Pass`, `Warn`, and `Error` methods for the most basic usage. 
Spectrum will take a string as an input and write it in green, yellow, or red, respectively.

The following code lines:
```C#
Spec.Initialize();
// To avoid writing "Spec" before everything, use the using static statement
Spec.Pass("Pass message");
Spec.Warn("Warn message");
Spec.Error("Error message");
Console.WriteLine("Normal Message (Console)");
```
Output:

![Example output of Pass, Warn, and Error lines](/images/PFEExample.png)

You can also write using custom colors by using the `Spec.WriteLine()` command.
It behaves just like `Console.WriteLine()`, except it takes an additional two parameters. 
The first parameter is the string to print, the second is the color of the foreground text, and the third is the color of the background. `Spec.Write()` behaves similarly, except without the newline character. Example:

```C#
// ... Make sure to initialize Spectrum!
Console.WriteLine("This is an example using Spec.Write and WriteLine");
// WriteLine examples
Spec.WriteLine("This will print using the color chosen (magenta)", Colors.Magenta);
Spec.WriteLine("This will print using a foreground and background color!", Colors.Cyan, Colors.Grey);
// Multiple colors per line
Console.Write("This will print multiple colors: ");
Spec.Write("Red, ", Colors.Red);
Spec.Write("Green, ", Colors.Green);
Spec.Write("Blue.\n", Colors.Blue);
```

Output:


![Example output of Pass, Warn, and Error lines](/images/WLExample.png)

Spectrum also provides a way to use customized colors. If you don't want to use the built in colors from `Spectrum.Colors`, you can use `RGB()` or `HEX()` inside the write methods or you can save them as variables. Example:
```C#
// Colors are saved as strings
var color = RGB(100, 255, 200);
Spec.WriteLine("My string", color, HEX("#cc60cc")); // "#" char optional for HEX()
```