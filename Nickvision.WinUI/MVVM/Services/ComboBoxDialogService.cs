using Microsoft.UI.Xaml;
using Nickvision.WinUI.Controls;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Nickvision.WinUI.MVVM.Services;

/// <summary>
/// A service for working with ComboBoxDialog.
/// </summary>
public class ComboBoxDialogService : IComboBoxDialogService
{
    private readonly XamlRoot _xamlRoot;

    /// <summary>
    /// Constructs a ComboBoxDialogService.
    /// </summary>
    /// <param name="xamlRoot">The XamlRoot of the host ui object</param>
    public ComboBoxDialogService(XamlRoot xamlRoot) => _xamlRoot = xamlRoot;

    /// <summary>
    /// Shows the dialog.
    /// </summary>
    /// <param name="title">The title of the dialog</param>
    /// <param name="description">The description of the choices</param>
    /// <param name="choices">The list of choices</param>
    /// <returns>The selected string from the ComboBox. Null if canceled.</returns>
    public async Task<string?> ShowAsync(string title, string description, List<string> choices)
    {
        var comboBoxDialog = new ComboBoxDialog(title, description, choices);
        comboBoxDialog.XamlRoot = _xamlRoot;
        return await comboBoxDialog.ShowAsync();
    }
}