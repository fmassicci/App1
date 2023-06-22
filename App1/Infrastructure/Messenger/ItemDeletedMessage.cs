using CommunityToolkit.Mvvm.Messaging.Messages;

namespace App1.Infrastructure.Messenger;
public class ItemDeletedMessage : ValueChangedMessage<string>
{
    public ItemDeletedMessage(string value) : base(value) { }
}
