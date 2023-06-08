using Microsoft.UI.Xaml;
using System;

namespace App1.Controls;

public interface IFormControl
{
    event EventHandler<FormVisualState> VisualStateChanged;

    FormEditMode Mode { get; }
    FormVisualState VisualState { get; }

    bool IsEnabled { get; }

    bool Focus(FocusState value);

    void SetVisualState(FormVisualState visualState);
}

public enum TextDataType
{
    String,
    Integer,
    Decimal,
    Double,
    Single
}

public enum FormEditMode
{
    Auto,
    ReadOnly,
    ReadWrite
}

public enum FormVisualState
{
    Idle,
    Ready,
    Focused,
    Disabled
}
