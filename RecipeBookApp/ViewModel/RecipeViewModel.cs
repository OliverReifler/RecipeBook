using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;

namespace RecipeBookApp.ViewModel
{
    public partial class RecipeViewModel : ObservableObject
    {
        public RecipeViewModel()
        {
        }

        [RelayCommand]
        private static async Task GetAllRecipes()
        {
            throw new NotImplementedException();
        }
    }
}