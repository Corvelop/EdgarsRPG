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
            ICharacter character = BeginingOfTheGame(name);
            Battle(character);

            //Console.WriteLine(mainUser.CharacterType.ToString());

            Console.ReadKey();
        }

        private static bool Battle(ICharacter mainUser)
        {
            Enemy enemy = new Enemy();

            //To fight until someone dieds
            do
            {
                enemy.HealthPoints = enemy.HealthPoints - 10;

            } while (mainUser.HealthPoints > 0 && enemy.HealthPoints > 0);

            if(mainUser.HealthPoints <= 0)
            {
                GameOver();
            }
            else if (enemy.HealthPoints <= 0)
            {
                Console.WriteLine("You have defeated the monster");
            }
            

            return false;
        }

        private static void GameOver()
        {
            throw new NotImplementedException();
        }

        private static ICharacter BeginingOfTheGame(string characterName)
        {
            ICharacter character = null;
            string TypeOfCharacter;

            do
            {
                Console.Clear();
                Console.WriteLine(characterName +", what would you want to become?");
                Console.WriteLine("A) Warrior");
                Console.WriteLine("B) Mage");
                Console.WriteLine("C) Ninja");

                TypeOfCharacter = Console.ReadLine().ToUpper();

                Console.Clear();
            } while (TypeOfCharacter != "A" && TypeOfCharacter != "B" && TypeOfCharacter != "C");

            switch (TypeOfCharacter)
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

            Console.WriteLine(character.Name + " - " + character.CharacterType.ToString() + " LVL" + character.Level);
            return character;
        }

        private static string  IntroStory()
        {
            Console.WriteLine("Hello World! \nWhat is your name? ");
            string name = Console.ReadLine();

            Console.WriteLine(name + " hows it going?");

            return name;
        }
    }
}
