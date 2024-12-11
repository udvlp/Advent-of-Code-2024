namespace AoC;

internal class Program
{
	static void Main()
	{
		long result = 0;
		List<int> list = [];

		var sr = new StreamReader(@"..\..\input.txt");
		var line = sr.ReadLine();

		int k = 0;
		for (int i = 0; i < line.Length; i++)
		{
			int n = line[i] - '0';
			if (i % 2 == 0)
			{
				for (int j = 0; j < n; j++) list.Add(k);
				k++;
			}
			else
			{
				for (int j = 0; j < n; j++) list.Add(-1);
			}
		}

		int p = 0;
		int q = list.Count - 1;
		while (true)
		{
			bool ok = false;
			for (int j = p; j < q; j++)
			{
				if (list[j] == -1)
				{
					p = j;
					ok = true;
					break;
				}
			}
			if (!ok) break;
			for (int j = q; j >= p; j--)
			{
				if (list[j] != -1)
				{
					q = j;
					ok = true;
					break;
				}
			}
			if (!ok) break;
			list[p] = list[q];
			list[q] = -1;
		}

		for (int i = 0; i < list.Count; i++)
		{
			if (list[i] >= 0)
			{
				result += (long)i * list[i];
			}
		}

		Console.WriteLine(result);
	}
}