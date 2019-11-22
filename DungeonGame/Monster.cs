using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DungeonGame
{
    class Monster
    {
        Collision collision = new Collision();

        public void move(IList<Attributes> monster, int x, int y, IList<Obstacles[]> walls, int borderX, int borderY)
        {
            for (int i = 0; i < monster.Count; i++)
            {
                Console.SetCursorPosition(monster[i].X, monster[i].Y);
                Console.ForegroundColor = ConsoleColor.Black;
                Console.Write(" ");

                if (monster[i].X > x)
                {
                    monster[i].X -= 1;
                    if (collision.checkMonsterWall(monster, x, y, walls, borderX, borderY))
                    {
                        monster[i].X += 1;
                    }
                }

                if (monster[i].X < x)
                {
                    monster[i].X += 1;
                    if (collision.checkMonsterWall(monster, x, y, walls, borderX, borderY))
                    {
                        monster[i].X -= 1;
                    }
                }
                    
                if (monster[i].Y < y)
                {
                    monster[i].Y += 1;
                    if (collision.checkMonsterWall(monster, x, y, walls, borderX, borderY))
                    {
                        monster[i].Y -= 1;
                    }
                }
                    
                if (monster[i].Y > y)
                {
                    monster[i].Y -= 1;
                    if (collision.checkMonsterWall(monster, x, y, walls, borderX, borderY))
                    {
                        monster[i].Y += 1;
                    }
                }
                    
                if (monster[i].Y.Equals(y) && monster[i].X.Equals(x))
                {

                }
            }
        }

        public void DrawMonster(IList<Attributes> monster)
        {
            for (int i = 0; i < monster.Count; i++)
            {
                Console.SetCursorPosition(monster[i].X, monster[i].Y);
                Console.ForegroundColor = monster[i].Color;
                Console.Write(monster[i].Symbol);
            }

        }
    }
}
