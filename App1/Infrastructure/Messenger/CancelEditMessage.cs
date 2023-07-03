using CommunityToolkit.Mvvm.Messaging.Messages;

namespace App1.Infrastructure.Messenger;
public class CancelEditMessage : ValueChangedMessage<object>
{
    public CancelEditMessage(object obj) : base(obj) { }
}
