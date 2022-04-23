using Microsoft.UI.Xaml.Controls;

namespace Nickvision.WinUI.Models;

/// <summary>
/// A model of the information to be shown in a ContentDialog message.
/// </summary>
public class ContentDialogMessageInfo
{
    /// <summary>
    /// The title of the dialog.
    /// </summary>
    public string? Title { get; set; }
    /// <summary>
    /// The message of the dialog.
    /// </summary>
    public string? Message { get; set; }
    /// <summary>
    /// The text of the close button.
    /// </summary>
    public string? CloseButtonText { get; set; }
    /// <summary>
    /// The text of the primary button.
    /// </summary>
    public string? PrimaryButtonText { get; set; }
    /// <summary>
    /// The text of the secondary button.
    /// </summary>
    public string? SecondaryButtonText { get; set; }
    /// <summary>
    /// The default button of the dialog.
    /// </summary>
    public ContentDialogButton DefaultButton { get; set; }

    /// <summary>
    /// Constructs a ContentDialogMessageInfo.
    /// </summary>
    /// <param name="title">The title of the dialog</param>
    /// <param name="message">The message of the dialog</param>
    /// <param name="closeButtonText">The text of the close button</param>
    /// <param name="primaryButtonText">The text of the primary button</param>
    /// <param name="secondaryButtonText">The text of the secondary button</param>
    /// <param name="defaultButton">The default button of the dialog</param>
    public ContentDialogMessageInfo(string? title = null, string? message = null, string? closeButtonText = null, string? primaryButtonText = null, string? secondaryButtonText = null, ContentDialogButton defaultButton = ContentDialogButton.Close)
    {
        Title = title;
        Message = message;
        CloseButtonText = closeButtonText;
        PrimaryButtonText = primaryButtonText;
        SecondaryButtonText = secondaryButtonText;
        DefaultButton = defaultButton;
    }
}