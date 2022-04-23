using Microsoft.UI.Xaml;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Windows.Storage.Pickers;
using WinRT.Interop;

namespace Nickvision.WinUI.MVVM.Services;

public class IOService : IIOService
{
    private readonly Window _parent;

    /// <summary>
    /// Constructs an IOService.
    /// </summary>
    /// <param name="parent">The parent window</param>
    public IOService(Window parent)
    {
        _parent = parent;
    }

    /// <summary>
    /// Shows an open file dialog.
    /// </summary>
    /// <param name="filters">The filters of the dialog</param>
    /// <returns>The list of paths of selected files</returns>
    public async Task<string?> ShowOpenFileDialogAsync(List<string> filters)
    {
        var fileOpenPicker = new FileOpenPicker();
        InitializeWithWindow.Initialize(fileOpenPicker, WindowNative.GetWindowHandle(_parent));
        foreach(var filter in filters)
        {
            fileOpenPicker.FileTypeFilter.Add(filter);
        }
        var file = await fileOpenPicker.PickSingleFileAsync();
        return file == null ? null : file.Path;
    }

    /// <summary>
    /// Shows an open folder dialog.
    /// </summary>
    /// <returns>The path of the selected folder</returns>
    public async Task<string?> ShowOpenFolderDialogAsync()
    {
        var folderPicker = new FolderPicker();
        InitializeWithWindow.Initialize(folderPicker, WindowNative.GetWindowHandle(_parent));
        folderPicker.FileTypeFilter.Add("*");
        var folder = await folderPicker.PickSingleFolderAsync();
        return folder == null ? null : folder.Path;
    }

    /// <summary>
    /// Shows a save file dialog.
    /// </summary>
    /// <param name="filters">The filters of the dialog</param>
    /// <param name="suggestedFileName">The default file name to use for the new file</param>
    /// <returns>The path of the saved folder</returns>
    public async Task<string?> ShowSaveFileDialogAsync(Dictionary<string, string> filters, string suggestedFileName)
    {
        var fileSavePicker = new FileSavePicker();
        InitializeWithWindow.Initialize(fileSavePicker, WindowNative.GetWindowHandle(_parent));
        foreach (var filter in filters)
        {
            fileSavePicker.FileTypeChoices.Add(filter.Key, new List<string>() { filter.Value });
        }
        fileSavePicker.SuggestedFileName = suggestedFileName;
        var file = await fileSavePicker.PickSaveFileAsync();
        return file == null ? null : file.Path;
    }
}
