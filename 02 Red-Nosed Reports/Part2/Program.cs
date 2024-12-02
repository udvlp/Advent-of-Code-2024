namespace AoC;

internal class Program
{
    static void Main(string[] args)
    {
        var sr = new StreamReader(@"..\..\input.txt");
        int result = 0;
        while (!sr.EndOfStream)
        {
            var line = sr.ReadLine();
            string[] a = line.Split(' ');
            int[] b = Array.ConvertAll(a, int.Parse);
            bool safe = true;
            for (int skip = -1; skip < b.Length; skip++)
            {
                safe = true;
                int i1 = (skip == 0 ? 1 : 0);
                int i2 = (skip == i1 + 1 ? i1 + 2 : i1 + 1);
                bool isascending = b[i2] > b[i1];
                for (int i = 0; i < b.Length - 1; i++)
                {
                    if (i == skip) continue;
                    int n = i + 1;
                    if (n == skip) n++;
                    if (n >= b.Length) continue;
                    int d = Math.Abs(b[n] - b[i]);
                    if (isascending != b[n] > b[i] || d < 1 || d > 3)
                    {
                        safe = false;
                        break;
                    }
                }
                if (safe) break;
            }
            if (safe) result++;
        }
        Console.WriteLine(result);
    }
}