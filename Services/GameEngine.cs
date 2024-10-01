using W6_assignment_template.Data;
using W6_assignment_template.Models;

namespace W6_assignment_template.Services
{
    public class GameEngine
    {
        private readonly IContext _context;
        private readonly Player _player;
        private readonly Goblin _goblin;

        private readonly Ghost _ghost;

        public GameEngine(IContext context)
        {
            _context = context;
            _player = context.Characters.OfType<Player>().FirstOrDefault();
            _goblin = _context.Characters.OfType<Goblin>().FirstOrDefault();
            _ghost = _context.Characters.OfType<Ghost>().FirstOrDefault();
        }

        public void Run()
        {
            if (_player == null || _goblin == null)
            {
                Console.WriteLine("Failed to initialize game characters.");
                return;
            }

            Console.WriteLine($"Player Gold: {_player.Gold}");

            _goblin.Move();
            _goblin.Attack(_player);
            _player.TakeHits(_goblin);

            _player.Move();
            _player.Attack(_goblin);
            _goblin.TakeHits(_player);
            _ghost.ExecuteFlyGhostCommand();
            _player.Attack(_ghost);
            _ghost.TakeHits(_player);

            Console.WriteLine($"Player Gold: {_player.Gold}");
            _context.UpdateCharacter(_player);
            _context.UpdateCharacter(_goblin);
            _context.UpdateCharacter(_ghost);
        }
    }
}
