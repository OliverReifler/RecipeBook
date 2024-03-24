using CommunityToolkit.Maui.Alerts;
using CommunityToolkit.Mvvm.ComponentModel;

namespace RecipeBookApp.ViewModel
{
    public partial class BaseViewModel : ObservableObject
    {
        [ObservableProperty]
        private bool _isBuisy;

        protected async Task GoToAsync(ShellNavigationState state) =>
            await Shell.Current.GoToAsync(state);

        protected async Task GoToAsync(ShellNavigationState state, bool animate, IDictionary<string, object> parameters) =>
            await Shell.Current.GoToAsync(state, animate, parameters);

        protected async Task GoToAsync(ShellNavigationState state, bool animate) =>
            await Shell.Current.GoToAsync(state, animate);

        protected async Task GoToAsync(ShellNavigationState state, IDictionary<string, object> parameters) =>
            await Shell.Current.GoToAsync(state, parameters);

        protected async Task ShowToastAsync(string message) =>
            await Toast.Make("All fields are mandatory").Show();

        protected async Task ShowAlertAsync(string title, string message, string buttontext) =>
            await App.Current.MainPage.DisplayAlert(title, message, buttontext);

        protected async Task ShowConfirmAsync(string title, string message, string okbuttontext, string cancelbuttontext) =>
           await App.Current.MainPage.DisplayAlert(title, message, okbuttontext, cancelbuttontext);
    }
}