namespace AoC;

internal class Program
{
    enum Direction { Up, Right, Down, Left }

    static void Main(string[] args)
    {
        int result = 0;
        var map = File.ReadAllLines(@"..\..\input.txt");
        int sx = -1;
        int sy = -1;
        int w = map[0].Length;
        int h = map.Length;

        for (int iy = 0; iy < map.Length; iy++)
        {
            for (int ix = 0; ix < map[iy].Length; ix++)
            {
                if (map[iy][ix] == '^')
                {
                    sx = ix;
                    sy = iy;
                    break;
                }
            }
        }

        for (int oy = 0; oy < h; oy++)
        {
            for (int ox = 0; ox < w; ox++)
            {
                if (ox == sx && oy == sy) continue;

                Direction dir = Direction.Up;
                HashSet<(int, int, Direction)> visited = new();
                int x = sx;
                int y = sy;

                bool isObstacle(int x, int y)
                {
                    return map[y][x] == '#' || (x == ox && y == oy);
                }

                while (x >= 0 && y >= 0 && x < w && y < h)
                {
                    if (!visited.Add((x, y, dir)))
                    {
                        result++;
                        break;
                    }
                    if (dir == Direction.Up)
                    {
                        if (y > 0 && isObstacle(x, y - 1))
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
                        if (x < w - 1 && isObstacle(x + 1, y))
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
                        if (y < h - 1 && isObstacle(x, y + 1))
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
                        if (x > 0 && isObstacle(x - 1, y))
                        {
                            dir = Direction.Up;
                        }
                        else
                        {
                            x--;
                        }
                    }
                }

            }
        }
        Console.WriteLine(result);
    }
}