using Android.Content;
using static System.String;

namespace MauiInteligente2022.ViewModels {
    public class LoginViewModel : BaseViewModel {
        public LoginViewModel() {
            Title = Resources.LoginTitle;
            SubTitle = Resources.LoginSubtitle;
            PageId = LOGIN_PAGE_ID;

            LoginCommand = new(async () => await LoginAsync(), () => {
                CanExecuteLogin = !IsNullOrWhiteSpace(_userName) && !IsNullOrWhiteSpace(_password);
                return CanExecuteLogin;
            });
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

        public async Task LoginAsync() {
            if(!IsBusy) {
                IsBusy = true;
                await Task.Delay(3000);
                Application.Current.MainPage = new AppShell();
                IsBusy = false;
            }
        }

        public async override Task OnAppearing() {
            await base.OnAppearing();
        }
    }
}