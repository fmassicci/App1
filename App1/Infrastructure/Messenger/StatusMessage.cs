using CommunityToolkit.Mvvm.Messaging.Messages;
using System;

namespace App1.Infrastructure.Messenger;
public class StatusMessage : ValueChangedMessage<String>
{
    public StatusMessage(string value) : base(value) { }
}
