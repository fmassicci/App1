using CommunityToolkit.Mvvm.Messaging.Messages;

namespace App1.Infrastructure.Messenger;
public class ItemChangedMessage : ValueChangedMessage<string>
{
    public ItemChangedMessage(string value) : base(value) { }
}
