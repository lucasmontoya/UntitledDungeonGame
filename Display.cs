using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace DungeonGame
{
    class Display
    {
        bool done;
        int counter;
        /// <summary>
        /// Starts the music of the game and draws the start menu out.
        /// </summary>
        public void Setup()
        {
            System.Media.SoundPlayer backgroundMusic = new System.Media.SoundPlayer(@"Possible music.wav");
            backgroundMusic.PlayLooping();
            Console.SetWindowSize(120, 40);
            DrawRectangle(60, 35, 5, 2, ConsoleColor.Red, ConsoleColor.Black);
            Title(5, 5, ConsoleColor.Black, ConsoleColor.Red);
            MenuOptions(ConsoleColor.Black, ConsoleColor.White);

            while (!done)
            {
                MenuKey();
            }
        }

        /// <summary>
        /// ASCII art for the project name to be displayed when program runs.
        /// </summary>
        /// <param name="left"></param>
        /// <param name="top"></param>
        /// <param name="FGColor"></param>
        /// <param name="BGColor"></param>
        public void Title(int left, int top, ConsoleColor BGColor, ConsoleColor FGColor)
        {
            // The border is getting erased on the left side because when it makes a new line it is going all the way to the left
            // instead of starting at the left margin (5 in) we set. 
            Console.ForegroundColor = FGColor;
            Console.BackgroundColor = BGColor;
            Console.SetCursorPosition(left, top);
            Console.WriteLine(
            "\t\t                )      ) (      (\n" +
            "\t\t    (        ( /((  ( /( )\\  (  )\\ )\n" +
            "\t\t    )\\  (    )\\())\\ )\\()|(_)))\\(()/(\n" +
            "\t\t _ ((_) )\\ )(_))((_|_))/ _ /((_)((_))\n" +
            "\t\t| | | |_(_/(| |_ (_) |_ | (_))  _| |\n" +
            "\t\t| |_| | ' \\))  _|| |  _|| / -_) _` |\n" +
            "\t\t (___/|_||_| \\__||_|\\__||_\\___\\__,_|\n" +
            "\t\t)\\ )\n" +
            "\t\t(()/(    (        (  (    (\n" +
            "\t\t/(_))  ))\\  (    )\\))(  ))\\ (   (\n" +
            "\t\t(_))_  /((_) )\\ )((_))\\ /((_))\\  )\\ )\n" +
            "\t\t|   \\(_))( _(_/( (()(_|_)) ((_)_(_/(\n" +
            "\t\t| |) | || | ' \\)) _` |/ -_) _ \\ ' \\))\n" +
            "\t\t(___/ \\_,_|_||_|\\__, |\\___\\___/_||_|\n" +
            "\t\t                |___/\n" +
            "\t\t       )\\ )      )    )    (\n" +
            "\t\t      (()/(   ( /(   (     ))\\\n" +
            "\t\t       /(_))_ )(_))  )\\  '/((_)\n" +
            "\t\t      (_)) __((_)_ _((_))(_))\n" +
            "\t\t        | (_ / _` | '  \\() -_)\n" +
            "\t\t         \\___\\__,_|_|_|_|\\___|\n");
        }

        /// <summary>
        /// Menu options when program is ran.
        /// </summary>
        private void MenuOptions(ConsoleColor BGColor, ConsoleColor FGColor)
        {
            Console.BackgroundColor = BGColor;
            Console.ForegroundColor = FGColor;
            string[] menuOptions = { "Press keys 1 - 4 to Continue", "", "1. Start", "2. How to Play", "3. High Scores", "4. Exit" };
            int counter = 0;
            foreach (string s in menuOptions)
            {
                Console.SetCursorPosition((Console.WindowWidth - menuOptions[counter].Length) / 2, 28 + counter);
                Console.WriteLine(s);
                Console.WriteLine();
                counter++;
            }

        }
        /// <summary>
        /// Character Info Stats When Game is Started
        /// </summary>
        private void CharacterInfo()
        {
            // Three rectangles for character screens
            DrawRectangle(60, 8, 5, 2, ConsoleColor.Blue, ConsoleColor.Black);
            DrawRectangle(60, 8, 5, 11, ConsoleColor.Green, ConsoleColor.Black);
            DrawRectangle(60, 8, 5, 20, ConsoleColor.Red, ConsoleColor.Black);

            // Warrior
            SetCharText(10, 5, "(⌐■_■)==O");
            SetCharText(25, 4, "The Warrior!");
            SetCharText(25, 5, "HP: 100 \t AP: 15");
            SetCharText(25, 6, "Weapon: Sword \t Item: Buff Potion");

            // Wizard
            SetCharText(10, 14, "(⌐■_■)/**");
            SetCharText(25, 13, "The Wizard!");
            SetCharText(25, 14, "HP: 75 \t AP: 5");
            SetCharText(25, 15, "Weapon: Staff \t Item: Fire Scroll");

            // Hunter
            SetCharText(10, 23, "(⌐■_■)==>");
            SetCharText(25, 22, "The Hunter!");
            SetCharText(25, 23, "HP: 50 \t AP: 30");
            SetCharText(25, 24, "Weapon: Dagger\t Item: Cloak Potion");

            // Choices
            string[] select = { "Choose Your Character!", "", "Press '1' to Play as the Warrior",
                "Press '2' to Play as the Wizard", "Press '3' to Play as the Hunter" };
            int counter = 0;
            foreach (string s in select)
            {
                Console.SetCursorPosition((Console.WindowWidth - select[counter].Length) / 2, 30 + counter);
                Console.WriteLine(s);
                Console.WriteLine();
                counter++;
            }
            // Check user input
            while (!done)
            {
                CharacterKey();
            }
        }
        // How to Play Screen When Clicked on From Start Menu
        //private void HowToPlay()
        //{
        //    Console.BackgroundColor = ConsoleColor.Black;
        //    //DrawMainGrid(50, 20, 8, 4);
        //    Player Person = new Player("Trevor", 20, 20, 10, 5, ConsoleColor.Green, "H");
        //    Monster monster = new Monster("Bill", 20, 20, 15, 15, ConsoleColor.Red, "M");
        //    Person.DrawHero();
        //    monster.DrawMonster();
        //}

        /// <summary>
        /// Draw rectangles with custom length, height, leftMargin, topMargin, and color parameters.
        /// The color parameters are for the background of the walls and the background of the floor.
        /// </summary>
        /// <param name="length"></param>
        /// <param name="height"></param>
        /// <param name="left"></param>
        /// <param name="top"></param>
        /// <param name="color"></param>
        public void DrawRectangle(int length, int height, int left, int top, ConsoleColor BGColorWall, ConsoleColor BGColorFloor)
        {
            Console.SetCursorPosition(left, top);
            for (int i = 0; i < height; i++)
            {
                Console.CursorLeft = left;
                Console.BackgroundColor = BGColorWall;
                Console.Write(" ");
                for (int j = 0; j < length; j++)
                {

                    if (i == 0 || i == height - 1 || j == length - 1)
                    {
                        Console.BackgroundColor = BGColorWall;
                        Console.Write(" ");
                    }
                    else
                    {
                        Console.BackgroundColor = BGColorFloor;
                        Console.Write(" ");
                    }
                }
                Console.WriteLine();
            }
            Console.BackgroundColor = ConsoleColor.Black;
        }
        /// <summary>
        /// Draws walls for map from the IList allWalls.
        /// </summary>
        /// <param name="walls"></param>
        public void drawWalls(IList<IList<Obstacles>> walls, ConsoleColor BGColor)
        {
            for (int i = 0; i < walls.Count; i++)
            {
                for (int j = 0; j < walls[i].Count; j++)
                {
                    Console.SetCursorPosition(walls[i][j].X, walls[i][j].Y);
                    Console.BackgroundColor = walls[i][j].Color;
                    Console.Write(" ");
                    Console.SetCursorPosition(walls[i][j].X2, walls[i][j].Y);
                    Console.BackgroundColor = walls[i][j].Color;
                    Console.Write(" ");
                }

            }
        }
        /// <summary>
        /// Main Menu Screen Key Check
        /// </summary>
        private void MenuKey()
        {
            if (Console.KeyAvailable)
            {
                ConsoleKey key = Console.ReadKey(true).Key;
                if (key == ConsoleKey.D1)
                {
                    Console.Clear();
                    CharacterInfo();
                }
                if (key == ConsoleKey.D2)
                {
                    Console.Clear();
                    //HowToPlay();
                }
                if (key == ConsoleKey.D3)
                {
                    // High Score Function
                }
                if (key == ConsoleKey.D4)
                {
                    Environment.Exit(0);
                }
            }
        }
        /// <summary>
        /// Character Selection Screen Key Check
        /// </summary>
        private void CharacterKey()
        {
            Game game = new Game();
            counter = 0;
            if (Console.KeyAvailable)
            {
                ConsoleKey key = Console.ReadKey(true).Key;
                if (key == ConsoleKey.D1)
                {
                    while (counter < 5)
                    {
                        DrawRectangle(60, 8, 5, 2, ConsoleColor.White, ConsoleColor.Black);
                        Thread.Sleep(50);
                        DrawRectangle(60, 8, 5, 2, ConsoleColor.Blue, ConsoleColor.Black);
                        Thread.Sleep(50);
                        counter++;
                    }
                    Console.BackgroundColor = ConsoleColor.Black;
                    Console.Clear();
                    game.startGame();

                }
                if (key == ConsoleKey.D2)
                {
                    while (counter < 5)
                    {
                        DrawRectangle(60, 8, 5, 11, ConsoleColor.White, ConsoleColor.Black);
                        Thread.Sleep(50);
                        DrawRectangle(60, 8, 5, 11, ConsoleColor.Green, ConsoleColor.Black);
                        Thread.Sleep(50);
                        counter++;
                    }
                    Console.BackgroundColor = ConsoleColor.Black;
                    Console.Clear();
                    game.startGame();

                }
                if (key == ConsoleKey.D3)
                {
                    while (counter < 5)
                    {
                        DrawRectangle(60, 8, 5, 20, ConsoleColor.White, ConsoleColor.Black);
                        Thread.Sleep(50);
                        DrawRectangle(60, 8, 5, 20, ConsoleColor.Red, ConsoleColor.Black);
                        Thread.Sleep(50);
                        counter++;
                    }
                    Console.BackgroundColor = ConsoleColor.Black;
                    Console.Clear();
                    //game.startGame();

                }
            }
        }

        public static void SetCharText(int left, int top, string text)
        {
            Console.BackgroundColor = ConsoleColor.Black;
            Console.ForegroundColor = ConsoleColor.White;
            Console.SetCursorPosition(left, top);
            Console.Write(text);
            Console.SetCursorPosition(left, top);
        }

        /// <summary>
        /// Creates the stats screen on the right hand side with the characters current stats
        /// There's probably a much better way to do this. 
        /// </summary>
        /// <param name="rightBorderX"></param>
        /// <param name="topMargin"></param>
        /// <param name="length"></param>
        /// <param name="height"></param>
        /// <param name="borderClr"></param>
        /// <param name="BGColor"></param>
        /// <param name="hero"></param>
        public void SetStatScreen(int rightBorderX, int topMargin, int length, int height, ConsoleColor borderClr, ConsoleColor BGColor, Attributes hero)
        {
            DrawRectangle(length, height, (rightBorderX + 5), (topMargin), borderClr, BGColor);
            Console.ForegroundColor = ConsoleColor.White;
            Console.SetCursorPosition((rightBorderX + 8), (topMargin + 8));
            Console.Write("Hero Name: " + hero.Name);
            Console.WriteLine();
            Console.CursorLeft = (rightBorderX + 8);
            Console.ForegroundColor = ConsoleColor.Green;
            Console.Write("HP: " + hero.HP);
            Console.WriteLine();
            Console.CursorLeft = (rightBorderX + 8);
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.Write("AP: " + hero.AP);
            Console.WriteLine();
            Console.CursorLeft = (rightBorderX + 8);
            Console.WriteLine();
            Console.CursorLeft = (rightBorderX + 8);
            Console.ForegroundColor = ConsoleColor.White;
            Console.Write("Weapon: ...nothing. Uh oh.");
            Console.WriteLine();
            Console.CursorLeft = (rightBorderX + 8);
            Console.Write("Item: Peanuts.");
            Console.WriteLine();
            Console.CursorLeft = (rightBorderX + 8);
            Console.Write("In case you get hangry");
            Console.BackgroundColor = BGColor;
        }

        public void SetBattleScreen(int gridXLength, int topMargin, IList<string> monsterArt)
        {
            Console.SetCursorPosition(10, (topMargin + 2));
            Console.BackgroundColor = ConsoleColor.DarkCyan;
            Console.ForegroundColor = ConsoleColor.Red;
            using (StreamReader reader = new StreamReader("Creature2.txt"))
            {
                string ma;
                while ((ma = reader.ReadLine()) != null)
                {
                    ma = reader.ReadLine();
                    Console.Write(ma);
                    Console.WriteLine();
                    Console.CursorLeft = (10);
                }
                    
            }
                
                
            
           
            
        }
    }
}
