using RecipeBookApp.ViewModel;

namespace RecipeBookApp;

public partial class DetailPage : ContentPage
{
    public DetailPage(DetailViewModel vm)
    {
        InitializeComponent();
        BindingContext = vm;
    }
}