using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
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
        private ConsoleColor mainGridBackgroundClr;
        private ConsoleColor mainGridWallClr;
        private int wallArraySize = 4;
        private IList<Attributes> listOfMonsters = new List<Attributes>();
        private Monster monsters = new Monster();
        private IList<IList<Obstacles>> allWalls = new List<IList<Obstacles>>();
        private Collision collisions = new Collision();
        private IList<Obstacles> topWall = new List<Obstacles>();
        private IList<Obstacles> bottomWall = new List<Obstacles>();
        private IList<Obstacles> rightWall = new List<Obstacles>();
        private IList<Obstacles> leftWall = new List<Obstacles>();
        private IList<string> asciiArt = new List<string>();
        private Battle NewBattle = new Battle();
        private Player hero = new Player();
        Random rand = new Random();
        Display display = new Display();
        System.Media.SoundPlayer player = new System.Media.SoundPlayer(@"Scream And Die Fx-SoundBible.com-299479967.wav");
        System.Media.SoundPlayer evilLaugh = new System.Media.SoundPlayer(@"Evil Laugh-SoundBible.com-874992221.wav");


        public void setup ()
        {
            display.Setup();
            startGame();
        }
        /// <summary>
        /// Starts the game by initiating all the components and running the data.
        /// In particular it initializes the player, monsters, walls, item locations, 
        /// and the door.
        /// It also calls the display methods to print the walls and grid.
        /// </summary>
        public void startGame()
        {
            Keys keys = new Keys();
            mainGridBackgroundClr = ConsoleColor.Black;
            mainGridWallClr = ConsoleColor.Gray;
            Console.SetCursorPosition(6, 6);
            Attributes character = new Attributes(name, 5, 20,Console.CursorLeft,Console.CursorTop,ConsoleColor.Green,"H");
            
            createWalls(wallArraySize);
            createMonsters(15);
            display.DrawRectangle(gridXLength, gridYHeight,leftMargin,topMargin,mainGridWallClr,mainGridBackgroundClr);
            display.drawWalls(allWalls, mainGridBackgroundClr);
            display.SetStatScreen((gridXLength + 5), topMargin, 35, 20, ConsoleColor.DarkBlue, ConsoleColor.Black, character);
            

            while (gameOver == false)
            {
                Console.CursorVisible = false;
                
                hero.DrawHero(character, mainGridBackgroundClr);
                monsters.DrawMonster(listOfMonsters, mainGridBackgroundClr);
                
                if (Console.KeyAvailable)
                {
                    // Allows the player to move two spaces before the monsters move.
                    for(int i = 0; i < 2; i++)
                    {
                        hero.move(keys.ProcessKey(), allWalls, gridXLength, gridYHeight, listOfMonsters, character,mainGridBackgroundClr);
                        //NewBattle.MonsterBattle(character, listOfMonsters, monsters.GetMonster(listOfMonsters, character));
                        if (collisions.CheckHeroMon(listOfMonsters, character))
                        {
                            //display.DrawRectangle(gridXLength, gridYHeight, leftMargin, topMargin, ConsoleColor.DarkRed, ConsoleColor.DarkCyan);
                            //display.SetBattleScreen(gridXLength, topMargin, asciiArt);
                        }
                            

                        display.SetStatScreen((gridXLength + 5), topMargin, 35, 20, ConsoleColor.DarkBlue, ConsoleColor.Black, character);
                       if(character.HP <= 0)
                       {
                            player.Play();
                            Thread.Sleep(2000);
                            evilLaugh.Play();
                            Thread.Sleep(3000);
                            Console.Clear();
                            display.Setup();
                       }
                    }
                    monsters.move(listOfMonsters, character,allWalls,gridXLength,gridYHeight, mainGridBackgroundClr);
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

            for(int i = 0; i < topWallSize; i ++)
            {
                topWall.Add(new Obstacles(randWallX, randWallX + 1, (topMargin + 1) + i, ConsoleColor.Gray));
            }
            allWalls.Add(topWall);

            randWallX = rand.Next((leftMargin + 5), ((leftMargin + gridXLength) - 5));
            for (int i = 0; i < bottomWallSize; i++)
            {
                if (collisions.checkWall(allWalls, randWallX, ((topMargin - 2) + gridYHeight) - i))
                {
                    break;
                }
                bottomWall.Add(new Obstacles(randWallX, randWallX + 1, ((topMargin - 2) + gridYHeight) - i, ConsoleColor.Gray));
            }
            allWalls.Add(bottomWall);

            for (int i = 0; i < rightWallSize; i++)
            {
                if (collisions.checkWall(allWalls, (leftMargin + gridXLength) - i, randWallY))
                {
                    break;
                }
                rightWall.Add(new Obstacles((leftMargin + gridXLength) - i, ((leftMargin + gridXLength) - i), randWallY, ConsoleColor.Gray));
            }
            allWalls.Add(rightWall);

            randWallY = rand.Next((topMargin + 5), ((topMargin + gridYHeight) - 5));
            for (int i = 0; i < leftWallSize; i++)
            {
                if (collisions.checkWall(allWalls, (leftMargin + 1) + i, randWallY))
                {
                    break;
                }
                leftWall.Add(new Obstacles((leftMargin + 1) + i, (leftMargin + 1) + i, randWallY, ConsoleColor.Gray));
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
                    for(int k = 0; k < allWalls[j].Count; k++)
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
