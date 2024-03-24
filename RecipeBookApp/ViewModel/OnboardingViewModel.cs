using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using RecipeBookApp.Pages;

namespace RecipeBookApp.ViewModel
{
    public partial class OnboardingViewModel : ObservableObject
    {
        [RelayCommand]
        private async Task NavigateToHomePage()
        {
            await Shell.Current.GoToAsync($"//{nameof(HomePage)}");
        }

        [RelayCommand]
        private async Task NavigateToLoginPage()
        {
            await Shell.Current.GoToAsync($"//{nameof(LoginPage)}");
        }

        [RelayCommand]
        private async Task NavigateToRegisterPage()
        {
            await Shell.Current.GoToAsync($"//{nameof(LoginPage)}");
        }
    }
}