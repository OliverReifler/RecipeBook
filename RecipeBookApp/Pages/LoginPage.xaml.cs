using RecipeBookApp.ViewModel;

namespace RecipeBookApp.Pages;

public partial class LoginPage : ContentPage
{
    private readonly LoginViewModel _lvm;

    public LoginPage(LoginViewModel Lvm)
    {
        InitializeComponent();
        _lvm = Lvm;
        BindingContext = _lvm;
    }

    private async void Clicked_Skip(object sender, EventArgs e)
    {
        await Shell.Current.GoToAsync($"//{nameof(HomePage)}");
    }
}