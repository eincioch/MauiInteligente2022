namespace MauiInteligente2022.Views;

public partial class AboutPage : BindedPage {
	public AboutPage(AboutViewModel aboutViewModel) {
		InitializeComponent();
		BindingContext = aboutViewModel;
	}
}