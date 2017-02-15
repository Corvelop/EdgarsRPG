using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EdgarRPG
{
    class Warrior:  Character
    {
        public Warrior() : base()
        {
          
        }

        public Warrior(string name) : base()
        {
            this.Name = name;
        }

        public override Enums.CharacterTypes CharacterType => Enums.CharacterTypes.Warrior;
    }
}
