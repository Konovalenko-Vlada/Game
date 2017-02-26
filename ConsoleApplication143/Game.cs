using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApplication143
{
    class Game
    {
        
        List<Coordinate> coords = new List<Coordinate>();

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
                    Coordinate temp_Coordinate = new Coordinate();
                    temp_Coordinate.x = i++;
                    temp_Coordinate.y = j++;
                    coords[data[i + j]] = temp_Coordinate;
                }
            }
        }

        public int this[int x, int y]
        {
            get
            {
                return coords.FindIndex(Coordinate => (Coordinate.x == x) && (Coordinate.y == y));
            }
        }

        public Coordinate getLocation(int value)
        {
            return coords[value];
        }

        void Shift(int value)
        {
            var current_Coordinate = getLocation(value);

            if (this[current_Coordinate.x + 1, current_Coordinate.y] == 0)
            {
                coords[0] = current_Coordinate;

                current_Coordinate.x++;
                coords[value] = current_Coordinate;
            } 
            else if (this[current_Coordinate.x - 1, current_Coordinate.y] == 0)
            {
                coords[0] = current_Coordinate;

                current_Coordinate.x--;
                coords[value] = current_Coordinate;
            }
            else if (this[current_Coordinate.x, current_Coordinate.y + 1] == 0)
            {
                coords[0] = current_Coordinate;

                current_Coordinate.y++;
                coords[value] = current_Coordinate;
            }
            else if (this[current_Coordinate.x, current_Coordinate.y - 1] == 0)
            {
                coords[0] = current_Coordinate;

                current_Coordinate.y--;
                coords[value] = current_Coordinate;
            }
            else
            {
                throw new ArgumentException("Error no empty space!!!");
            }
        }
    }
}
