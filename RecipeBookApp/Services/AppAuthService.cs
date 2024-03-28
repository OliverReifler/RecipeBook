using RecipeBook.Domain.Dtos;
using RecipeBookApp.Models;

namespace RecipeBookApp.Services
{
    public class AppAuthService
    {
        private readonly CommonService _commonService;
        private readonly IAuthApi _authApi;

        public AppAuthService(CommonService commonService, IAuthApi authApi)
        {
            _authApi = authApi;
            _commonService = commonService;
        }

        public async Task<bool> LoginRegisterAsync(LoginRegisterModel lrm)
        {
            ApiResponse<AuthResponseDto> apiResponse = null;
            try
            {
                if (lrm.IsNewUser) //Go to register
                {
                    apiResponse = await _authApi.RegisterAsync(new RegisterRequestDto()
                    {
                        Name = lrm.Name,
                        Email = lrm.Email,
                        Password = lrm.Password,
                    });
                }
                else //Go to Login
                {
                    apiResponse = await _authApi.LoginAsync(new LoginRequestDto()
                    {
                        Email = lrm.Email,
                        Password = lrm.Password,
                    });
                }
            }
            catch (Refit.ApiException ex)
            {
                await App.Current.MainPage.DisplayAlert("Error", ex.Message, "Ok");
                return false;
            }
            if (!apiResponse.IsSuccess)
            {
                await App.Current.MainPage.DisplayAlert("Error", apiResponse.Message, "Ok");
                return false;
            }
            var user = new LoggedInUser(apiResponse.Data.UserId, apiResponse.Data.Name, apiResponse.Data.Token);
            SetUser(user);
            _commonService.SetToken(apiResponse.Data.Token);
            return true;
        }

        private void SetUser(LoggedInUser user) =>
            Preferences.Default.Set(UIconstants.UserInfo, user.ToJson());

        public async Task Logout()
        {
            _commonService.SetToken(null);
            Preferences.Default.Remove(UIconstants.UserInfo);
        }

        public LoggedInUser GetUser()
        {
            var userJson = Preferences.Default.Get(UIconstants.UserInfo, string.Empty);
            return LoggedInUser.LoadFromJson(userJson);
        }

        public bool IsLoggedIn() => Preferences.Default.ContainsKey(UIconstants.UserInfo);
    }
}