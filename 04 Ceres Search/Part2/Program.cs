namespace AoC;

internal class Program
{
    static void Main(string[] args)
    {
        int result = 0;
        var field = File.ReadAllLines(@"..\..\input.txt");
        int w = field[0].Length;
        int h = field.Length;
        for (int y = 1; y < h - 1; y++)
        {
            for (int x = 1; x < w - 1; x++)
            {
                if (field[y][x] == 'A')
                {
                    if (
                        (
                            field[y - 1][x - 1] == 'M' && field[y + 1][x + 1] == 'S' ||
                            field[y - 1][x - 1] == 'S' && field[y + 1][x + 1] == 'M'
                        ) && (
                            field[y - 1][x + 1] == 'M' && field[y + 1][x - 1] == 'S' ||
                            field[y - 1][x + 1] == 'S' && field[y + 1][x - 1] == 'M'
                        )
                       )
                    {
                        result++;
                    }

                }
            }
        }
        Console.WriteLine(result);
    }
}