using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EdgarRPG
{
    class Ninja : Character
    {
        public Ninja() : base()
        {
           
        }
        public Ninja(string name) : base()
        {
            this.Name = name;
        }

        public override Enums.CharacterTypes CharacterType => Enums.CharacterTypes.Ninja;
    }
}
