using RecipeBookApp.ViewModel;

namespace RecipeBookApp.Pages;

public partial class RecipesPage : ContentPage
{
    public RecipesPage(MainViewModel vm)
    {
        InitializeComponent();
        BindingContext = vm;
    }
}