namespace AoC;

internal class PageComparer : IComparer<int>
{
	public int Compare(int x, int y) => x.CompareTo(y);
}

internal class Program
{
	static void Main()
	{
		var sr = new StreamReader(@"..\..\input.txt");
		int result = 0;
		Dictionary<int, List<int>> order = [];

		while (!sr.EndOfStream)
		{
			var line = sr.ReadLine();
			if (line == "") break;
			var parts = Array.ConvertAll(line.Split("|"), int.Parse);
			if (order.TryGetValue(parts[0], out var list))
			{
				list.Add(parts[1]);
			}
			else
			{
				order.Add(parts[0], [parts[1]]);
			}
		}

		while (!sr.EndOfStream)
		{
			var line = sr.ReadLine();
			var parts = Array.ConvertAll(line.Split(","), int.Parse);
			bool valid = true;
			for (int i = 0; i < parts.Length && valid; i++)
			{
				if (order.TryGetValue(parts[i], out var list))
				{
					foreach (var n in list)
					{
						int f = Array.IndexOf(parts, n);
						if (f >= 0 && f < i)
						{
							valid = false;
							break;
						}
					}
				}
			}
			if (!valid)
			{
				Array.Sort(parts, (int a, int b) =>
				{
					if (order.TryGetValue(a, out var list) && list.Contains(b))
					{
						return -1;
					}
					if (order.TryGetValue(b, out list) && list.Contains(a))
					{
						return 1;
					}
					return 0;
				});
				result += parts[parts.Length / 2];
			}
		}

		Console.WriteLine(result);
	}
}