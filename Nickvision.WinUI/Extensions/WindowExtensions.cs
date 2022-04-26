using Microsoft.UI.Xaml;
using System;
using System.Runtime.InteropServices;
using Vanara.PInvoke;
using WinRT.Interop;

namespace Nickvision.WinUI.Extensions;

/// <summary>
/// Extension methods for Window.
/// </summary>
public static class WindowExtensions
{
    [DllImport("dwmapi.dll")]
    private static extern int DwmSetWindowAttribute(IntPtr hwnd, int dwAttribute, ref int pvAttribute, int cbAttribute);

    /// <summary>
    /// Maximizes a window.
    /// </summary>
    /// <param name="window">The window to maximize</param>
    public static void Maximize(this Window window) => User32.ShowWindow(WindowNative.GetWindowHandle(window), ShowWindowCommand.SW_SHOWMAXIMIZED);

    /// <summary>
    /// Changes the window's title bar to a dark theme.
    /// </summary>
    /// <param name="window">The window to change theme</param>
    public static void ApplyDarkWin32TitleBar(this Window window)
    {
        var hwnd = WindowNative.GetWindowHandle(window);
        var enabled = 1;
        DwmSetWindowAttribute(hwnd, 20, ref enabled, sizeof(int));
        UxTheme.SetWindowTheme(hwnd, "DarkMode_Explorer", null);
    }
}