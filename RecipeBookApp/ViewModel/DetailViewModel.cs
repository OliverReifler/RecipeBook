using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;

namespace RecipeBookApp.ViewModel
{
    [QueryProperty("Text", "Text")]
    public partial class DetailViewModel : ObservableObject
    {
        [ObservableProperty]
        private string? text;

        [RelayCommand]
        private static async Task GoToPreviousPage()
        {
            await Shell.Current.GoToAsync("..");
        }
    }
}