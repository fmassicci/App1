using App1.Contracts;
using App1.Infrastructure.Messenger;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Messaging;
using System;
using System.Diagnostics;

namespace App1.ViewModels;
public class ViewModelBase : ObservableObject
{
    private Stopwatch _stopwatch = new();

    public ViewModelBase(ICommonServices commonServices)
    {
        ContextService = commonServices.ContextService;
        NavigationService = commonServices.NavigationService;
        MessageService = commonServices.MessageService;
        DialogService = commonServices.DialogService;
        LogService = commonServices.LogService;

        WeakReferenceMessenger.Default.Register<StatusMessage>(this, (r, m) =>
        {
            StatusMessage(m.Value);
        });

        WeakReferenceMessenger.Default.Register<StatusErrorMessage>(this, (r, m) =>
        {
            StatusError(m.Value);
        });

        WeakReferenceMessenger.Default.Register<DisableAllViewsMessage>(this, (r, m) =>
        {
            DisableAllViews(m.Value);
        });

        WeakReferenceMessenger.Default.Register<DisableThisViewMessage>(this, (r, m) =>
        {
            DisableThisView(m.Value);
        });

        WeakReferenceMessenger.Default.Register<EnableAllViewsMessage>(this, (r, m) =>
        {
            EnableAllViews(m.Value);
        });

        WeakReferenceMessenger.Default.Register<EnableOtherViewsMessage>(this, (r, m) =>
        {
            EnableOtherViews(m.Value);
        });


    }

    public IContextService ContextService
    {
        get;
    }
    public INavigationService NavigationService
    {
        get;
    }
    public IMessageService MessageService
    {
        get;
    }
    public IDialogService DialogService
    {
        get;
    }
    public ILogService LogService
    {
        get;
    }

    public virtual string Title => string.Empty;

    public bool IsMainView => true;

    public async void LogInformation(string source, string action, string message, string description)
    {
        await LogService.WriteAsync(LogType.Information, source, action,
            message, description);
    }

    public async void LogWarning(string source, string action, string message, string description)
    {
        await LogService.WriteAsync(LogType.Warning, source, action, message, description);
    }

    public void LogException(string source, string action, Exception exception)
    {
        LogError(source, action, exception.Message, exception.ToString());
    }

    public async void LogError(string source, string action, string message, string description)
    {
        await LogService.WriteAsync(LogType.Error, source, action, message, description);
    }

    public void StartStatusMessage(string message)
    {
        StatusMessage(message);
        _stopwatch.Reset();
        _stopwatch.Start();
    }
    public void EndStatusMessage(string message)
    {
        _stopwatch.Stop();
        StatusMessage($"{message}({_stopwatch.Elapsed.TotalSeconds:#0.000} seconds)");
    }

    public void StatusReady()
    {
        WeakReferenceMessenger.Default.Send("StatusMessage", "Ready");
        //MessageService.Send(this, "StatusMessage", "Ready");
    }

    public void StatusMessage(string message)
    {
        Microsoft.AppCenter.Analytics.Analytics.TrackEvent(message);
        WeakReferenceMessenger.Default.Send("StatusMessage", message);
        //MessageService.Send(this, "StatusMessage", message);
    }
    public void StatusError(string message)
    {
        Microsoft.AppCenter.Analytics.Analytics.TrackEvent(message);
        WeakReferenceMessenger.Default.Send("StatusError", message);
        //MessageService.Send(this, "StatusError", message);
    }

    public void EnableThisView(string message = null)
    {
        message ??= "Ready";
        WeakReferenceMessenger.Default.Send("EnableThisView", message);
        //MessageService.Send(this, "EnableThisView", message);
    }
    public void DisableThisView(string message)
    {
        WeakReferenceMessenger.Default.Send("DisableThisView", message);
        //MessageService.Send(this, "DisableThisView", message);
    }

    public void EnableOtherViews(string message = null)
    {
        message ??= "Ready";
        WeakReferenceMessenger.Default.Send("EnableOtherViews", message);
        //MessageService.Send(this, "EnableOtherViews", message);
    }
    public void DisableOtherViews(string message)
    {
        WeakReferenceMessenger.Default.Send("DisableOtherViews", message);
        //MessageService.Send(this, "DisableOtherViews", message);
    }

    public void EnableAllViews(string message = null)
    {
        message ??= "Ready";
        WeakReferenceMessenger.Default.Send("EnableAllViews", message);
        //MessageService.Send(this, "EnableAllViews", message);
    }
    public void DisableAllViews(string message)
    {
        WeakReferenceMessenger.Default.Send("DisableAllViews", message);
        //MessageService.Send(this, "DisableAllViews", message);
    }
}