using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Nickvision.WinUI.MVVM.Services;

/// <summary>
/// A service for working with ComboBoxDialog.
/// </summary>
public interface IComboBoxDialogService : IService
{
    /// <summary>
    /// Shows the dialog.
    /// </summary>
    /// <param name="title">The title of the dialog</param>
    /// <param name="description">The description of the choices</param>
    /// <param name="choices">The list of choices</param>
    /// <returns>The selected string from the ComboBox. Null if canceled.</returns>
    Task<string?> ShowAsync(string title, string description, List<string> choices);
}