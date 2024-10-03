using W6_assignment_template.Interfaces;

namespace W6_assignment_template.Models
{
    public class Ghost : CharacterBase, ILootable
    {
        public string Treasure { get; set; }
        public int HP {get;set;}

        public Ghost(string name, string type, int level, int hp, string treasure)
            : base(name, type, level, hp)
        {
            Treasure = treasure;
            HP = hp;
        }

        public void ExecuteFlyGhostCommand()
        {
            Console.WriteLine($"{Name} flies commandingly.");
        }

        public override void TakeHits(ICharacter attacker)
        {
            if (attacker is Player)
            {
                HP -= 2;
            }

            if (attacker is Goblin)
            {
                HP -=3;
            }
            
            Console.WriteLine($"{Name} has {HP} Hit Points Left.");
        }
    }
}
