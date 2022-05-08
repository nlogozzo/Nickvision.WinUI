![Nuget](https://img.shields.io/nuget/v/Nickvision.WinUI)

# Nickvision.WinUI
A framework for creating Nickvision applications with the Windows App SDK

# Features
- Custom controls (`ProgressDialog`, etc...)
- An update framework to keep track and notify users of new application versions and changes
- Extensions methods to make working with WinUI and other objects easier (`WindowExtensions`, `HttpClientExtensions`, etc...)
- A full MVVM framework custom built for working with WinUI and Windows App SDK:
  - Support for Commands with `DelegateCommand` and `DelegateAsyncCommand`
  - Customs services made for working with Windows App SDK and Nickvision.WinUI controls: `IIOService`, `IProgressDialogService`, `IContentDialogService`, etc...
  - A `Messenger` class to support sending messages between ViewModels

# Nuget
[Nickvision.WinUI](https://www.nuget.org/packages/Nickvision.WinUI/)
