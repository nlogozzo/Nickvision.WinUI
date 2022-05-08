using Microsoft.UI.Xaml.Controls;
using Nickvision.WinUI.MVVM;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Nickvision.WinUI.Controls;

/// <summary>
/// A control for displaying choices for selection in a dialog.
/// </summary>
public sealed partial class ComboBoxDialog : ContentDialog, IHideable
{
    /// <summary>
    /// Constructs a ComboBoxDialog.
    /// </summary>
    /// <param name="title">The title of the dialog</param>
    /// <param name="description">The description of the choices</param>
    /// <param name="choices">The list of choices</param>
    public ComboBoxDialog(string title, string description, List<string> choices)
    {
        InitializeComponent();
        Title = title;
        LblDescription.Text = description;
        CmbChoices.ItemsSource = choices;
        CmbChoices.SelectedIndex = 0;
    }

    /// <summary>
    /// Shows the dialog.
    /// </summary>
    /// <returns>The selected string from the ComboBox. Null if canceled.</returns>
    public new async Task<string?> ShowAsync()
    {
        var result = await base.ShowAsync();
        if(result == ContentDialogResult.Primary)
        {
            return CmbChoices.SelectedItem as string;
        }
        return null;
    }
}
