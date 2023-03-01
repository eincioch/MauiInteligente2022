using System.Net.Http.Json;
using static System.String;

namespace MauiInteligente2022.ViewModels {
    public class LoginViewModel : BaseViewModel {
        private readonly IServiceProvider ServiceProvider;
        private readonly HttpClient _httpClient;
        public LoginViewModel(IServiceProvider serviceProvider, HttpClient httpClient) {
            Title = Resources.LoginTitle;
            SubTitle = Resources.LoginSubtitle;
            PageId = LOGIN_PAGE_ID;
            this.ServiceProvider = serviceProvider;
            _httpClient = httpClient;

            LoginCommand = new(async () => await LoginAsync(), () => {
                CanExecuteLogin = !IsNullOrWhiteSpace(_userName) && !IsNullOrWhiteSpace(_password);
                return CanExecuteLogin;
            });

            SignupCommand = new(async () => await SignupAsync()); 

#if DEBUG
            UserName = "jacunar";
            Password = "Marilia1*";
#endif
        }

        private string _userName;

        public string UserName {
            get => _userName;
            set => SetProperty(ref _userName, value, onChanged: () => LoginCommand.ChangeCanExecute());
        }

        private string _password;

        public string Password {
            get =>_password;
            set => SetProperty(ref _password, value, onChanged: () => LoginCommand.ChangeCanExecute());
        }

        private bool canLogin;

        public bool CanExecuteLogin {
            get => canLogin;
            set => SetProperty(ref canLogin, value);
        }

        public Command LoginCommand { get; set; }

        public Command SignupCommand { get; set; }

        public async Task LoginAsync() {
            if(!IsBusy) {
                IsBusy = true;

                LoginCredentials loginCredentials = new(UserName, Password);

                var loginResponse = await _httpClient.PostAsJsonAsync("", loginCredentials);

                if (loginResponse.IsSuccessStatusCode)
                    Application.Current.MainPage = new AppShell();
                else
                    await Application.Current.MainPage.DisplayAlert(Resources.LoginUserAlertTitle,
                         Resources.LoginAlertError,
                         Resources.AcceptButton);

                IsBusy = false;
            }
        }

        public async Task SignupAsync() {
            await App.Current.MainPage.Navigation.PushAsync(
                    ServiceProvider.GetRequiredService<SignUpPage>());
        }

        public async override Task OnAppearing() {
            await base.OnAppearing();
        }
    }
}