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
            Level = 1;
        }

        public string Name { get; set; }
        public virtual Enums.CharacterTypes CharacterType => Enums.CharacterTypes.None;
        public int NumberOfHealthPotions { get; set; } = 3; 
        public int HealthPoints { get; set; }
        public int Gold { get; set; }
        public int Level { get; set; }
        public string PlayerInfo
        {
            get
            {
                return $"{Name} - {CharacterType.ToString() } LVL:{Level} HP:{HealthPoints} HP Potions:{NumberOfHealthPotions}\n";
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

            Console.WriteLine($"{PlayerInfo}{character.PlayerInfo}\nEnemy has lost {hitPointsTaking}HP!");
        }

        public void AttackOptions(ICharacter character)
        {

            string attackOption;

            Console.WriteLine("Would you like to...\n A)Attack\n B)Heal\n C)Nothing\n\n");

            attackOption = Console.ReadLine().ToUpper();

            Console.Clear();

            switch (attackOption)
            {
                case "A":
                    Attack(character);
                    break;
                case "B":
                    if(NumberOfHealthPotions.Equals(0))
                    {
                        Console.WriteLine("You are call out of health potions");
                        AttackOptions(character);
                    }
                    else
                    {
                        NumberOfHealthPotions--;
                        Heal(character);
                    }
                    break;
                case "C":
                default:
                    AttackOptions(character);
                    break;
            }
        }

        private void Heal(ICharacter character)
        {

            Random rng = new Random();
            var numberOfHealthPointsToAdd = rng.Next(5, 12);
          
            this.HealthPoints += numberOfHealthPointsToAdd;

            //user can not have a greater amount of health point then the max value.
            if(this.HealthPoints > 100)
            {
                this.HealthPoints = 100;
            }

            Console.WriteLine($"{PlayerInfo}{character.PlayerInfo}You have has gained {numberOfHealthPointsToAdd}HP!\n");
        }
    }
}
