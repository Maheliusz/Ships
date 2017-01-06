using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Ships
{
    class Mapper
    {
        public String drawShots(List<Ship>ships, bool[,] shotMap)
        {
            String res = "";
            bool[,] shipMap = new bool[10,10];
            foreach (Ship ship in ships) shipMap[ship.x, ship.y] = true;
            for (int i = 9; i >=0; i--)
            {
                res += i.ToString();
                for (int j = 0; j < 10; j++)
                {
                    if (shipMap[i,j] && shotMap[i,j]) res += " x";
                    else if (shotMap[i,j] && !shipMap[i,j]) res += " o";
                    else res += " -";
                }
                res += "\n";
            }
            res += "\\ 0 12 34 56 78 9\n";
            return res;
        }

        public String drawShips(List<Ship>ships, bool[,] shotMap)
        {
            String res = "";
            bool[,] shipMap = new bool[10, 10];
            foreach (Ship ship in ships) shipMap[ship.x, ship.y] = true;
            for (int i = 9; i >=0; i--)
            {
                res += i.ToString();
                for (int j = 0; j < 10; j++)
                {
                    if (shipMap[i,j] && shotMap[i,j]) res += " x";
                    else if (shotMap[i,j] && !shipMap[i,j]) res += " o";
                    else if (shipMap[i,j]) res += " s";
                    else res += " -";
                }
                res += "\n";
            }
            res += "\\ 0 12 34 56 78 9\n";
            return res;
        }

        public static String noMap()
        {
            String res = "";
            for(int i=0; i<10; i++)
            {
                res += (9 - i).ToString();
                for(int j=0; j<10; j++)
                {
                    res += " -";
                }
                res += "\n";
            }
            res += "\\ 0 12 34 56 78 9\n";
            return res;
        }
    }
}
