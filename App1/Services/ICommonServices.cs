using App1.Contracts;
namespace App1.Services;
public interface ICommonServices
{
    IContextService ContextServices
    {
        get;
    }

    ILogService LogService
    {
        get;
    }

    IDialogService DialogService { get; }
}
