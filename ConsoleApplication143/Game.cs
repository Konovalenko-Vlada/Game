using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace ConsoleApplication143
{
    class Game
    {        
        List<Coordinate> coords = new List<Coordinate>();
        int[,] val;
        int c = 0;

        public Game(params int[] data)
        {
            if (Math.Sqrt(data.Length) % 1 != 0)
            {
                throw new ArgumentException("Error Size!!!");
            }

            for (int i = 0; i < Math.Sqrt(data.Length); i++)
            {
                for (int j = 0; j < Math.Sqrt(data.Length); j++)
                {
                    Coords[c].x = i + 1;
                    Coords[c].y = j + 1;
                    Coords[c].filled = true;
                    val[i, j] = c++;
                }
            }
        }

        public Game(params string[] data)
        {
            if (Math.Sqrt(data.Length) % 1 != 0)
            {
                throw new ArgumentException("Error Size!!!");
            }

            for (int i = 0; i < Math.Sqrt(data.Length); i++)
            {
                for (int j = 0; j < Math.Sqrt(data.Length); j++)
                {
                    Coordinate temp_Coordinate = new Coordinate();
                    temp_Coordinate.x = i++;
                    temp_Coordinate.y = j++;
                    coords[Convert.ToInt32(data[i + j])] = temp_Coordinate;

                    val[i, j] = c++;
                }
            }
        }

        public int this[int x, int y]
        {
            get
            {
                return val[x, y];
            }
        }

        public Coordinate GetLocation(int value)
        {
            return coords[value];
        }

        void Shift(int value)
        {
            Coordinate zero = GetLocation(0);
            Coordinate val = GetLocation(value);

            if (Math.Abs(zero.x - val.x) == 1 || Math.Abs(zero.y - val.y) == 1)
            {
                Coordinate prom = zero;
                zero = val;
                val = prom;
            }
            else
            {
                throw new ArgumentException("Error no empty space!!!");
            }
        }

        public static Game FromCSV(string file)
        {
            string[] data = File.ReadAllText(file).Split(';');
            return new Game(data);
        }
    }
}
