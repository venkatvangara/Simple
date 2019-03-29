using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp2
{
    class Console2D
    {
        char[,] grid;
        Person[,] personGrid;
        Soldier[,] soldierGrid;
        Knight[,] knightGrid;
        char[,] gridToDisplay;

        //Contructor
        public Console2D()
        {
             grid = new char[10, 10];
             personGrid = new Person[10, 10];
            soldierGrid = new Soldier[10, 10];
            knightGrid = new Knight[10, 10];
            gridToDisplay = new char[10, 10];


            for (int i = 0; i < 10; i++)
            {
                for (int j = 0; j < 10; j++) {

                    grid[i, j] = 'X';
                    gridToDisplay[i, j] = '?';

                }


            }
            this.initializeChar();
        }

        /*
         * To SET the Position of Yvan and Castle at the begining
         
             */
        public void initializeChar() {
            gridToDisplay[0, 0] = 'Y';
            gridToDisplay[9, 9] = 'C';
            grid[0, 0] = 'Y';
            grid[9, 9] = 'C';
        }


        public void displayGrid() {
            
            for (int i = 0; i < 10; i++)
            {
                for (int j = 0; j < 10; j++)
                {

                    Console.Write(""+gridToDisplay[i,j]+"\t");

                }
                Console.WriteLine();


            }

            
        }

        

        /*
         * To Place the Players in Random Position.
         
             */
        public void placePlayers(Person[] players) {
            Soldier soldier= new Soldier("Test", new DateTime(1990, 01, 01), "Test", 0, 0, "test", 0, "test");
            Knight knight = new Knight("Test", new DateTime(1990, 01, 01), "Test", 0, 0, "test", 0, "test",0);
            Person person = new Person("Test", new DateTime(1990, 01, 01), "Test", 0, 0, "test");
            Random rand = new Random();

            foreach (var player in players)
            {
                if (player.GetType().IsAssignableFrom(person.GetType()))
                {
                    int x = rand.Next(0, 10);
                    int y = rand.Next(0, 10);
                    if (rand.Next(1, 101) <= 20)
                    {
                        if (x != 0 && y != 0)
                        {
                            if (x != 9 && y != 9)
                            {
                                personGrid[x, y] = player;
                                grid[x, y] = 'P';
                            }

                        }
                      //  Console.WriteLine("It is a Person" + x + y);
                    }
                }
                else if (player.GetType().IsAssignableFrom(soldier.GetType()))
                {
                    int x = rand.Next(0, 10);
                    int y = rand.Next(0, 10);
                    if (rand.Next(1, 101) <= 80)
                    {
                        if (x != 0 && y != 0)
                        {
                            if (x != 9 && y != 9)
                            {
                                soldierGrid[x, y] = (Soldier)player;
                                grid[x, y] = 'S';
                            }

                        }
                       // Console.WriteLine("It is a Soldier" + x + y);
                    }

                }
                else if (player.GetType().IsAssignableFrom(knight.GetType()))
                {
                    int x = rand.Next(0, 10);
                    int y = rand.Next(0, 10);
                    if (rand.Next(1, 101) <= 20)
                    {
                        if (x != 0 && y != 0)
                        {
                            if (x != 9 && y != 9)
                            {
                                knightGrid[x, y] = (Knight)player;
                                grid[x, y] = 'K';
                            }
                        }
                        //Console.WriteLine("It is a Knight" + x + y);
                    }
                }
            


            }

        }

        /*
         * This Class is Reponsible for Moving Yvan Across the Grid
         * and Based on the Charactors he meets repections actions are carried out.
         * When he meets a Soldier / knight of the same king the Weapon is repaired
         * When an Soldier/ Enemy of Other King is met then Yvan Fights with them to win 
         * If he meets a person then the details of the person are received.
         
             */
        public void move(Hero hero,String input) {
            gridToDisplay[0, 0] = 'X';
            if (input.ToUpper().Equals("D"))
            {
                
                Console.WriteLine(gridToDisplay[0, 0] = 'X');
                if ((hero.Y + 1) <= 9)
                {
                    if (grid[hero.X, hero.Y + 1] == 'X')
                    {
                        gridToDisplay[hero.X, hero.Y] = grid[hero.X, hero.Y];
                        hero.Y = hero.Y + 1;
                        gridToDisplay[hero.X, hero.Y] = 'Y';
                    } else if(grid[hero.X, hero.Y + 1] == 'P'){
                        gridToDisplay[hero.X, hero.Y] = grid[hero.X, hero.Y];
                        hero.Y = hero.Y + 1;
                        personGrid[hero.X, hero.Y].Display();
                        gridToDisplay[hero.X, hero.Y] = 'Y';
                    }
                    else if (grid[hero.X, hero.Y + 1] == 'S')
                    {
                        gridToDisplay[hero.X, hero.Y] = grid[hero.X, hero.Y];
                        hero.Y = hero.Y + 1;
                        soldierMet(hero);
                        gridToDisplay[hero.X, hero.Y] = 'Y';
                    }
                    else if (grid[hero.X, hero.Y + 1] == 'K')
                    {
                        gridToDisplay[hero.X, hero.Y] = grid[hero.X, hero.Y];
                        hero.Y = hero.Y + 1;
                        knightMet(hero);
                        gridToDisplay[hero.X, hero.Y] = 'Y';
                    }
                    else if (grid[hero.X, hero.Y + 1] == 'C')
                    {
                        gridToDisplay[hero.X, hero.Y] = grid[hero.X, hero.Y];
                        hero.Y = hero.Y + 1;
                        gridToDisplay[hero.X, hero.Y] = 'Y';
                    }
                }
                else
                {
                    Console.WriteLine("You Cannot Move Beyond your Kingdom!! try a different Move");
                }

            }
            else if (input.ToUpper().Equals("A"))
            {
                if ((hero.Y - 1) >= 0)
                {
                    if (grid[hero.X, hero.Y-1] == 'X')
                    {
                        gridToDisplay[hero.X, hero.Y] = grid[hero.X, hero.Y];
                        hero.Y = hero.Y - 1;
                        gridToDisplay[hero.X, hero.Y] = 'Y';
                    }
                    else if (grid[hero.X, hero.Y - 1] == 'P')
                    {
                        gridToDisplay[hero.X, hero.Y] = grid[hero.X, hero.Y];
                        hero.Y = hero.Y - 1;
                        personGrid[hero.X, hero.Y].Display();
                        gridToDisplay[hero.X, hero.Y] = 'Y';
                    }
                    else if (grid[hero.X, hero.Y - 1] == 'S')
                    {
                        gridToDisplay[hero.X, hero.Y] = grid[hero.X, hero.Y];
                        hero.Y = hero.Y - 1;
                        soldierMet(hero);
                        gridToDisplay[hero.X, hero.Y] = 'Y';
                    }
                    else if (grid[hero.X, hero.Y - 1] == 'K')
                    {
                        gridToDisplay[hero.X, hero.Y] = grid[hero.X, hero.Y];
                        hero.Y = hero.Y - 1;
                        knightMet(hero);
                        gridToDisplay[hero.X, hero.Y] = 'Y';
                    }
                    else if (grid[hero.X, hero.Y - 1] == 'C')
                    {
                        gridToDisplay[hero.X, hero.Y] = grid[hero.X, hero.Y];
                        hero.Y = hero.Y - 1;
                        gridToDisplay[hero.X, hero.Y] = 'Y';
                    }
                }
                else
                {
                    Console.WriteLine("You Cannot Move Beyond your Kingdom!! try a different Move");
                }
            }
            else if (input.ToUpper().Equals("S"))
            {
                if ((hero.X + 1) <= 9)
                {

                    if (grid[hero.X + 1, hero.Y] == 'X')
                    {
                        gridToDisplay[hero.X, hero.Y] = grid[hero.X, hero.Y];
                        hero.X = hero.X + 1;
                        gridToDisplay[hero.X, hero.Y] = 'Y';
                    }
                    else if (grid[hero.X + 1, hero.Y] == 'P')
                    {
                        gridToDisplay[hero.X, hero.Y] = grid[hero.X, hero.Y];
                        hero.X = hero.X + 1;
                        personGrid[hero.X, hero.Y].Display();
                        gridToDisplay[hero.X, hero.Y] = 'Y';
                    }
                    else if (grid[hero.X + 1, hero.Y] == 'S')
                    {
                        gridToDisplay[hero.X, hero.Y] = grid[hero.X, hero.Y];
                        hero.X = hero.X + 1;
                        soldierMet(hero);
                        gridToDisplay[hero.X, hero.Y] = 'Y';
                    }
                    else if (grid[hero.X + 1, hero.Y] == 'K')
                    {
                        gridToDisplay[hero.X, hero.Y] = grid[hero.X, hero.Y];
                        hero.X = hero.X + 1;
                        knightMet(hero);
                        gridToDisplay[hero.X, hero.Y] = 'Y';
                    }
                    else if (grid[hero.X + 1, hero.Y] == 'C')
                    {
                        gridToDisplay[hero.X, hero.Y] = grid[hero.X, hero.Y];
                        hero.X = hero.X + 1;
                        gridToDisplay[hero.X, hero.Y] = 'Y';
                    }
                }
                else
                {
                    Console.WriteLine("You Cannot Move Beyond your Kingdom!! try a different Move");
                }

            }
            else if (input.ToUpper().Equals("W"))
            {
                if ((hero.X - 1) >= 0)
                {
                    if (grid[hero.X - 1, hero.Y] == 'X')
                    {
                        gridToDisplay[hero.X, hero.Y] = grid[hero.X, hero.Y];
                        hero.X = hero.X - 1;
                        gridToDisplay[hero.X, hero.Y] = 'Y';
                    }
                    else if (grid[hero.X - 1, hero.Y] == 'P')
                    {
                        gridToDisplay[hero.X, hero.Y] = grid[hero.X, hero.Y];
                        hero.X = hero.X - 1;
                        personGrid[hero.X, hero.Y].Display();
                        gridToDisplay[hero.X, hero.Y] = 'Y';
                    }
                    else if (grid[hero.X - 1, hero.Y] == 'S')
                    {
                        gridToDisplay[hero.X, hero.Y] = grid[hero.X, hero.Y];
                        hero.X = hero.X - 1;
                        soldierMet(hero);
                        gridToDisplay[hero.X, hero.Y] = 'Y';
                    }
                    else if (grid[hero.X - 1, hero.Y] == 'K')
                    {
                        gridToDisplay[hero.X, hero.Y] = grid[hero.X, hero.Y];
                        hero.X = hero.X - 1;
                        knightMet(hero);
                        gridToDisplay[hero.X, hero.Y] = 'Y';
                    }
                    else if (grid[hero.X - 1, hero.Y] == 'C')
                    {
                        gridToDisplay[hero.X, hero.Y] = grid[hero.X, hero.Y];
                        hero.X = hero.X - 1;
                        gridToDisplay[hero.X, hero.Y] = 'Y';
                    }
                }
                else
                {
                    Console.WriteLine("You Cannot Move Beyond your Kingdom!! try a different Move");

                }

            }
            else {
                Console.WriteLine("Invalid Direction!! Use W/S/A/D for \n moving Yvan UP/DOWN/LEFT/RIGHT ");
            }

        }


        //Action the needs to be performed when meeting a soldier are done here
        public void soldierMet(Hero hero) {
            if (soldierGrid[hero.X, hero.Y].NameOftheKing.Equals(hero.NameOftheKing))
            {
                soldierGrid[hero.X, hero.Y].Display();
                Console.WriteLine("I am Friend!!! Let me Repair your Weapon to 100% \n");
                Console.WriteLine("**********************************************************");
                hero.HeroWeapon.WeaponState = 100;
                Console.WriteLine("Weapon Strength reset to " + hero.HeroWeapon.WeaponState + " ");
                Console.WriteLine("**********************************************************");


            }
            else
            {
                Random rand = new Random();
                Boolean flag = false;
                flag = rand.Next(1, 2) == 1;
                while (hero.isAlive() && soldierGrid[hero.X, hero.Y].isAlive())
                {
                    if (flag)
                    {

                        Console.WriteLine("Yvan Attacking with Weapon Power " + hero.StrengthOfWeapon);
                        hero.Attack(soldierGrid[hero.X, hero.Y]);
                        Console.WriteLine("Enemy Health" + soldierGrid[hero.X, hero.Y].HealthPoint + "\n Weapon State" + hero.HeroWeapon.WeaponState);
                        flag = !flag;
                    }
                    else
                    {
                        Console.WriteLine("Enemy Attacking with Weapon Power " + soldierGrid[hero.X, hero.Y].StrengthOfWeapon);
                        soldierGrid[hero.X, hero.Y].Attack(hero);
                        Console.WriteLine("Yvan Health" + hero.HealthPoint + "\n Weapon State" + soldierGrid[hero.X, hero.Y].SoldierWeapon.WeaponState);
                        flag = !flag;
                    }

                }
                if (!soldierGrid[hero.X, hero.Y].isAlive())
                {
                    grid[hero.X, hero.Y] = 'X';
                    gridToDisplay[hero.X, hero.Y] = 'X';
                }
            }

        }


        //Actions required when a knight is met is done over here.
        public void knightMet(Hero hero)
        {
            if (knightGrid[hero.X, hero.Y].NameOftheKing.Equals(hero.NameOftheKing))
            {
                knightGrid[hero.X, hero.Y].Display();
                Console.WriteLine("I am Friend!!! Let me Repair your Weapon to 100% \n");
                Console.WriteLine("**********************************************************");
                hero.HeroWeapon.WeaponState = 100;
                Console.WriteLine("Weapon Strength reset to " + hero.HeroWeapon.WeaponState + " ");
                Console.WriteLine("**********************************************************");


            }
            else
            {
                Random rand = new Random();
                Boolean flag = false;
                flag = rand.Next(1, 2) == 1;
                while (hero.isAlive() && knightGrid[hero.X, hero.Y].isAlive())
                {
                    if (flag)
                    {

                        Console.WriteLine("Yvan Attacking with Weapon Power " + hero.StrengthOfWeapon);
                        hero.Attack(knightGrid[hero.X, hero.Y]);
                        Console.WriteLine("Enemy Health" + knightGrid[hero.X, hero.Y].HealthPoint + "\n Weapon State" + hero.HeroWeapon.WeaponState);
                        flag = !flag;
                    }
                    else
                    {
                        Console.WriteLine("Enemy Attacking with Weapon Power " + knightGrid[hero.X, hero.Y].StrengthOfWeapon);
                        knightGrid[hero.X, hero.Y].Attack(hero);
                        Console.WriteLine("Yvan Health" + hero.HealthPoint + "\n Weapon State" + knightGrid[hero.X, hero.Y].SoldierWeapon.WeaponState);
                        flag = !flag;
                    }

                }
                if (!knightGrid[hero.X, hero.Y].isAlive())
                {
                    grid[hero.X, hero.Y] = 'X';
                    gridToDisplay[hero.X, hero.Y] = 'X';
                }
            }

        }



    }
}
