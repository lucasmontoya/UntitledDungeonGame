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

        public void move(IList<Attributes> monster, Attributes hero, IList<IList<Obstacles>> walls, int borderX, int borderY, ConsoleColor BGColor)
        {
            for (int i = 0; i < monster.Count; i++)
            {
                Console.SetCursorPosition(monster[i].X, monster[i].Y);
                Console.ForegroundColor = ConsoleColor.Black;
                Console.BackgroundColor = BGColor;
                Console.Write(" ");

                if (monster[i].X > hero.X)
                {
                    monster[i].X -= 1;
                    if (collision.checkMonsterWall(monster, walls, borderX, borderY))
                    {
                        monster[i].X += 1;
                    }
                }

                if (monster[i].X < hero.X)
                {
                    monster[i].X += 1;
                    if (collision.checkMonsterWall(monster, walls, borderX, borderY))
                    {
                        monster[i].X -= 1;
                    }
                }
                    
                if (monster[i].Y < hero.Y)
                {
                    monster[i].Y += 1;
                    if (collision.checkMonsterWall(monster, walls, borderX, borderY))
                    {
                        monster[i].Y -= 1;
                    }
                }
                    
                if (monster[i].Y > hero.Y)
                {
                    monster[i].Y -= 1;
                    if (collision.checkMonsterWall(monster, walls, borderX, borderY))
                    {
                        monster[i].Y += 1;
                    }
                }
                    
                if (monster[i].Y.Equals(hero.Y) && monster[i].X.Equals(hero.X))
                {
                    hero.HP -= 1;
                }
            }
        }

        public void DrawMonster(IList<Attributes> monster, ConsoleColor BGColor)
        {
            for (int i = 0; i < monster.Count; i++)
            {
                Console.SetCursorPosition(monster[i].X, monster[i].Y);
                Console.BackgroundColor = BGColor;
                Console.ForegroundColor = monster[i].Color;
                Console.Write(monster[i].Symbol);
            }
        }

        public int GetMonster(IList<Attributes> monster, Attributes hero)
        {
            for (int i = 0; i < monster.Count; i++)
            {
                if (monster[i].X.Equals(hero.X) && monster[i].Y.Equals(hero.Y))
                {
                    return i;
                }
            }
            return -1;
        }
    }
}
