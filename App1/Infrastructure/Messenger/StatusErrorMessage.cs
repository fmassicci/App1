using CommunityToolkit.Mvvm.Messaging.Messages;

namespace App1.Infrastructure.Messenger;
public class StatusErrorMessage : ValueChangedMessage<string>
{
    public StatusErrorMessage(string value) : base(value) { }
}
