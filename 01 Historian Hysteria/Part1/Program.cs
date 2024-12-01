namespace AoC;

internal class Program
{
    static void Main()
    {
        List<int> l1 = [];
        List<int> l2 = [];

        var sr = new StreamReader(@"..\..\input.txt");
        int result = 0;
        while (!sr.EndOfStream)
        {
            var line = sr.ReadLine();
            var a = line.Split("   ");
            l1.Add(int.Parse(a[0]));
            l2.Add(int.Parse(a[1]));
        }
        l1.Sort();
        l2.Sort();
        for (int i = 0; i < l1.Count; i++)
        {
            var d = (Math.Abs(l1[i] - l2[i]));
            result += d;
        }
        Console.WriteLine(result);
    }
}