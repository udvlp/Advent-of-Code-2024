using System.Text.RegularExpressions;

namespace AoC;

internal class Program
{
    static void Main()
    {
        long result = 0;
        var data = System.IO.File.ReadAllText(@"..\..\input.txt");
        var regex = new Regex(@"mul\((\d+),(\d+)\)");
        foreach (Match match in regex.Matches(data))
        {
            var a = long.Parse(match.Groups[1].Value);
            var b = long.Parse(match.Groups[2].Value);
            result += a * b;
        }
        Console.WriteLine(result);
    }
}