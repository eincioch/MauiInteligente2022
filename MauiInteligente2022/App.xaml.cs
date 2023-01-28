namespace MauiInteligente2022;

public partial class App : Application {
	public App(BranchDetailPage page) {
		InitializeComponent();

		MainPage = new NavigationPage(page);
	}
}