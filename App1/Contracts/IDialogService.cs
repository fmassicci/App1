using Microsoft.UI.Xaml;
using System.Threading.Tasks;

namespace App1.Contracts;
public interface IDialogService
{
    Task<bool> ShowAsync(string title, string message, string yesButtonText, string noButtonText, XamlRoot xamlRoot);
}
