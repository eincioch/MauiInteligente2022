namespace MauiInteligente2022.Views;

public partial class LocationsPage : BindedPage {
	public LocationsPage(LocationsViewModel locationsViewModel) {
		InitializeComponent();
		BindingContext = locationsViewModel;
	}
}