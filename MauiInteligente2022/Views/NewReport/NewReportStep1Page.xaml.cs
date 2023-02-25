namespace MauiInteligente2022.Views;

public partial class NewReportStep1Page : BindedPage {
	public NewReportStep1Page(NewReportStep1ViewModel viewModel) {
		InitializeComponent();
		BindingContext = viewModel;
	}
}