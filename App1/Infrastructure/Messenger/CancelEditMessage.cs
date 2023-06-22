using CommunityToolkit.Mvvm.Messaging.Messages;

namespace App1.Infrastructure.Messenger;
public class CancelEditMessage : ValueChangedMessage<string>
{
    public CancelEditMessage(string value) : base(value) { }
}
