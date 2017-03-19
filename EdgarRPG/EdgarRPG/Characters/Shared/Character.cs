using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EdgarRPG
{
    abstract class Character : ICharacter
    {
        public Character()
        {
            Gold = 1;
            HealthPoints = 100;
        }

        public string Name { get; set; }
        public virtual Enums.CharacterTypes CharacterType => Enums.CharacterTypes.None;
        public int HealthPoints { get; set; }
        public int Gold { get; set; }
        public int Level { get; set; }
        public string PlayerInfo
        {
            get
            {
                return $"{Name} - {CharacterType.ToString() } LVL {Level}";
            }
        }

        public void Attack(ICharacter character)
        {
            Random rng = new Random();
            int hit = Level - character.Level;

            if (hit <= 0)
            {
                hit = 1;
            }
            var hitPointsTaking = rng.Next(hit * 3, hit * 14);

            character.HealthPoints -= hitPointsTaking;

            Console.WriteLine($"{PlayerInfo}  {HealthPoints}\nEnemy has lost {hitPointsTaking}HP!");
            Console.ReadKey();
        }

        public void AttackOptions(ICharacter character)
        {
            string attackOption;
            do
            {
                Console.Clear();
                Console.WriteLine("Would you like to...\n A)Attack\n B)Heal\n C)Nothing\n");

                attackOption = Console.ReadLine().ToUpper();

                Console.Clear();
            } while (attackOption != "A" && attackOption != "B" && attackOption != "C");

            switch (attackOption)
            {
                case "A":
                    Attack(character);
                    break;
                case "B":
                    Heal();
                    break;
                case "C":
                default:
                    break;
            }
        }

        private void Heal()
        {
            this.HealthPoints += 5;
        }
    }
}
