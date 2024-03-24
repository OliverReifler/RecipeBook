namespace RecipeBookApp.Pages;

public partial class LoginPage : ContentPage
{
    public LoginPage()
    {
        InitializeComponent();
    }

    private async void Clicked_Login(object sender, EventArgs e)
    {
        await Shell.Current.GoToAsync($"//{nameof(LoginPage)}");
    }

    private async void Clicked_Skip(object sender, EventArgs e)
    {
        await Shell.Current.GoToAsync($"//{nameof(OnboardingPage)}");
    }
}