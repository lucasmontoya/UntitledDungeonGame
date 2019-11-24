using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DungeonGame
{
    class Battle
    {
        //    public void PrintAllStats(Player player1, Attributes monster)
        //    {
        //        player1.PrintAttributes();
        //        Console.WriteLine(" ");
        //        monster.PrintAttributes();
        //        Console.WriteLine(" ");
        //    }

        //    public void MonsterBattle(Attributes hero, IList<Attributes> monster, int monIndex)
        //    {
        //        Keys keys = new Keys();
        //        while (monster[monIndex].HP > 0 && hero.HP > 0)
        //        {
        //            PrintAllStats(hero, monster);

        //            hero.Turn(Choice(), monster);

        //            if (monster.HP > 0)
        //            {
        //                monster.MonsterTurn(hero);
        //                IsHeroDead(hero);
        //            }

        //        }

        //        Console.WriteLine(monster.Name + " was killed!");
        //    }

        //    private void IsHeroDead(Attributes hero)
        //    {
        //        throw new NotImplementedException();
        //    }

        //    public int Choice()
        //    {
        //        int Choice = 0;
        //        string[] BattleOptions = new string[] { "Attack", "Block", "Dodge", "Item" };

        //        while (true)
        //        {
        //            Console.Clear();
        //            for (int i = 0; i < BattleOptions.Length; i++)
        //            {
        //                if (Choice == 1)
        //                {
        //                    Console.ForegroundColor = ConsoleColor.Red;
        //                }
        //                Console.WriteLine("{0}-{1}", i, BattleOptions[i]);
        //                if (Choice == 1)
        //                {
        //                    Console.ResetColor();
        //                }
        //            }

        //            var KeyPressed = Console.ReadKey();
        //            if (KeyPressed.Key == ConsoleKey.DownArrow)
        //            {
        //                if (Choice != BattleOptions.Length - 1)
        //                {
        //                    Choice++;
        //                }
        //            }
        //            else if (KeyPressed.Key == ConsoleKey.UpArrow)
        //            {
        //                if (Choice != 0)
        //                {
        //                    Choice--;
        //                }
        //            }

        //            if (KeyPressed.Key == ConsoleKey.Enter)
        //            {
        //                Console.Clear();
        //                return Choice;
        //            }
        //        }
        //    }

        //    public void PrintAttributes()
        //    {
        //        Console.WriteLine("Name:" + Name);
        //        Console.WriteLine("HP:" + HP);
        //        Console.WriteLine("AP:" + AP);
        //        Console.WriteLine("Symbol:" + Symbol);
        //    }

        //    internal void MonsterTurn(Attributes hero)
        //    {
        //        throw new NotImplementedException();
        //    }

        //    public void Turn(int choice, Attributes monster)
        //    {
        //        if (choice == 1)
        //        {
        //            Attack(monster);
        //            Console.WriteLine("You attacked " + monster.Name);
        //        }
        //        if (choice == 2)
        //        {
        //            Block(monster);
        //            Console.WriteLine("You block " + monster.Name + "'s attack");
        //        }
        //        if (choice == 3)
        //        {
        //            Dodge(monster);
        //            Console.WriteLine("You dodge " + monster.Name + "'s attack");
        //        }
        //        if (choice == 4)
        //        {
        //            useItem();
        //            Console.WriteLine("You used ");
        //        }
        //    }

        //    private void UseItem()
        //    {
        //        throw new NotImplementedException();
        //    }

        //    private void Dodge(Attributes monster)
        //    {
        //        throw new NotImplementedException();
        //    }

        //    private void Block(Attributes monster)
        //    {
        //        HP += monster.AP;
        //    }

        //    private void Attack(Attributes monster)
        //    {
        //        monster.HP -= AP;
        //    }

        //    private Attributes FindMonster()
        //    {
        //        throw new NotImplementedException();
        //    }
    }
}
