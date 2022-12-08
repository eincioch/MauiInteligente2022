namespace MauiInteligente2022.Views;

public partial class LoginPage : ContentPage {
	public LoginPage(LoginViewModel loginViewModel) {
		InitializeComponent();
		BindingContext = loginViewModel;
	}
}