using CommunityToolkit.Mvvm.Messaging.Messages;

namespace App1.Infrastructure.Messenger;
public class BeginEditMessage : ValueChangedMessage<string>
{
    public BeginEditMessage(string value) : base(value) { }
}
