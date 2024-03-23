using RecipeBookApp.ViewModel;

namespace RecipeBookApp.Pages;

public partial class RecipesPage : ContentPage
{
    public RecipesPage(MainViewModel Mvm)
    {
        //InitializeComponent();
        BindingContext = Mvm;
    }
}