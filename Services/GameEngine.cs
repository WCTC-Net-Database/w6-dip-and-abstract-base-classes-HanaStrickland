using W6_assignment_template.Data;
using W6_assignment_template.Models;

namespace W6_assignment_template.Services
{
    public class GameEngine
    {
        private readonly IContext _context;
        private readonly Player _player;
        private readonly Goblin _goblin1;

        private readonly Ghost _ghost;
        private readonly Goblin _goblin2;

        public GameEngine(IContext context)
        {
            _context = context;
            _player = context.Characters.OfType<Player>().FirstOrDefault();
            _goblin1 = _context.Characters.OfType<Goblin>().FirstOrDefault();
            _ghost = _context.Characters.OfType<Ghost>().FirstOrDefault();
            _goblin2 = _context.Characters.OfType<Goblin>().Skip(1).FirstOrDefault();
        }

        public void Run()
        {
            if (_player == null || _goblin1 == null)
            {
                Console.WriteLine("Failed to initialize game characters.");
                return;
            }

            Console.WriteLine($"Player Gold: {_player.Gold}");

            _goblin1.Move();
            _goblin1.Attack(_player);
            _player.TakeHits(_goblin1);

            _player.Move();
            _player.Attack(_goblin1);
            _goblin1.TakeHits(_player);
            _ghost.ExecuteFlyGhostCommand();
            _player.Attack(_ghost);
            _ghost.TakeHits(_player);
            _goblin2.Attack(_player);
            _player.TakeHits(_goblin2);
            _player.Attack(_goblin2);

            Console.WriteLine($"Player Gold: {_player.Gold}");
            _context.UpdateCharacter(_player);
            _context.UpdateCharacter(_goblin1);
            _context.UpdateCharacter(_ghost);
            _context.UpdateCharacter(_goblin2);
        }
    }
}
