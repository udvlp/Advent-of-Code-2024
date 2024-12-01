namespace AoC;

internal class Program
{
    static void Main()
    {
        List<int> left = [];
        Dictionary<int, int> right = [];
        var sr = new StreamReader(@"..\..\input.txt");
        int result = 0;
        while (!sr.EndOfStream)
        {
            var line = sr.ReadLine();
            var a = line.Split("   ");
            left.Add(int.Parse(a[0]));
            int rv = int.Parse(a[1]);
            if (right.TryGetValue(rv, out int count))
            {
                right[rv] = count + 1;
            }
            else
            {
                right[rv] = 1;
            }
        }
        left.Sort();
        for (int i = 0; i < left.Count; i++)
        {
            if (right.TryGetValue(left[i], out int count))
            {
                result += count * left[i];
            }
        }
        Console.WriteLine(result);
    }
}