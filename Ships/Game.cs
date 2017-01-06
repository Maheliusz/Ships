using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ships
{
    class Game
    {
        public Player player1;
        public Player player2;
        private short currentPlayer;
        private short counter;
        public Game()
        {
            currentPlayer = 1;
            player1 = new Player();
            player2 = new Player();
            counter = 0;
        }
        public int getPlayer()
        {
            return currentPlayer;
        }
        public void setPlayer()
        {
            if (currentPlayer == 1) currentPlayer = 2;
            else currentPlayer = 1;
        }
        public short getCounter()
        {
            return counter;
        }
        public void count()
        {
            counter++;
        }
        
    }
}
