using Microsoft.Extensions.Logging;
using zad7.Services;
using zad7.ViewModels;

namespace zad7;

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

        ConfigureServices(builder.Services);
        return builder.Build();
    }
    
    private static void ConfigureServices(IServiceCollection services)
    {
        ConfigureAppServices(services);
        ConfigureViewModels(services);
        ConfigureViews(services);
    }


    private static void ConfigureAppServices(IServiceCollection services)
    {
        services.AddSingleton<IBooksService, BooksService>();
    }

    private static void ConfigureViewModels(IServiceCollection services)
    {
        services.AddTransient<MainViewModel>();
        services.AddTransient<AddABookViewModel>();
        services.AddTransient<BookListViewModel>();
        services.AddTransient<BookDetailsViewModel>();
        services.AddTransient<EditBookViewModel>();
    }

    private static void ConfigureViews(IServiceCollection services)
    {
        services.AddSingleton<MainPage>();
        services.AddTransient<AddABookPage>();
        services.AddTransient<BookListPage>();
        services.AddTransient<BookDetailsPage>();
        services.AddTransient<EditBookPage>();
    }
}