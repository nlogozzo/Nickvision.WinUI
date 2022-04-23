using Microsoft.UI.Xaml;
using Microsoft.UI.Xaml.Controls;
using Nickvision.WinUI.Models;
using System;
using System.Threading.Tasks;

namespace Nickvision.WinUI.MVVM.Services;

/// <summary>
/// A service for working with ContentDialog.
/// </summary>
public class ContentDialogService : IContentDialogService
{
    private readonly XamlRoot _xamlRoot;

    /// <summary>
    /// Constructs a ContentDialogService.
    /// </summary>
    /// <param name="xamlRoot">The XamlRoot of the host ui object</param>
    public ContentDialogService(XamlRoot xamlRoot) => _xamlRoot = xamlRoot;

    /// <summary>
    /// Shows a message in the form of a content dialog.
    /// </summary>
    /// <param name="messageInfo">The message info</param>
    /// <returns>The result from the content dialog</returns>
    public async Task<ContentDialogResult> ShowMessageAsync(ContentDialogMessageInfo messageInfo)
    {
        return await new ContentDialog()
        {
            Title = messageInfo.Title,
            Content = messageInfo.Message,
            CloseButtonText = messageInfo.CloseButtonText,
            PrimaryButtonText = messageInfo.PrimaryButtonText,
            SecondaryButtonText = messageInfo.SecondaryButtonText,
            DefaultButton = messageInfo.DefaultButton,
            XamlRoot = _xamlRoot
        }.ShowAsync();
    }

    /// <summary>
    /// Shows a custom content dialog.
    /// </summary>
    /// <param name="viewModel">The ViewModel of the custom content dialog</param>
    /// <typeparam name="T">The type of the ViewModel</typeparam>
    /// <returns>The result from the content dialog</returns>
    public async Task<ContentDialogResult> ShowCustomAsync<T>(T viewModel) where T : ViewModelBase
    {
        var contentDialog = viewModel.GetContentDialogView();
        if (contentDialog != null)
        {
            contentDialog.XamlRoot = _xamlRoot;
            return await contentDialog.ShowAsync();
        }
        return ContentDialogResult.None;
    }
}