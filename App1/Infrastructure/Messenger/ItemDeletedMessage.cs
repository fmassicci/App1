using CommunityToolkit.Mvvm.Messaging.Messages;

namespace App1.Infrastructure.Messenger;
public class ItemDeletedMessage : ValueChangedMessage<object>
{
    public ItemDeletedMessage(object obj) : base(obj) { }
}
