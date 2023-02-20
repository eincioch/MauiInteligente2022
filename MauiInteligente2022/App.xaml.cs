namespace MauiInteligente2022;

public partial class App : Application {
	public App(SplashPage page) {
		InitializeComponent();

		MainPage = new NavigationPage(page);
	}
}