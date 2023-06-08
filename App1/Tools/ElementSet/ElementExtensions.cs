using Microsoft.UI.Xaml;
using System.Linq;

namespace App1;
public static class ElementExtensions
{
    public static void Show(this FrameworkElement elem, bool visible = true)
    {
        elem.Visibility = visible ? Visibility.Visible : Visibility.Collapsed;
    }

    public static void Hide(this FrameworkElement elem)
    {
        elem.Visibility = Visibility.Collapsed;
    }

    public static bool IsCategory(this FrameworkElement elem, string category)
    {
        if (elem.Tag is string tag)
        {
            return tag.Split(' ').Any(s => s == category);
        }
        return false;
    }

    public static bool IsCategory(this FrameworkElement elem, params string[] categories)
    {
        if (elem.Tag is string tag)
        {
            return tag.Split(' ').Any(s => categories.Any(c => s == c.Trim()));
        }
        return false;
    }

}
