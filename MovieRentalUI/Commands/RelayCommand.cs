using System.Windows.Input;

namespace MovieRentalUI.Commands;

public class RelayCommand : ICommand
{
    public event EventHandler? CanExecuteChanged;

    public Action<object> _execute { get; set; }

    public Predicate<object> _canExecute { get; set; }
    public RelayCommand(Action<object> Execute, Predicate<object> CanExecute)
    {
        _execute = Execute;
        _canExecute = CanExecute;
    }

    public bool CanExecute(object? parameter)
    {
        return _canExecute(parameter);
    }

    public void Execute(object? parameter)
    {
         _execute(parameter);
    }
}
