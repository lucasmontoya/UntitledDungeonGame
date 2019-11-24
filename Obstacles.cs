using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DungeonGame
{
    class Obstacles
    {
        public int X { get; set; }
        public int X2 { get; set; }
        public int Y { get; set; }
        public ConsoleColor Color { get; set; }
        public string Size{get; set;}
        

        public Obstacles(int x,int x2, int y, ConsoleColor color)
        {
            X = x;
            X2 = x2;
            Y = y;
            Color = color;
        }
    }
}
