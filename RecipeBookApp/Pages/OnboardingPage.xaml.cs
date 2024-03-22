using RecipeBookApp.ViewModel;

namespace RecipeBookApp.Pages;

public partial class OnboardingPage : ContentPage
{
    public OnboardingPage(OnboardingViewModel vm)
    {
        InitializeComponent();
        BindingContext = vm;
    }
}