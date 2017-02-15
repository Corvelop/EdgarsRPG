using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EdgarRPG
{
    class Mage : Character
    {
        public Mage():base()
        {
           
        }
        public Mage(string name) : base()
        {
            this.Name = name;
        }
        public override Enums.CharacterTypes CharacterType => Enums.CharacterTypes.Mage;
    }
}
