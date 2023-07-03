using CommunityToolkit.Mvvm.Messaging.Messages;

namespace App1.Infrastructure.Messenger;
public class ItemChangedMessage : ValueChangedMessage<object>
{
    public ItemChangedMessage(object obj) : base(obj) { }
}
