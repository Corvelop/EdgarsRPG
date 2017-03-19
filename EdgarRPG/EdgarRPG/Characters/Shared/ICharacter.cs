using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EdgarRPG
{
    interface ICharacter
    {
        string Name {get; set;}
        Enums.CharacterTypes CharacterType { get; }
        int HealthPoints { get; set; }
        int Gold { get; set; }
        int Level { get; set; }
        string PlayerInfo { get;}

        void Attack(ICharacter character);
        void AttackOptions(ICharacter character);
        
    }
}
