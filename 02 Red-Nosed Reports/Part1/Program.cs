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
            bool isascending = b[1] > b[0];
            bool safe = true;
            for (int i = 0; i < b.Length - 1; i++)
            {
                int d = Math.Abs(b[i + 1] - b[i]);
                if (isascending != b[i + 1] > b[i] || d < 1 || d > 3)
                {
                    safe = false;
                    break;
                }
            }
            if (safe)
            {
                result++;
            }
        }
        Console.WriteLine(result);
    }
}