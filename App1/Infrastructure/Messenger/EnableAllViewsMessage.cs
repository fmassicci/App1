using CommunityToolkit.Mvvm.Messaging.Messages;

namespace App1.Infrastructure.Messenger;
public class EnableAllViewsMessage : ValueChangedMessage<string>
{
    public EnableAllViewsMessage(string value) : base(value) { }
}
