using System;
using System.Threading.Tasks;

namespace App1.Services;
public interface IContextService
{
    void Initialize();
    Task RunAsync(Action action);
}
