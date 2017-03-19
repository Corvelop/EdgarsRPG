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
            string name  = IntroStory();
            ICharacter character = BeginningOfTheGame(name);
            Battle(character);

            //Console.WriteLine(mainUser.CharacterType.ToString());

            Console.ReadKey();
        }

        private static bool Battle(ICharacter mainUser)
        {
            Enemy enemy = new Enemy();
            Console.WriteLine("An Ememy has shown up. What would you like to do?");

            //To fight until someone dieds
            do
            {
                var healthPointBefore = enemy.HealthPoints;
                mainUser.AttackOptions(enemy);

           
                Console.ReadKey();

                Console.Clear();

            } while (mainUser.HealthPoints > 0 && enemy.HealthPoints > 0);

            if(mainUser.HealthPoints <= 0)
            {
                GameOver();
            }
            else if (enemy.HealthPoints <= 0)
            {
                Console.WriteLine("You have defeated the monster!");
            }

            return false;
        }

        private static void GameOver()
        {
            throw new NotImplementedException();
        }

        private static ICharacter BeginningOfTheGame(string characterName)
        {
            ICharacter character = null;
            string typeOfCharacter;

            do
            {
                Console.Clear();
                Console.WriteLine($"{characterName}, what would you want to become?");
                Console.WriteLine("A) Warrior");
                Console.WriteLine("B) Mage");
                Console.WriteLine("C) Ninja");

                typeOfCharacter = Console.ReadLine().ToUpper();

                Console.Clear();
            } while (typeOfCharacter != "A" && typeOfCharacter != "B" && typeOfCharacter != "C");

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
