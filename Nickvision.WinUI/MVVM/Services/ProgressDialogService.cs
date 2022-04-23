using Microsoft.UI.Xaml;
using Nickvision.WinUI.Controls;
using System;
using System.Threading.Tasks;

namespace Nickvision.WinUI.MVVM.Services;

/// <summary>
/// A service for working with ProgressDialog.
/// </summary>
public class ProgressDialogService : IProgressDialogService
{
    private readonly XamlRoot _xamlRoot;

    /// <summary>
    /// Constructs a ProgressDialogService.
    /// </summary>
    /// <param name="xamlRoot">The XamlRoot of the host ui object</param>
    public ProgressDialogService(XamlRoot xamlRoot) => _xamlRoot = xamlRoot;

    /// <summary>
    /// Shows the dialog.
    /// </summary>
    /// <param name="description">The description of the long task</param>
    /// <param name="action">The long task to complete</param>
    /// <returns></returns>
    public async Task ShowAsync(string description, Func<Task> action)
    {
        var progressDialog = new ProgressDialog(description, action);
        progressDialog.XamlRoot = _xamlRoot;
        await progressDialog.ShowAsync();
    }
}