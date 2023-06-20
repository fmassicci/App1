using CommunityToolkit.Mvvm.Messaging.Messages;

namespace App1.Infrastructure.Messenger;
public class EnableOtherViewsMessage : ValueChangedMessage<string>
{
    public EnableOtherViewsMessage(string value) : base(value) { }
}
