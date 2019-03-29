using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp2
{
   

   

   

    class Program {

        static void Main(string[] args) {
            


            Person[] p1=new Person[17];
            p1[0] = new Soldier("Shane", new DateTime(1992, 08, 20), "Firenze", 167, 67, "strong",5, "Day King");
            p1[1] = new Soldier("Cole", new DateTime(1994, 09, 22), "Milan", 183, 92, "Athletic", 3, "Day King");
            p1[2] = new Soldier("Dustin", new DateTime(1990, 10, 24), "Lyon", 170, 72, "strong", 4, "Night King");
            p1[3] = new Soldier("Cam", new DateTime(1988, 08, 13), "London", 195, 98, "Fat", 4, "Day King");
            p1[4] = new Soldier("Joey", new DateTime(1994, 06, 26), "Paris", 160, 55, "dwarf", 2, "Night King");
            p1[5] = new Soldier("Chandler", new DateTime(1991, 07, 21), "Anthens", 72, 67, "strong", 5, "Night King");
            p1[6] = new Knight("Ross", new DateTime(1991, 07, 21), "Anthens", 72, 67, "strong", 5, "Day King", 60);
            p1[7] = new Knight("Jack", new DateTime(1991, 07, 21), "Anthens", 72, 67, "strong", 5, "Night King",58);
            p1[8] = new Person("Cole", new DateTime(1992, 08, 20), "Firenze", 167, 67, "strong");
            p1[9] = new Person("Henry", new DateTime(1992, 08, 20), "Firenze", 167, 67, "strong");
            p1[10] = new Person("Warne", new DateTime(1992, 08, 20), "Firenze", 167, 67, "strong");
            p1[11] = new Person("Mckenzie", new DateTime(1992, 08, 20), "Firenze", 167, 67, "strong");
            p1[12] = new Soldier("Dustin", new DateTime(1990, 10, 24), "Lyon", 170, 72, "strong", 4, "Night King");
            p1[13] = new Soldier("Dustin", new DateTime(1990, 10, 24), "Lyon", 170, 72, "strong", 4, "Night King");
            p1[14] = new Soldier("Dustin", new DateTime(1990, 10, 24), "Lyon", 170, 72, "strong", 4, "Night King");
            p1[15] = new Soldier("Dustin", new DateTime(1990, 10, 24), "Lyon", 170, 72, "strong", 4, "Night King");
            p1[16] = new Soldier("Dustin", new DateTime(1990, 10, 24), "Lyon", 170, 72, "strong", 4, "Night King");


            Program prog = new Program();

             prog.runGame(p1);            

        }
        //Method to Start the Game where the Grid is populated and waits for th User Input to Move the Character
        public void runGame(Person[] p1) {
            Hero hero = null;
            Console.WriteLine("*******************************");
            Console.WriteLine("****Yvan The Warrior!!!!!******");
            Console.WriteLine("*******************************");
            String option;
            ConsoleKeyInfo key;

            do
            {
                Console.WriteLine("1.DAY KING");
                Console.WriteLine("2.NIGHT KING");
                Console.WriteLine("Choose a King to Fight(1 OR 2):");
                         
                option = Console.ReadLine();
                if (option.Equals("1"))
                {
                    hero = new Hero("Yvan", new DateTime(1991, 07, 21), "Rouen", 172, 67, "strong", 5, "DAY KING", 70, 0, 0);
                    Console.WriteLine("Day King");
                    hero.Display();
                    break;
                }
                else if (option.Equals("2"))
                {
                    hero = new Hero("Yvan", new DateTime(1991, 07, 21), "Rouen", 172, 67, "strong", 5, "NIGHT KING", 70, 0, 0);
                    Console.WriteLine("Night King");
                    hero.Display();
                    break;
                }
                else
                {
                    Console.WriteLine("Please Choose a Valid Option");

                }
            } while (option != "1" || option != "2");


            Console2D console = new Console2D();

            console.placePlayers(p1);
            console.displayGrid();

            Console.WriteLine("Move Yvans towards to Castle From Forest");
            //IsAlive Condition to be added 
            while ((hero.X != 9 || hero.Y != 9) && hero.isAlive())
            {
                
                Console.WriteLine("[X:" + hero.X + "Y:" + hero.Y + "]");
                key = Console.ReadKey();
                String input = key.Key.ToString();
                Console.WriteLine();
                Char direction ;
                if (!input.Equals("")) {
                    direction = input[0].Equals("") ? 'X' : input[0];
                }
                else {
                    direction = 'X';
                }
                console.move(hero, direction.ToString());
                console.displayGrid();
            }

            if (hero.X == 9 || hero.Y == 9)
            {
                Console.WriteLine("***************************************");
                Console.WriteLine("Congrats!!! Yvan Has reached his Castle");
                Console.WriteLine("***************************************");
                Console.ReadLine();
            }

            if (!hero.isAlive()) {
                Console.WriteLine("***************************************");
                Console.WriteLine("***Sorry Yvan Got Killed in the Fight**");
                Console.WriteLine("***************************************");
                Console.ReadLine();
            }
        }

       

       

    }
}
