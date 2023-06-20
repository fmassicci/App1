using CommunityToolkit.Mvvm.Messaging.Messages;

namespace App1.Infrastructure.Messenger;
public class DisableThisViewMessage : ValueChangedMessage<string>
{
    public DisableThisViewMessage(string value) : base(value) { }
}
