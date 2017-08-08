using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EdgarRPG
{
    class Program
    {
        static void Main(string[] args)

        {
            //TODO: add more to the story. 
            string name  = IntroStory();
            ICharacter character = BeginningOfTheGame(name);
            Battle(character);

            Console.ReadKey();
        }

        private static void Battle(ICharacter mainUser)
        {
            Enemy enemy = new Enemy();
            Console.WriteLine("An Ememy has shown up. What would you like to do?");

            //To fight until someone dieds
            do
            {
                var healthPointBefore = enemy.HealthPoints;

                //TODO: make the use and the Enemy attack at the same time.. not having to click again once you finished your turn. 
                mainUser.AttackOptions(enemy);
                enemy.Attack(mainUser);

            } while (mainUser.HealthPoints > 0 && enemy.HealthPoints > 0);

            if(mainUser.HealthPoints <= 0)
            {
                GameOver();
            }
            else if (enemy.HealthPoints <= 0)
            {
                Console.WriteLine("You have defeated the monster!");

                //TODO: come back to full health and get experice
            }

        }

        private static void GameOver()
        {
            Console.WriteLine("Snakee..... SNAKE!!!!!!");
            string playAgainOption = string.Empty;

            Console.WriteLine("Would you like to play again?\ny/n");
            playAgainOption = Console.ReadLine().ToUpper();
            Console.Clear();

            switch (playAgainOption)
            {
                case "Y":
                    Main(new string[0]);
                    break;
                case "N":
                    //TODO: Add credits... created by... etc etc.
                    break;
                default:
                    GameOver();
                    break;
            }
        
        }

        private static ICharacter BeginningOfTheGame(string characterName)
        {
            ICharacter character = null;
            string typeOfCharacter;

            Console.Clear();
            Console.WriteLine($"{characterName}, what would you want to become?");
            Console.WriteLine("A) Warrior");
            Console.WriteLine("B) Mage");
            Console.WriteLine("C) Ninja");

            typeOfCharacter = Console.ReadLine().ToUpper();
            Console.Clear();

            switch (typeOfCharacter)
            {
                case "A":
                    character =new Warrior(characterName);
                    break;
                case "B":
                    character = new Mage(characterName);
                    break;
                case "C":
                    character = new Ninja(characterName);
                    break;
                default:
                    BeginningOfTheGame(characterName);
                    break;
            }
            Console.Clear();
            return character;
        }

        private static string  IntroStory()
        {
            Console.WriteLine("Hello World! \nWhat is your name? ");
            string name = Console.ReadLine();

            Console.WriteLine($"{name} hows it going?");

            return name;
        }
    }
}
