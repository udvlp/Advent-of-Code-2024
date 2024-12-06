namespace AoC;

internal class Program
{
    enum Direction { Up, Right, Down, Left }

    static void Main(string[] args)
    {
        var map = File.ReadAllLines(@"..\..\input.txt");
        int x = -1;
        int y = -1;
        int w = map[0].Length;
        int h = map.Length;
        Direction dir = Direction.Up;
        HashSet<(int, int)> visited = new();

        for (int iy = 0; iy < map.Length; iy++)
        {
            for (int ix = 0; ix < map[iy].Length; ix++)
            {
                if (map[iy][ix] == '^')
                {
                    x = ix;
                    y = iy;
                }
            }
        }

        while (x >= 0 && y >= 0 && x < w && y < h)
        {
            visited.Add((x, y));
            if (dir == Direction.Up)
            {
                if (y > 0 && map[y - 1][x] == '#')
                {
                    dir = Direction.Right;
                }
                else
                {
                    y--;
                }
            }
            else if (dir == Direction.Right)
            {
                if (x < w - 1 && map[y][x + 1] == '#')
                {
                    dir = Direction.Down;
                }
                else 
                {
                    x++;
                }
            }
            else if (dir == Direction.Down)
            {
                if (y < h - 1 && map[y + 1][x] == '#')
                {
                    dir = Direction.Left;
                }
                else 
                {
                    y++;
                }
            }
            else if (dir == Direction.Left)
            {
                if (x > 0 && map[y][x - 1] == '#')
                {
                    dir = Direction.Up;
                }
                else 
                {
                    x--;
                }
            }
        }
        Console.WriteLine(visited.Count);
    }
}