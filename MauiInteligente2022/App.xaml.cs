namespace MauiInteligente2022;

public partial class App : Application {
	public App(LoginPage loginPage) {
		InitializeComponent();

		MainPage = new NavigationPage(loginPage);
	}
}