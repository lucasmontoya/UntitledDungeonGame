using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace DungeonGame
{
    class Display
    {
        private int leftMargin = 5;
        private int topMargin = 5;

        /// <summary>
        /// Temporary solution to drawing a simple grid to test movement
        /// </summary>
        /// <param name="length"></param>
        /// <param name="height"></param>
        public void DrawMainGrid(int length, int height)
        {
            Console.SetCursorPosition(leftMargin, topMargin);
            for(int i = 0; i < height; i++)
            {
                Console.ForegroundColor = ConsoleColor.White;
                Console.CursorLeft = leftMargin;
                Console.Write("x");
                for (int j = 0; j < length; j++)
                {
                    if(i == 0 || i == height-1)
                    {
                        Console.ForegroundColor = ConsoleColor.White;
                        Console.Write("x");
                    }
                    if(j == length -1)
                    {
                        Console.CursorLeft = leftMargin + length;
                        Console.ForegroundColor = ConsoleColor.White;
                        Console.Write("x");
                    }
                }
                Console.WriteLine();
            }
        }
        
        /// <summary>
        /// Draws the wall obstacles on the map including the extra space for
        /// the walls the the Y coordinate. They need to have the extra space
        /// or they become too skinny compared to the side walls.
        /// </summary>
        /// <param name="walls"></param>
        public void drawWalls(IList<Obstacles[]> walls)
        {
            for (int i = 0; i < walls.Count; i++)
            {
                for (int j = 0; j < walls[i].Length; j++)
                {
                    Console.SetCursorPosition(walls[i][j].X, walls[i][j].Y);
                    Console.BackgroundColor = walls[i][j].Color;
                    Console.Write(" ");
                    Console.SetCursorPosition(walls[i][j].X2, walls[i][j].Y);
                    Console.BackgroundColor = walls[i][j].Color;
                    Console.Write(" ");
                    Console.BackgroundColor = ConsoleColor.Black;
                }
            }
        }

    }
}
