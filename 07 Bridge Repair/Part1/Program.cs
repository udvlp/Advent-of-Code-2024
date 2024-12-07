namespace AoC;

internal class Program
{
	static void Main()
	{
		var sr = new StreamReader(@"..\..\input.txt");
		ulong result = 0;
		while (!sr.EndOfStream)
		{
			var line = sr.ReadLine();
			var parts = Array.ConvertAll(line.Split([' ', ':'], StringSplitOptions.RemoveEmptyEntries), ulong.Parse);

			bool Evaluate(int i, ulong v)
			{
				if (i >= parts.Length)
				{
					return (v == parts[0]);
				}
				else
				{
					return
						Evaluate(i + 1, parts[i] + v) ||
						Evaluate(i + 1, parts[i] * v);
				}
			}

			if (Evaluate(2, parts[1])) result += parts[0];
		}
		Console.WriteLine(result);
	}
}
