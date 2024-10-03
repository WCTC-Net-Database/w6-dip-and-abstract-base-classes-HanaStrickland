using System.Windows.Input;
using W6_assignment_template.Models;


public class FlyGhostCommand : ICommand
    {
        private readonly Ghost _ghost;
        
        public FlyGhostCommand(Ghost ghost)
        {
            _ghost = ghost;
        }

    public event EventHandler? CanExecuteChanged;

    public bool CanExecute(object? parameter)
    {
        throw new NotImplementedException();
    }

    public void Execute(object? parameter)
    {
        _ghost.ExecuteFlyGhostCommand();
    }
}