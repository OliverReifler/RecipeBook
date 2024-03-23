using RecipeBookApp.ViewModel;

namespace RecipeBookApp.Pages;

public partial class HomePage : ContentPage
{
    public HomePage(HomeViewModel Hvm)
    {
        InitializeComponent();
        BindingContext = Hvm;
    }
}