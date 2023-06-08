using System.ComponentModel;

namespace App1;
public interface INotifyExpressionChanged : INotifyPropertyChanged
{
    void NotifyPropertyChanged(string propertyName);
}
