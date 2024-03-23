using RecipeBookApp.ViewModel;

namespace RecipeBookApp.Pages;

public partial class DetailPage : ContentPage
{
    public DetailPage(DetailViewModel vm)
    {
        //InitializeComponent();
        BindingContext = vm;
    }
}