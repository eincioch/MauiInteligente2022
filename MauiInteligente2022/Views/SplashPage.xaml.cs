namespace MauiInteligente2022.Views;

public partial class SplashPage : BindedPage {
	public SplashPage(SplashViewModel splashViewModel) {
		InitializeComponent();
		BindingContext = splashViewModel;
	}

	protected override void OnAppearing() {
		base.OnAppearing();
		StartAnimation();
	}

	private void StartAnimation() => splashLogo.RotateTo(360, 10000);
}