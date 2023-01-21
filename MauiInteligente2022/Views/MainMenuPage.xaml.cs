namespace MauiInteligente2022.Views;

public partial class MainMenuPage : BindedPage {
	public MainMenuPage(MainMenuViewModel mainMenuViewModel) {
		InitializeComponent();
		BindingContext = mainMenuViewModel;
	}
}