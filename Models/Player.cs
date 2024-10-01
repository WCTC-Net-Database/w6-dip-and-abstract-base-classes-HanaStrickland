using System.Security.Cryptography.X509Certificates;
using W6_assignment_template.Interfaces;

namespace W6_assignment_template.Models
{
    public class Player : CharacterBase
    {
        public int HP {get;set;}
        public List<string> Equipment {get;set;}
        public int Gold { get; set; }
        

        public Player(string name, string type, int level, int hp, int gold)
            : base(name, type, level, hp)
        {
            Gold = gold;
            HP = hp;
        }

        public override void TakeHits(ICharacter attacker)
        {
            if (attacker is Goblin)
            {
                HP -= 2;
            }
            if (attacker is Ghost)
            {
                HP -=1;
            }
            
            Console.WriteLine($"{Name} has {HP} Hit Points Left.");
        }
    }
}
