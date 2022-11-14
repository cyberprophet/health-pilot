using System;
using static Android.Provider.Settings;

namespace Bitflow;

public partial class MainPage : ContentPage
{
    public MainPage()
    {
        InitializeComponent();
    }
    async void OnCounterClicked(object sender, EventArgs e)
    {
        await ReadDeviceInfo();

        SemanticScreenReader.Announce(CounterBtn.Text);
    }
    async Task ReadDeviceInfo()
    {
        string id;

#if ANDROID
        var context = Android.App.Application.Context;

        id = Android.Provider.Settings.Secure.GetString(context.ContentResolver, Secure.AndroidId);
        
        await SecureStorage.Default.SetAsync("uuid", id);
#endif
        DisplayDeviceLabel.Text = id;
    }
}