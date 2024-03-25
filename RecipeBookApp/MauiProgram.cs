using CommunityToolkit.Maui;
using Microsoft.Extensions.Logging;
using RecipeBookApp.Models;
using RecipeBookApp.Pages;
using RecipeBookApp.Services;
using RecipeBookApp.ViewModel;
using Refit;

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
                .AddSingleton<CommonService>()
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
                .AddTransient<LoginRegisterModel>()
                .AddTransient<AppAuthService>();

            ConfigureRefit(builder.Services);

            return builder.Build();
        }

        private static void ConfigureRefit(IServiceCollection services)
        {
            services.AddRefitClient<IAuthApi>()
                .ConfigureHttpClient(SetHttpClient);

            services.AddRefitClient<IRecipeBookApi>()
                .ConfigureHttpClient(SetHttpClient);

            services.AddRefitClient<IUserApi>(sp =>
            {
                var commonService = sp.GetRequiredService<CommonService>();
                return new RefitSettings()
                {
                    AuthorizationHeaderValueGetter = (_, __) => Task.FromResult(commonService.Token ?? string.Empty)
                };
            })

                .ConfigureHttpClient(SetHttpClient);

            static void SetHttpClient(HttpClient httpClient) =>
                httpClient.BaseAddress = new Uri(AppConstants.BaseApiUrl);
        }
    }
}