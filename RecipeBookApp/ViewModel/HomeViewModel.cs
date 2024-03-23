using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using RecipeBookApp.Pages;

namespace RecipeBookApp.ViewModel
{
    public partial class HomeViewModel : ObservableObject
    {
        [RelayCommand]
        private static async Task GoToOnboarding()
        {
            await Shell.Current.GoToAsync($"//{nameof(OnboardingPage)}");
        }
        //TODO:Doesnt work. the details page method does. why?
        [RelayCommand]
        private static async Task GoToPrevious()
        {
            await Shell.Current.GoToAsync("..");
        }
    }
}