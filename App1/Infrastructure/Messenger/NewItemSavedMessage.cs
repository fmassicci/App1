using CommunityToolkit.Mvvm.Messaging.Messages;

namespace App1.Infrastructure.Messenger;
public class NewItemSavedMessage : ValueChangedMessage<object>
{
    public NewItemSavedMessage(object obj) : base(obj) { }
}
