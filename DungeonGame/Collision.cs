using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DungeonGame
{
    class Collision
    {
        /// <summary>
        /// Checks whether or not the hero is touching a border or wall.
        /// </summary>
        /// <param name="heroX"></param>
        /// <param name="heroY"></param>
        /// <param name="walls"></param>
        /// <returns></returns>
        public bool checkHeroWall(int heroX, int heroY, IList<Obstacles[]> walls, int borderX, int borderY)
        {
            // Checks if Hero is touching a wall (not border)
            for (int i = 0; i < walls.Count; i++)
            {
                for(int j = 0; j < walls[i].Length; j++)
                if (heroX.Equals(walls[i][j].X) && heroY.Equals(walls[i][j].Y) || heroX.Equals(walls[i][j].X2) && heroY.Equals(walls[i][j].Y))
                    return true;
            }
            // Checks Top border
            for(int i = 0; i < (borderX + 5); i++)
            {
                if (heroX.Equals(i) && heroY.Equals(5)) // I don't like hardcoding 5
                    return true;
            }

            // Checks Bottom border
            for (int i = 0; i < (borderX + 5); i++)
            {
                if (heroX.Equals(i) && heroY.Equals(borderY + 4)) // I don't like hardcoding 4.
                    return true;
            }

            // Checks Left border
            for (int i = 0; i < (borderY + 5); i++)
            {
                if (heroX.Equals(5) && heroY.Equals(i)) // I don't like hardcoding 5.
                    return true;
            }

            // Checks Right border
            for (int i = 0; i < (borderY + 5); i++)
            {
                if (heroX.Equals(borderX + 5) && heroY.Equals(i)) // I don't like hardcoding 5.
                    return true;
            }
            return false;
        }

        /// <summary>
        /// Checks if a monster and hero are on the same X Y position. 
        /// If so it returns true. This will start a battle.
        /// </summary>
        /// <param name="monster"></param>
        /// <param name="heroX"></param>
        /// <param name="heroY"></param>
        /// <returns></returns>
        public bool checkHeroMon(IList<Attributes> monster, int heroX, int heroY)
        {
            for (int i = 0; i < monster.Count; i++)
            {
                if (heroX.Equals(monster[i].X) && heroY.Equals(monster[i].Y))
                    return true;
            }
            return false;
        }

        /// <summary>
        /// Checks to see if the monster is at the same position a the wall.
        /// If the monster is at the same position as a wall, the monster can't pass.
        /// </summary>
        /// <param name="monster"></param>
        /// <param name="heroX"></param>
        /// <param name="heroY"></param>
        /// <param name="walls"></param>
        /// <param name="borderX"></param>
        /// <param name="borderY"></param>
        /// <returns></returns>
        public bool checkMonsterWall(IList<Attributes> monster, int heroX, int heroY, IList<Obstacles[]> walls, int borderX, int borderY)
        {
            // Checks Top Border
            for (int i = 0; i < (borderX + 5); i++)
            {
                for(int j = 0; j < monster.Count; j++)
                if (monster[j].X.Equals(i) && monster[j].Equals(5)) // I don't like hardcoding 5
                    return true;
            }

            // Checks Bottom Border
            for (int i = 0; i < (borderX + 5); i++)
            {
                for (int j = 0; j < monster.Count; j++)
                    if (monster[j].X.Equals(i) && monster[j].Equals(borderY + 4)) 
                        return true;
            }

            // Checks Left border
            for (int i = 0; i < (borderY + 5); i++)
            {
                for (int j = 0; j < monster.Count; j++)
                    if (monster[j].X.Equals(5) && monster[j].Equals(i))
                        return true;
            }

            // Checks Right border
            for (int i = 0; i < (borderY + 5); i++)
            {
                for (int j = 0; j < monster.Count; j++)
                    if (monster[j].X.Equals(borderX + 5) && monster[j].Equals(i))
                        return true;
            }

            // Checks if a monstser is touching another monster
            for (int i = 0; i < monster.Count; i++)
            {
                for(int j = 0; j < monster.Count - 1; j++)
                {
                    if(i!=j)
                    {
                        if (monster[i].X.Equals(monster[j].X) && monster[i].Y.Equals(monster[j].Y))
                            return true;
                    }
                }
            }

            // Checks if monster is touching a wall (not border)
            for (int i = 0; i < walls.Count; i++)
            {
                for (int j = 0; j < walls[i].Length; j++)
                {
                    for (int k = 0; k < monster.Count; k++)
                    {
                        // Changed this TODO
                        if (monster[k].X.Equals(walls[i][j].X) && monster[k].Y.Equals(walls[i][j].Y) || monster[k].X.Equals(walls[i][j].X2) && monster[k].Y.Equals(walls[i][j].Y))
                            return true;
                    }
                }
            }
            return false;
        }

        /// <summary>
        /// Checks if the walls are touching other walls before it actually 
        /// saves or prints the wall. This also checks to make sure that each 
        /// wall has an opening to allow monsters or players to get through.
        /// </summary>
        /// <param name="walls"></param>
        /// <param name="wallX"></param>
        /// <param name="wallY"></param>
        /// <returns></returns>
        public bool checkWall(IList<Obstacles[]> walls, int wallX, int wallY)
        {
            for (int i = 0; i < walls.Count; i++)
            {
                for (int j = 0; j < walls[i].Length; j++)
                {
                    for (int k = 0; k < 10; k++)
                    {
                        if (walls[i][j].X.Equals(wallX) && walls[i][j].Y.Equals(wallY))
                            return true;
                        if(walls[i][j].X2.Equals(wallX) && walls[i][j].Y.Equals(wallY))
                            return true;
                        if ((walls[i][j].X.Equals(wallX + 1) && walls[i][j].Y.Equals(wallY + 1)) || (walls[i][j].X.Equals(wallX + 1) && walls[i][j].Y.Equals(wallY - 1)))
                            return true;
                        if ((walls[i][j].X.Equals(wallX - 1) && walls[i][j].Y.Equals(wallY + 1)) || (walls[i][j].X.Equals(wallX - 1) && walls[i][j].Y.Equals(wallY - 1)))
                            return true;
                        if ((walls[i][j].X.Equals(wallX - 1) && walls[i][j].Y.Equals(wallY + 1)) || (walls[i][j].X.Equals(wallX + 1) && walls[i][j].Y.Equals(wallY + 1)))
                            return true;
                        if ((walls[i][j].X.Equals(wallX + 1) && walls[i][j].Y.Equals(wallY - 1)) || (walls[i][j].X.Equals(wallX - 1) && walls[i][j].Y.Equals(wallY - 1)))
                            return true;
                        if ((walls[i][j].X2.Equals(wallX + 1) && walls[i][j].Y.Equals(wallY - 1)) || (walls[i][j].X2.Equals(wallX + 1) && walls[i][j].Y.Equals(wallY + 1)))
                            return true;
                        if ((walls[i][j].X2.Equals(wallX - 1) && walls[i][j].Y.Equals(wallY + 1)) || (walls[i][j].X2.Equals(wallX - 1) && walls[i][j].Y.Equals(wallY - 1)))
                            return true;
                        if ((walls[i][j].X2.Equals(wallX - 1) && walls[i][j].Y.Equals(wallY + 1)) || (walls[i][j].X2.Equals(wallX + 1) && walls[i][j].Y.Equals(wallY + 1)))
                            return true;
                        if ((walls[i][j].X2.Equals(wallX - 1) && walls[i][j].Y.Equals(wallY - 1)) || (walls[i][j].X2.Equals(wallX + 1) && walls[i][j].Y.Equals(wallY - 1)))
                            return true;
                    }
                }
            }
            return false;
        }
    }
}
