namespace AoC;

internal class Program
{
	static void Main()
	{
		long result = 0;
		List<(long pos, long len)> file = [];
		List<(long pos, long len)> space = [];

		var sr = new StreamReader(@"..\..\input.txt");
		var line = sr.ReadLine();

		int p = 0;
		for (int i = 0; i < line.Length; i++)
		{
			int l = line[i] - '0';
			if (i % 2 == 0)
			{
				file.Add((p, l));
			}
			else
			{
				space.Add((p, l));
			}
			p += l;
		}

		for (int i = file.Count - 1; i >= 0; i--)
		{
			var f = file[i];
			for (int j = 0; j < space.Count; j++)
			{
				var s = space[j];
				if (s.pos < f.pos && s.len >= f.len)
				{
					file[i] = (s.pos, f.len);
					space[j] = (s.pos + f.len, s.len - f.len);
					space.Add((f.pos, f.len));
					break;
				}
			}
		}

		int k = 0;
		foreach (var f in file)
		{
			result += k * f.len * (2 * f.pos + f.len - 1) / 2L;
			k++;
		}

		Console.WriteLine(result);
	}
}