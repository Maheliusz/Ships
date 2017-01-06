using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ships
{
    class Ship
    {
        public int x;
        public int y;
        public String name;
        public Ship(int x, int y, String name)
        {
            this.x = x;
            this.y = y;
            this.name = name;
        }
        public Ship(int x, int y)
        {
            this.x = x;
            this.y = y;
            name = "Statek(" + x.ToString() + "," + y.ToString() + ")";
        }
    }
}
