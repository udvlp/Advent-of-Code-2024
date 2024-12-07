namespace AoC;

internal class Program
{
	static ulong ConcatNumbers(ulong a, ulong b)
	{
		ulong r = 0;
		ulong s = 1;
		while (b > 0)
		{
			r += s * (b % 10);
			s *= 10;
			b /= 10;
		}
		while (a > 0)
		{
			r += s * (a % 10);
			s *= 10;
			a /= 10;
		}
		return r;
	}

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
					return v == parts[0];
				}
				else
				{
					return
						Evaluate(i + 1, v + parts[i]) ||
						Evaluate(i + 1, v * parts[i]) ||
						Evaluate(i + 1, ConcatNumbers(v, parts[i]));
				}
			}
			if (Evaluate(2, parts[1])) result += parts[0];
		}
		Console.WriteLine(result);
	}
}
