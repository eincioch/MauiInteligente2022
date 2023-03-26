namespace MauiInteligente2022.Views;

public partial class ReportsPage : BindedPage {
	public ReportsPage(ReportsViewModel viewModel) {
		InitializeComponent();
		BindingContext = viewModel;
	}
}