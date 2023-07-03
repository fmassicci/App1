using CommunityToolkit.Mvvm.Messaging.Messages;

namespace App1.Infrastructure.Messenger;
public class BeginEditMessage : ValueChangedMessage<object>
{
    public BeginEditMessage(object obj) : base(obj) { }
}
