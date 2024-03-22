using RecipeBookApp.Pages;
using RecipeBookApp.ViewModel;

namespace RecipeBookApp
{
    public partial class MainPage : ContentPage
    {
        public MainPage(MainViewModel vm)
        {
            InitializeComponent();
            BindingContext = vm;
        }

        protected override async void OnAppearing()
        {
            base.OnAppearing();

            //check if onboarding screen has to be shown
            if (Preferences.Default.ContainsKey(UIconstants.OnboardingShown))
                await Shell.Current.GoToAsync($"//{nameof(HomePage)}");
        }
    }
}