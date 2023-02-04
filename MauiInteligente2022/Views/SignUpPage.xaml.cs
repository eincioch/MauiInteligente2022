namespace MauiInteligente2022.Views;

public partial class SignUpPage : BindedPage {
	public SignUpPage(SignUpViewModel signUpViewModel) {
		InitializeComponent();
		BindingContext = signUpViewModel;
	}
}