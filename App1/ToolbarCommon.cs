using System;

namespace App1;
public enum ToolbarButton
{
    Insert,
    Accept,
    Back,
    New,
    Edit,
    Delete,
    Cancel,
    Save,
    Select,
    Refresh
}

public enum ListToolbarMode
{
    Default,
    Cancel,
    CancelDelete
}

public enum DetailToolbarMode
{
    Default,
    BackEditDelete,
    CancelSave
}

public enum CollectionToolbarMode
{
    Default,
    BackEditDelete,
    CancelSave
}

public enum DataGridToolbarMode
{
    Default,
    Cancel,
    Filter,
    Group
}
public class ToolbarButtonClickEventArgs : EventArgs
{
    public ToolbarButtonClickEventArgs(ToolbarButton button)
    {
        ClickedButton = button;
    }

    public ToolbarButton ClickedButton { get; }
}

public delegate void ToolbarButtonClickEventHandler(object sender, ToolbarButtonClickEventArgs e);
