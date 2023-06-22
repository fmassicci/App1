using CommunityToolkit.Mvvm.Messaging.Messages;

namespace App1.Infrastructure.Messenger;
public class NewItemSavedMessage : ValueChangedMessage<string>
{
    public NewItemSavedMessage(string value) : base(value) { }
}
