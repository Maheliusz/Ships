using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ships
{
    class Player
    {
        public List<Ship> ships;
        public bool[,] shotMap; //0 - nie strzelano w dane pole, 1 - strzelano w dane pole
        public Player()
        {
            ships = new List<Ship>();
            shotMap = new bool[10,10];
            
            for (int i = 0; i < 10; i++)
            {
                for (int j = 0; j < 10; j++)
                {
                    shotMap[i,j] = false;
                }
            }
        }

        public bool isShipThere(int x, int y)
        {
            foreach(Ship ship in ships)
            {
                if (ship.x == x && ship.y == y) return true;
            }
            return false;
        }

        public void shootAt(int x, int y)
        {
            shotMap[x,y] = true;
        }
        
    }
}
