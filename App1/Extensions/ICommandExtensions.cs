using System.Windows.Input;

namespace App1;
static public class ICommandExtensions
{
    static public void TryExecute(this ICommand command, object parameter = null)
    {
        if (command != null)
        {
            if (command.CanExecute(parameter))
            {
                command.Execute(parameter);
            }
        }
    }
}
