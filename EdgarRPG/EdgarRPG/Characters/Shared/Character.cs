using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EdgarRPG
{
    class Character: ICharacter
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
    }
}
