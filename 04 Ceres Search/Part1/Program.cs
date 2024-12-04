namespace AoC;

internal class Program
{
    static void Main(string[] args)
    {
        int result = 0;
        var field = File.ReadAllLines(@"..\..\input.txt");
        int w = field[0].Length;
        int h = field.Length;
        string s = "XMAS";
        for (int n = 0; n < 9; n++)
        {
            int dx = n % 3 - 1;
            int dy = n / 3 - 1;
            if (dx == 0 && dy == 0) continue;
            for (int y = 0; y < h; y++)
            {
                for (int x = 0; x < w; x++)
                {
                    bool found = true;
                    for (int i = 0; i < s.Length; i++)
                    {
                        int xx = x + i * dx;
                        int yy = y + i * dy;
                        if (xx < 0 || xx >= w || yy < 0 || yy >= h || field[yy][xx] != s[i])
                        {
                            found = false;
                            break;
                        }
                    }
                    if (found) result++;
                }
            }
        }
        Console.WriteLine(result);
    }
}