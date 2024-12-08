namespace AoC;

internal class Program
{
	static void Main(string[] args)
	{
		var lines = File.ReadAllLines(@"..\..\input.txt");
		int width = lines[0].Length;
		int height = lines.Count();

		Dictionary<char, List<(int x, int y)>> map = new();
		HashSet<(int x, int y)> locations = new();

		for (int y = 0; y < height; y++)
		{
			for (int x = 0; x < width; x++)
			{
				if (lines[y][x] != '.')
				{
					if (map.TryGetValue(lines[y][x], out var list))
					{
						list.Add((x, y));
					}
					else
					{
						map[lines[y][x]] = new() { (x, y) };
					}
				}
			}
		}

		foreach (var item in map)
		{
			var l = item.Value;
			for (int i = 0; i < l.Count; i++)
			{
				for (int j = 0; j < l.Count; j++)
				{
					if (i != j)
					{
						int dx = l[j].x - l[i].x;
						int dy = l[j].y - l[i].y;

						int ax = l[i].x;
						int ay = l[i].y;

						while (ax >= 0 && ax < width && ay >= 0 && ay < height)
						{
							locations.Add((ax, ay));
							ax -= dx;
							ay -= dy;
						}
					}
				}
			}
		}

		for (int y = 0; y < height; y++)
		{
			for (int x = 0; x < width; x++)
			{
				Console.Write(locations.Contains((x, y)) ? 'X' : lines[y][x]);
			}
			Console.WriteLine();
		}

		Console.WriteLine(locations.Count);
	}
}