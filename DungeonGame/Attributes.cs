using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DungeonGame
{
    class Attributes
    {
        public string Name { get; }
        public int HP { get; set; }
        public int AP { get; set; }
        public int X { get; set; }
        public int Y { get; set; }
        public ConsoleColor Color { get; set; }
        public string Symbol { get; set; }
        
        public Attributes (String name, int hp, int ap, int x, int y, ConsoleColor color, String symbol)
        {
            Name = name;
            HP = hp;
            AP = ap;
            X = x;
            Y = y;
            Color = color;
            Symbol = symbol;
        }
    }
}
