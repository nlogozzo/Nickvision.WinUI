using Microsoft.UI;
using Microsoft.UI.Windowing;
using Microsoft.UI.Xaml;
using Microsoft.UI.Xaml.Media;
using Nickvision.WinUI.Controls;
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
    /// Gets the AppWindow object associated with the provided Window object.
    /// </summary>
    /// <param name="window">The Window object</param>
    /// <returns></returns>
    public static AppWindow GetAppWindow(this Window window) => AppWindow.GetFromWindowId(Win32Interop.GetWindowIdFromWindow(WindowNative.GetWindowHandle(window)));

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

    /// <summary>
    /// Changes the window's title bar to the custom title bar.
    /// </summary>
    /// <param name="window">The window to change</param>
    /// <param name="titleBar">The title bar to use</param>
    public static void ApplyCustomTitleBar(this Window window, TitleBar titleBar)
    {
        var appWindow = window.GetAppWindow();
        if(AppWindowTitleBar.IsCustomizationSupported())
        {
            window.Title = titleBar.Title;
            appWindow.Title = titleBar.Title;
            appWindow.TitleBar.ExtendsContentIntoTitleBar = true;
            appWindow.TitleBar.ButtonBackgroundColor = Colors.Transparent;
            appWindow.TitleBar.ButtonInactiveBackgroundColor = Colors.Transparent;
            appWindow.TitleBar.ButtonForegroundColor = ((SolidColorBrush)Application.Current.Resources["WindowCaptionForeground"]).Color;
            titleBar.LeftPaddingColumnWidth = new GridLength(appWindow.TitleBar.LeftInset);
            titleBar.RightPaddingColumnWidth = new GridLength(appWindow.TitleBar.RightInset);
            window.Activated += (sender, args) =>
            {
                var foreground = (SolidColorBrush)Application.Current.Resources[args.WindowActivationState == WindowActivationState.Deactivated ? "WindowCaptionForegroundDisabled" : "WindowCaptionForeground"];
                titleBar.TitleForeground = foreground;
                appWindow.TitleBar.ButtonForegroundColor = foreground.Color;
            };
        }
        else
        {
            appWindow.TitleBar.ExtendsContentIntoTitleBar = false;
            titleBar.Visibility = Visibility.Collapsed;
        }
    }
}