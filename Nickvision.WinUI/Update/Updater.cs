using Nickvision.WinUI.Models;
using System;
using System.Net.Http;
using System.Threading.Tasks;

namespace Nickvision.WinUI.Update;

/// <summary>
/// An update manager.
/// </summary>
public class Updater
{
    private readonly AppInfo _appInfo;
    private readonly HttpClient _httpClient;
    private readonly Uri _linkToConfig;
    private UpdateConfig? _updateConfig;
    private bool _updateAvailable;

    /// <summary>
    /// Whether or not an update is available.
    /// </summary>
    public bool UpdateAvailable => _updateAvailable && _updateConfig != null;
    /// <summary>
    /// The version provided by the update, if available.
    /// </summary>
    public Version? LatestVersion => _updateConfig == null ? null : new Version(_updateConfig.LatestVersion);
    /// <summary>
    /// The changelog of the update, if available.
    /// </summary>
    public string? Changelog => _updateConfig?.Changelog;

    /// <summary>
    /// Constructs an Updater.
    /// </summary>
    /// <param name="appInfo">The AppInfo for the running application</param>
    /// <param name="httpClient">The HttpClient</param>
    /// <param name="linkToConfig">The link to the UpdateConfig file online</param>
    public Updater(AppInfo appInfo, HttpClient httpClient, Uri linkToConfig)
    {
        _appInfo = appInfo;
        _httpClient = httpClient;
        _linkToConfig = linkToConfig;
        _updateConfig = null;
        _updateAvailable = false;
    }

    /// <summary>
    /// Checks if an update is available.
    /// </summary>
    /// <returns>Whether or not an update is available</returns>
    public async Task<bool> CheckForUpdatesAsync()
    {
        _updateConfig = await UpdateConfig.LoadFromWebAsync(_appInfo, _httpClient, _linkToConfig);
        if (_updateConfig != null && LatestVersion > _appInfo.Version)
        {
            _updateAvailable = true;
        }
        return UpdateAvailable;
    }
}