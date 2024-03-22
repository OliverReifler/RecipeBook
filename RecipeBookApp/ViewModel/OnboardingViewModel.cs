using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;

namespace RecipeBookApp.ViewModel
{
    public partial class OnboardingViewModel : ObservableObject
    {
        [RelayCommand]
        private static async Task SkipToHomePage()
        {
            await Shell.Current.GoToAsync("Home");
        }
    }
}