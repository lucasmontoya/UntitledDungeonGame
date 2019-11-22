using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DungeonGame
{
    class Player
    {
        Attributes Hero;
        Collision collision = new Collision();

        public Player(string name, int hp, int ap,int x, int y, ConsoleColor color, string symbol)
        {
            Hero = new Attributes(name, hp, ap, x, y,color, symbol);
        }

        /// <summary>
        /// Check to see if the new coodrdinates the player is moving in
        /// collide with a wall. If so, the player doesn't move beyond the wall.
        /// If not, the player moves 1 space in that direction.
        /// Right now the monster is not used, but I will keep it there for now 
        /// in case in the future we need it.
        /// </summary>
        /// <param name="d"></param>
        /// <param name="walls"></param>
        public void move(Keys.Direction d, IList<Obstacles[]> walls, int x, int y, IList<Attributes> monster)
        {
            // remove the IList if it is never used.-----------------------------------^

            Console.SetCursorPosition(Hero.X, Hero.Y);
            Console.ForegroundColor = ConsoleColor.Black;
            Console.Write(" ");

            if (d == Keys.Direction.Down)
            {
                Hero.Y += 1;
                if (collision.checkHeroWall(Hero.X, Hero.Y, walls, x, y))
                {
                    Hero.Y -= 1;
                }
            }
            if (d == Keys.Direction.Up)
            {
                Hero.Y -= 1;
                if (collision.checkHeroWall(Hero.X, Hero.Y, walls, x, y))
                {
                    Hero.Y += 1;
                }
            }
            if (d == Keys.Direction.Left)
            {
                Hero.X -= 1;
                if (collision.checkHeroWall(Hero.X, Hero.Y, walls, x, y))
                {
                    Hero.X += 1;
                }
            }
            if (d == Keys.Direction.Right)
            {
                Hero.X += 1;
                if (collision.checkHeroWall(Hero.X, Hero.Y, walls, x, y))
                {
                    Hero.X -= 1;
                }
            }            

            DrawHero();
        }

        /// <summary>
        /// Draws the hero in the new location after the User chooses a direction
        /// and passes the collision check.
        /// </summary>
        public void DrawHero()
        {
            Console.SetCursorPosition(Hero.X, Hero.Y);
            Console.ForegroundColor = Hero.Color;
            Console.Write(Hero.Symbol);
        }

        /// <summary>
        /// Return the X value of the current Hero position.
        /// </summary>
        /// <returns></returns>
        public int getHeroX()
        {
            return Hero.X;
        }

        /// <summary>
        /// Return the Y value of the current Hero position.
        /// </summary>
        /// <returns></returns>
        public int getHeroY()
        {
            return Hero.Y;
        }
    }
}
