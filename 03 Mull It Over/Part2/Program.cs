using System.Text.RegularExpressions;

namespace AoC;

internal class Program
{
    static void Main()
    {
        long result = 0;
        var data = System.IO.File.ReadAllText(@"..\..\input.txt");
        var regex = new Regex(@"(mul)\((\d+),(\d+)\)|(do)\(\)|(don't)\(\)");
        bool enabled = true;
        foreach (Match match in regex.Matches(data))
        {
            if (match.Groups[1].Value == "mul")
            {
                if (enabled)
                {
                    var a = long.Parse(match.Groups[2].Value);
                    var b = long.Parse(match.Groups[3].Value);
                    result += a * b;
                }
            }
            else if (match.Groups[4].Value == "do")
            {
                enabled = true;
            }
            else if (match.Groups[5].Value == "don't")
            {
                enabled = false;
            }
            else
            {
                throw new System.Exception("Invalid match");
            }
        }
        Console.WriteLine(result);
    }
}