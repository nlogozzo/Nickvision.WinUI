using Microsoft.UI.Xaml;
using Microsoft.UI.Xaml.Controls;
using Microsoft.UI.Xaml.Media;

namespace Nickvision.WinUI.Controls;

/// <summary>
/// A control for creating a modern title bar.
/// </summary>
public sealed partial class TitleBar : Grid
{
    public static readonly DependencyProperty TitleProperty = DependencyProperty.Register("Title", typeof(string), typeof(TitleBar), new PropertyMetadata(null)); 
    public static readonly DependencyProperty IconProperty = DependencyProperty.Register("Icon", typeof(ImageSource), typeof(TitleBar), new PropertyMetadata(null));
    public static readonly DependencyProperty LeftPaddingColumnWidthProperty = DependencyProperty.Register("LeftPaddingColumnWidth", typeof(GridLength), typeof(TitleBar), new PropertyMetadata(null));
    public static readonly DependencyProperty RightPaddingColumnWidthProperty = DependencyProperty.Register("RightPaddingColumnWidth", typeof(GridLength), typeof(TitleBar), new PropertyMetadata(null));

    /// <summary>
    /// Constructs a TitleBar.
    /// </summary>
    public TitleBar() => InitializeComponent();

    /// <summary>
    /// The title to show in the TitleBar.
    /// </summary>
    public string Title
    {
        get => (string)GetValue(TitleProperty);

        set => SetValue(TitleProperty, value);
    }

    /// <summary>
    /// The source of the icon to show in the TitleBar.
    /// </summary>
    public ImageSource Icon
    {
        get => (ImageSource)GetValue(IconProperty);

        set => SetValue(IconProperty, value);
    }

    /// <summary>
    /// The left padding for the TitleBar.
    /// </summary>
    public GridLength LeftPaddingColumnWidth
    {
        get => (GridLength)GetValue(LeftPaddingColumnWidthProperty);

        set => SetValue(LeftPaddingColumnWidthProperty, value);
    }

    /// <summary>
    /// The right padding for the TitleBar.
    /// </summary>
    public GridLength RightPaddingColumnWidth
    {
        get => (GridLength)GetValue(RightPaddingColumnWidthProperty);

        set => SetValue(RightPaddingColumnWidthProperty, value);
    }
}
