namespace MauiInteligente2022.Views;

public partial class SyncPage : BindedPage {
	public SyncPage(SyncViewModel viewModel) {
		InitializeComponent();
		BindingContext= viewModel;
	}
}