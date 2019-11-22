using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace DungeonGame
{
    class Game
    {
        // TODO make this something that the player can input.
        private string name = "Doofus";
        private bool gameOver = false;
        // Can we make this values static since they don't change for the rest of the game?
        private int gridXLength = 60;
        private int gridYHeight = 20;
        private int leftMargin = 5;
        private int topMargin = 5;
        private int monX;
        private int monY;
        private int wallArraySize = 4;
        private IList<Attributes> listOfMonsters = new List<Attributes>();
        private Monster monsters = new Monster();
        private IList<Obstacles[]> allWalls = new List<Obstacles[]>();
        private Collision collisions = new Collision();
        private Obstacles[] topWall;
        private Obstacles[] rightWall;
        private Obstacles[] bottomWall;
        private Obstacles[] leftWall;
        Random rand = new Random();
        System.Media.SoundPlayer player = new System.Media.SoundPlayer(@"Scream And Die Fx-SoundBible.com-299479967.wav");


        /// <summary>
        /// Starts the game by initiating all the components and running the data.
        /// In particular it initializes the player, monsters, walls, item locations, 
        /// and the door.
        /// It also calls the display methods to print the walls and grid.
        /// </summary>
        public void startGame()
        {
            Display display = new Display();
            Keys keys = new Keys();
            Console.SetCursorPosition(10, 10);
            Player Person = new Player(name, 20, 20,Console.CursorLeft,Console.CursorTop,ConsoleColor.Green,"H");
            
            createWalls(wallArraySize);
            createMonsters(8);
            display.drawWalls(allWalls);
            display.DrawMainGrid(gridXLength, gridYHeight);

            while (gameOver == false)
            {
                Console.CursorVisible = false;
                
                Person.DrawHero();
                monsters.DrawMonster(listOfMonsters);
                
                if (Console.KeyAvailable)
                {
                    // Allows the player to move two spaces before the monsters move.
                    for(int i = 0; i < 2; i++)
                    {
                        Person.move(keys.ProcessKey(), allWalls, gridXLength, gridYHeight, listOfMonsters);
                        if(collisions.checkHeroMon(listOfMonsters, Person.getHeroX(), Person.getHeroY()))
                        {
                            //startBattle();
                            player.Play();
                        }
                    }
                    monsters.move(listOfMonsters, Person.getHeroX(), Person.getHeroY(),allWalls,gridXLength,gridYHeight);
                }    
            }
        }

        /// <summary>
        /// Creates 4 arrays of obstacles: Top, Bottom, Left, and Right.
        /// Each Wall has an array of Obstacles that have an X,Y position and size.
        /// After each wall is checked for collision then it fills the wall into
        /// the allWalls list to print.
        /// </summary>
        public void createWalls(int size)
        {
            //TODO find a better way to go through this.

            int topWallSize = rand.Next((int)(Math.Round(gridYHeight * .20)), (int)(Math.Round(gridYHeight *.70)));
            int bottomWallSize = rand.Next((int)(Math.Round(gridYHeight * .20)), (int)(Math.Round(gridYHeight * .70)));
            int leftWallSize = rand.Next((int)(Math.Round(gridXLength *.20)) , (int)Math.Round(gridXLength * .70));
            int rightWallSize = rand.Next((int)(Math.Round(gridXLength * .20)), (int)Math.Round(gridXLength * .70));
            int randWallX = rand.Next((leftMargin +5),((leftMargin + gridXLength) - 5));
            int randWallY = rand.Next((topMargin + 5), ((topMargin + gridYHeight) - 5));

            topWall = new Obstacles[topWallSize];
            for(int i = 0; i < topWallSize; i ++)
            {
                topWall[i] = new Obstacles(randWallX, randWallX + 1, (topMargin + 1) + i, ConsoleColor.Gray);
            }
            allWalls.Add(topWall);

            bottomWall = new Obstacles[bottomWallSize];
            randWallX = rand.Next((leftMargin + 5), ((leftMargin + gridXLength) - 5));
            for (int i = 0; i < bottomWallSize; i++)
            {
                if(collisions.checkWall(allWalls, randWallX, ((topMargin - 2) + gridYHeight) - i))
                {
                    while (collisions.checkWall(allWalls, randWallX, ((topMargin - 2) + gridYHeight) - i))
                    {
                        randWallX = rand.Next((leftMargin + 5), ((leftMargin + gridXLength) - 5));
                        i = 0;
                    }
                }
                bottomWall[i] = new Obstacles(randWallX, randWallX + 1,((topMargin-2) + gridYHeight) - i, ConsoleColor.Gray);
            }
            allWalls.Add(bottomWall);

            rightWall = new Obstacles[rightWallSize];
            for (int i = 0; i < rightWallSize; i++)
            {
                if(collisions.checkWall(allWalls, (leftMargin + gridXLength) - i, randWallY))
                {
                    while (collisions.checkWall(allWalls, (leftMargin + gridXLength) - i, randWallY))
                    {
                        randWallY = rand.Next((topMargin + 5), ((topMargin + gridYHeight) - 5));
                        i = 0;
                    }
                }
                
                rightWall[i] = new Obstacles((leftMargin + gridXLength) - i, ((leftMargin + gridXLength) - i), randWallY, ConsoleColor.Gray);
            }
            allWalls.Add(rightWall);

            leftWall = new Obstacles[leftWallSize];
            randWallY = rand.Next((topMargin + 5), ((topMargin + gridYHeight) - 5));
            for (int i = 0; i < leftWallSize; i++)
            {
                if(collisions.checkWall(allWalls, (leftMargin + 1) + i, randWallY))
                {
                    while (collisions.checkWall(allWalls, (leftMargin + 1) + i, randWallY))
                    {
                        randWallY = rand.Next((topMargin + 5), ((topMargin + gridYHeight) - 5));
                        i = 0;
                    }
                }

                leftWall[i] = new Obstacles((leftMargin + 1) + i, (leftMargin + 1) + i, randWallY, ConsoleColor.Gray);
            }
            allWalls.Add(leftWall);
        }

        /// <summary>
        /// Creates a list of Attributes which is filled by monsters. 
        /// May need to change this to work move() and Draw()
        /// </summary>
        /// <param name="size"></param>
        public void createMonsters(int size)
        {
            for (int i = 0; i < size; i++)
            {
                monX = rand.Next((leftMargin + 1), (gridXLength - 1));
                monY = rand.Next((topMargin + 1), (gridYHeight - 1));

                // Checks to make sure the random X and Y location is not the same as a wall.
                for (int j = 0; j < allWalls.Count; j++)
                {
                    for(int k = 0; k < allWalls[j].Length; k++)
                    {
                        
                        if(monX.Equals(allWalls[j][k].X) && monY.Equals(allWalls[j][k].Y) || monX.Equals(allWalls[j][k].X2) && monY.Equals(allWalls[j][k].Y))
                        {
                            while(monX.Equals(allWalls[j][k].X) && monY.Equals(allWalls[j][k].Y) || monX.Equals(allWalls[j][k].X2) && monY.Equals(allWalls[j][k].Y))
                            {
                                monX = rand.Next((leftMargin + 1), (gridXLength - 1));
                                monY = rand.Next((topMargin + 1), (gridYHeight - 1));
                            }
                        }
                    }
                }
                listOfMonsters.Add(new Attributes("Kill me", 20, 20, monX, monY, ConsoleColor.Red, "M"));
            }
        }
    }
}
