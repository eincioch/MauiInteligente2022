namespace MauiInteligente2022;

public partial class App : Application {
	public App(MainMenuPage page) {
		InitializeComponent();

		MainPage = new NavigationPage(page);
	}
}