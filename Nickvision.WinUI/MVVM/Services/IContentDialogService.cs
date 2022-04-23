using Microsoft.UI.Xaml.Controls;
using Nickvision.WinUI.Models;
using System.Threading.Tasks;

namespace Nickvision.WinUI.MVVM.Services;

/// <summary>
/// A service for working with ContentDialog.
/// </summary>
public interface IContentDialogService : IService
{
    /// <summary>
    /// Shows a message in the form of a content dialog.
    /// </summary>
    /// <param name="messageInfo">The message info</param>
    /// <returns>The result from the content dialog</returns>
    Task<ContentDialogResult> ShowMessageAsync(ContentDialogMessageInfo messageInfo);

    /// <summary>
    /// Shows a custom content dialog.
    /// </summary>
    /// <param name="viewModel">The ViewModel of the custom content dialog</param>
    /// <typeparam name="T">The type of the ViewModel</typeparam>
    /// <returns>The result from the content dialog</returns>
    Task<ContentDialogResult> ShowCustomAsync<T>(T viewModel) where T : ViewModelBase;
}