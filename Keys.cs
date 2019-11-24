using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DungeonGame
{
    class Keys
    {
        public enum Direction
        {
            Up,
            Down,
            Left,
            Right
        }

        /// <summary>
        /// Tracks which key is pressed
        /// </summary>
        /// <returns></returns>
        public Direction ProcessKey()
        {
            ConsoleKey key = Console.ReadKey(true).Key;
            switch (key)
            {
                case ConsoleKey.LeftArrow:
                    return Direction.Left;
                case ConsoleKey.RightArrow:
                    return Direction.Right;
                case ConsoleKey.UpArrow:
                    return Direction.Up;
                case ConsoleKey.DownArrow:
                    return Direction.Down;
                case ConsoleKey.Enter:
                    return Direction.Right;
                default:
                    return 0;
            }
        }
    }
}
