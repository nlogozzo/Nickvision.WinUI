using System.Collections.Generic;
using System.Threading.Tasks;

namespace Nickvision.WinUI.MVVM.Services;

/// <summary>
/// A service for working with IO dialogs.
/// </summary>
public interface IIOService : IService
{
    /// <summary>
    /// Shows an open file dialog.
    /// </summary>
    /// <param name="filters">The filters of the dialog</param>
    /// <returns>The list of paths of selected files</returns>
    Task<string?> ShowOpenFileDialogAsync(List<string> filters);

    /// <summary>
    /// Shows an open folder dialog.
    /// </summary>
    /// <returns>The path of the selected folder</returns>
    Task<string?> ShowOpenFolderDialogAsync();

    /// <summary>
    /// Shows a save file dialog.
    /// </summary>
    /// <param name="filters">The filters of the dialog</param>
    /// <param name="suggestedFileName">The default file name to use for the new file</param>
    /// <returns>The path of the saved folder</returns>
    Task<string?> ShowSaveFileDialogAsync(Dictionary<string, string> filters, string suggestedFileName);
}