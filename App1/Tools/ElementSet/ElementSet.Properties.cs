﻿using Microsoft.UI.Xaml;
using Microsoft.UI.Xaml.Controls;
using Microsoft.UI.Xaml.Media;

namespace App1;
partial class ElementSet<T>
{
    public ElementSet<T> SetOpacity(double value) => ForEach(v => v.Opacity = value);

    public ElementSet<T> SetVisibility(Visibility value) => ForEach(v => v.Visibility = value);

    public ElementSet<T> SetForeground(Brush value) => ForEach<Control>(v => v.Foreground = value);

    public ElementSet<T> SetBackground(Brush value) => ForEach<Control>(v => v.Background = value).ForEach<Panel>(v => v.Background = value);
}
