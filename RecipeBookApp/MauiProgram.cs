using CommunityToolkit.Maui;
using Microsoft.Extensions.Logging;
using RecipeBookApp.Models;
using RecipeBookApp.Pages;
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
                })
                .UseMauiCommunityToolkit();

#if DEBUG
            builder.Logging.AddDebug();
#endif
            builder.Services.AddSingleton<MainPage>()
                .AddSingleton<MainViewModel>()
                .AddSingleton<IConnectivity>(Connectivity.Current)
                .AddTransient<OnboardingPage>()
                .AddTransient<OnboardingViewModel>()
                .AddTransient<DetailPage>()
                .AddTransient<DetailViewModel>()
                .AddTransient<LoginPage>()
                .AddTransient<LoginViewModel>()
                .AddTransient<HomePage>()
                .AddTransient<HomeViewModel>()
                .AddTransient<RecipesPage>()
                .AddTransient<RecipeViewModel>()
                .AddTransient<LoginRegisterModel>();

            return builder.Build();
        }
    }
}