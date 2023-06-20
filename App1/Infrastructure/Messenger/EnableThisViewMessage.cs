using CommunityToolkit.Mvvm.Messaging.Messages;

namespace App1.Infrastructure.Messenger;
public class EnableThisViewMessage : ValueChangedMessage<string>
{
    public EnableThisViewMessage(string value) : base(value) { }
}
