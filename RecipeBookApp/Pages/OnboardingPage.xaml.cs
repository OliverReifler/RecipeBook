using RecipeBookApp.ViewModel;

namespace RecipeBookApp.Pages;

public partial class OnboardingPage : ContentPage
{
    public OnboardingPage(OnboardingViewModel vm)
    {
        InitializeComponent();
        BindingContext = vm;
        Preferences.Default.Set(UIconstants.OnboardingShown, string.Empty);
    }

    private async void Clicked_Login(object sender, EventArgs e)
    {
        await Shell.Current.GoToAsync($"//{nameof(LoginPage)}");
    }

    private async void Clicked_Continue(object sender, EventArgs e)
    {
        var parameters = new Dictionary<string, object>()
        {
            [nameof(LoginViewModel.IsFirstVisit)] = true,
        };
        await Shell.Current.GoToAsync($"//{nameof(HomePage)}?{nameof(LoginViewModel.IsFirstVisit)}", parameters);
    }
}