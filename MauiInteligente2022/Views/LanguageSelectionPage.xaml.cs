namespace MauiInteligente2022.Views;

public partial class LanguageSelectionPage : BindedPage {
	public LanguageSelectionPage(LanguageSelectionViewModel viewModel) {
		InitializeComponent();
		BindingContext = viewModel;
	}
}