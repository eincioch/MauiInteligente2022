namespace MauiInteligente2022.ViewModels {
    internal class LoginViewModel : BaseViewModel {
        public LoginViewModel() {
            Title = Resources.LoginTitle;
            SubTitle = Resources.LoginSubtitle;
            PageId = LOGIN_PAGE; 

            //LoginCommand = new(async() await LoginAsync(), () => !IsNull)
        }

        public async override Task OnAppearing() {
            await base.OnAppearing();
        }
    }
}