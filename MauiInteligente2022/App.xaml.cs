namespace MauiInteligente2022;

public partial class App : Application {
	public App(AboutPage page) {
		InitializeComponent();

		MainPage = new NavigationPage(page);
	}
}