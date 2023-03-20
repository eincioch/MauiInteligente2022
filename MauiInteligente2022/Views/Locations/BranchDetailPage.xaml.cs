using Microsoft.Maui.Maps;

namespace MauiInteligente2022.Views;

public partial class BranchDetailPage : BindedPage {
	public BranchDetailPage(BranchDetailViewModel branchDetailViewModel) {
		InitializeComponent();
		BindingContext = branchDetailViewModel;
	}
} 