using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using RecipeBookApp.Pages;
using System.Collections.ObjectModel;

namespace RecipeBookApp.ViewModel
{
    public partial class MainViewModel : ObservableObject
    {
        private readonly IConnectivity connectivity;

        public MainViewModel(IConnectivity connectivity)
        {
            Items = new ObservableCollection<string>();
            this.connectivity = connectivity;
        }

        [ObservableProperty]
        private ObservableCollection<string> _items;

        [ObservableProperty]
        private string text;

        [RelayCommand]
        private async Task Add()
        {
            if (string.IsNullOrWhiteSpace(Text)) return;

            if (connectivity.NetworkAccess != NetworkAccess.Internet)
            {
                await Shell.Current.DisplayAlert("Connection Issue", "You have no internet connection", "OK");
                return;
            }
            Items.Add(Text);
            Text = string.Empty;
        }

        [RelayCommand]
        private void Delete(string s)
        {
            Items.Remove(s);
        }

        [RelayCommand]
        private async Task Tap(string s)
        {
            await Shell.Current.GoToAsync($"{nameof(DetailPage)}?Text={s}");
        }
    }
}