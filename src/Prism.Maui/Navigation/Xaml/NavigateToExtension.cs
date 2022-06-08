﻿
namespace Prism.Navigation.Xaml;

[ContentProperty(nameof(Name))]
public class NavigateToExtension : NavigationExtensionBase
{
    public static readonly BindableProperty NameProperty =
        BindableProperty.Create(nameof(Name), typeof(string), typeof(NavigateToExtension), null);

    public string Name
    {
        get => (string)GetValue(NameProperty);
        set => SetValue(NameProperty, value);
    }

    protected override async Task HandleNavigation(INavigationParameters parameters, INavigationService navigationService)
    {
        AddKnownNavigationParameters(parameters);

        var result = await navigationService.NavigateAsync(Name, parameters);
        if (result.Exception != null)
        {
            Log(result.Exception, parameters);
        }
    }

    protected override void Log(Exception ex, INavigationParameters parameters)
    {
        //TODO: What to do with logs?
        //Xamarin.Forms.Internals.Log.Warning("Warning", $"{GetType().Name} threw an exception while navigating to '{Name}'.");
        //Xamarin.Forms.Internals.Log.Warning("Exception", ex.ToString());
    }
}
