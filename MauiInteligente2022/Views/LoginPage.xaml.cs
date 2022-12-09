namespace MauiInteligente2022.Views;

public partial class LoginPage : BindedPage {
	public LoginPage(LoginViewModel loginViewModel) {
		InitializeComponent();
		BindingContext = loginViewModel;
	}
}