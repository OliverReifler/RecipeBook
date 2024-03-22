using Microsoft.Extensions.Logging;
using RecipeBookApp.ViewModel;

namespace RecipeBookApp
{
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
            builder.Services.AddSingleton<MainPage>()
                .AddSingleton<MainViewModel>()
                .AddSingleton<IConnectivity>(Connectivity.Current)
                .AddTransient<DetailPage>()
                .AddTransient<DetailViewModel>();
            return builder.Build();
        }
    }
}