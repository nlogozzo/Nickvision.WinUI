using Microsoft.UI.Xaml;
using System;
using Vanara.PInvoke;
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
    public static void Maximize(this Window window) => User32.ShowWindow(WindowNative.GetWindowHandle(window), ShowWindowCommand.SW_SHOWMAXIMIZED);

    /// <summary>
    /// Changes the window's title bar to a dark theme.
    /// </summary>
    /// <param name="window">The window to change theme</param>
    public static void ApplyDarkTitleBar(this Window window)
    {
        DwmApi.DwmSetWindowAttribute(WindowNative.GetWindowHandle(window), (DwmApi.DWMWINDOWATTRIBUTE)20, new IntPtr(1), sizeof(int));
        UxTheme.SetWindowTheme(WindowNative.GetWindowHandle(window), "DarkMode_Explorer", null);
    }
}