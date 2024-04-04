using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GreedySnake.Draw
{
    struct Position
    {
        public int x;
        public int y;

        public Position(int x, int y) 
        {
            this.x = x;
            this.y = y;
        }
        public static bool operator ==(Position p1,Position p2)
        {
            if( p1.x == p2.x && p1.y == p2.y ) return true;
            else return false; 
        }
        public static bool operator !=(Position p1, Position p2)
        {
            if (p1.x == p2.x && p1.y == p2.y) return false;
            else return true;
        }
    }
}   
