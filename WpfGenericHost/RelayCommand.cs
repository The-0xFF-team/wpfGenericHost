using System;
using System.Windows.Input;

namespace WpfGenericHost;

internal class RelayCommand : ICommand
{
    private readonly Action _start;

    public RelayCommand(Action start)
    {
        _start = start;
    }

    public bool CanExecute(object parameter)
    {
        return true;
    }

    public void Execute(object parameter)
    {
        _start();
    }

    public event EventHandler CanExecuteChanged = (sender, args) => { };
}