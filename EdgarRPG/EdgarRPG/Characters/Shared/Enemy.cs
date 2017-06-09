using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EdgarRPG
{
    class Enemy: ICharacter
    {
        public Enemy()
        {
            Level = 1;
            HealthPoints = 100;
            Gold = 10;
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
                return $"Enemy - LVL:{Level} HP:{HealthPoints}\n";
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

            Console.WriteLine($"{character.PlayerInfo}{PlayerInfo}\nYou has lost {hitPointsTaking}HP!\n");
        }


        public void AttackOptions(ICharacter character)
        {
          //ToDo
        }


    }
}
