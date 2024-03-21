using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using System.Collections.ObjectModel;

namespace RecipeBookApp.ViewModel
{
    public partial class MainViewModel : ObservableObject
    {
        public MainViewModel()
        {
            Items = new ObservableCollection<string>();
        }

        [ObservableProperty]
        private ObservableCollection<string> _items;

        [ObservableProperty]
        private string text;

        [RelayCommand]
        private void Add()
        {
            if (string.IsNullOrWhiteSpace(Text)) return;

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