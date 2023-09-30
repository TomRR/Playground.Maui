namespace SideLayout;

public static class MauiProgram
{
	public static MauiApp CreateMauiApp()
	{
		var builder = MauiApp.CreateBuilder();
		builder
			.UseMauiApp<App>()
			.UseMauiCommunityToolkit()
			.ConfigureFonts(fonts =>
			{
				fonts.AddFont("OpenSans-Regular.ttf", "OpenSansRegular");
				fonts.AddFont("OpenSans-Semibold.ttf", "OpenSansSemibold");
			});

        builder.Services.AddSingleton<MainViewModel>();

        builder.Services.AddSingleton<MainPage>();

        builder.Services.AddSingleton<BlankViewModel>();

        builder.Services.AddSingleton<BlankPage>();

		builder.Services.AddTransient<SampleDataService>();
		builder.Services.AddTransient<ListDetailDetailViewModel>();
		builder.Services.AddTransient<ListDetailDetailPage>();

        builder.Services.AddSingleton<ListDetailViewModel>();

        builder.Services.AddSingleton<ListDetailPage>();

        builder.Services.AddSingleton<DrawingViewModel>();

        builder.Services.AddSingleton<DrawingPage>();

        builder.Services.AddSingleton<WebViewViewModel>();

        builder.Services.AddSingleton<WebViewPage>();

        builder.Services.AddSingleton<SampleViewModel>();

        builder.Services.AddSingleton<SamplePage>();

        builder.Services.AddSingleton<LocalizationViewModel>();

        builder.Services.AddSingleton<LocalizationPage>();

		return builder.Build();
	}
}
