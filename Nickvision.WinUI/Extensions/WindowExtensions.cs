using Microsoft.UI.Xaml;
using PInvoke;
using WinRT.Interop;

namespace Nickvision.WinUI.Extensions;

/// <summary>
/// Extension methods for Window.
/// </summary>
public static class WindowExtensions
{
    /// <summary>
    /// Maximizes a window.
    /// </summary>
    /// <param name="window">The window to maximize</param>
    public static void Maximize(this Window window) => User32.ShowWindow(WindowNative.GetWindowHandle(window), User32.WindowShowStyle.SW_SHOWMAXIMIZED);
}