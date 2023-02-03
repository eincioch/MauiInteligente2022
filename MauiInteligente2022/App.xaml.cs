namespace MauiInteligente2022;

public partial class App : Application {
	public App(SignUpPage page) {
		InitializeComponent();

		MainPage = new NavigationPage(page);
	}
}