using MauiUi.ViewModels;
using MauiUi.Views;
using Microsoft.Extensions.Logging;

namespace MauiUi;
public static class MauiProgram
{
    public static MauiApp CreateMauiApp()
    {
        var builder = MauiApp.CreateBuilder();
        builder
            .UseMauiApp<App>()
            .ConfigureFonts(fonts =>
            {
                fonts.AddFont("OpenSans-Regular.ttf", "OpenSansRegular");
                fonts.AddFont("OpenSans-Semibold.ttf", "OpenSansSemibold");
            });

#if DEBUG
        builder.Logging.AddDebug();
#endif
        builder.Services.AddHybridWebView();

        builder.Services.AddDependencies();

        return builder.Build();
    }
}

public static class Extensions
{
    public static IServiceCollection AddDependencies(this IServiceCollection services)
    {
        services.AddTransient<TodoViewModel>();
        services.AddTransient<TodoPage>();

        return services;
    }    
    
}