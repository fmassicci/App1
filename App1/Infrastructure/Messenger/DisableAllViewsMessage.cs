using CommunityToolkit.Mvvm.Messaging.Messages;

namespace App1.Infrastructure.Messenger;
public class DisableAllViewsMessage : ValueChangedMessage<string>
{
    public DisableAllViewsMessage(string value) : base(value) { }
}
