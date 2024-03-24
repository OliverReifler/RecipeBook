using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using RecipeBookApp.Models;
using RecipeBookApp.Pages;

namespace RecipeBookApp.ViewModel
{
    [QueryProperty(nameof(IsFirstVisit), nameof(IsFirstVisit))]
    public partial class LoginViewModel : BaseViewModel
    {
        [ObservableProperty]
        private bool _isRegistrationMode;

        [ObservableProperty]
        private LoginRegisterModel _model = new();

        [ObservableProperty]
        private bool _isFirstVisit;

        partial void OnIsFirstVisitChanging(bool value)
        {
            if (value)
                IsRegistrationMode = true;
        }

        [RelayCommand]
        private void ToggleMode() => IsRegistrationMode = !IsRegistrationMode;

        [RelayCommand]
        private async Task SkipForNow() => await GoToAsync($"//{nameof(HomePage)}");

        [RelayCommand]
        public async Task Submit()
        {
            if (!Model.IsValid(IsRegistrationMode))
            {
                await ShowToastAsync("All fields are mandatory");
                return;
            }
            IsBuisy = true;
            //Api call to login
            await Task.Delay(100);
            await SkipForNow();
            IsBuisy = false;
        }
    }
}