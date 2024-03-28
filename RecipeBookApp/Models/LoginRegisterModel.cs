using CommunityToolkit.Mvvm.ComponentModel;

namespace RecipeBookApp.Models
{
    public partial class LoginRegisterModel : ObservableObject
    {
        [ObservableProperty]
        private string? _name;

        [ObservableProperty]
        private string? _password;

        [ObservableProperty]
        private string? _email;

        public bool IsNewUser => !string.IsNullOrWhiteSpace(Name);

        public bool IsValid(bool IsRegistrationMode)
        {
            {
                if (string.IsNullOrWhiteSpace(Email) || string.IsNullOrWhiteSpace(Password))
                    return false;
                if (IsRegistrationMode && string.IsNullOrWhiteSpace(Name))
                    return false;
                return true;
            }
        }
    }
}