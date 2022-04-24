using System;

namespace Nickvision.WinUI.Models;

/// <summary>
/// A model of the information of an application.
/// </summary>
public class AppInfo
{
    /// <summary>
    /// The name of the app.
    /// </summary>
    public string Name { get; set; }
    /// <summary>
    /// The description of the app.
    /// </summary>
    public string Description { get; set; }
    /// <summary>
    /// The version of the app.
    /// </summary>
    public Version Version { get; set; }

    /// <summary>
    /// Constructs a new AppInfo.
    /// </summary>
    /// <param name="name">The name of the app</param>
    /// <param name="description">The description of the app</param>
    /// <param name="version">The version of the app</param>
    public AppInfo(string name = "", string description = "", Version? version = null)
    {
        Name = name;
        Description = description;
        Version = version ?? new Version(0, 0, 0);
    }
}
