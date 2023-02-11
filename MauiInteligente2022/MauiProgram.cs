namespace MauiInteligente2022;

public static class MauiProgram {
	public static MauiApp CreateMauiApp() {
		var builder = MauiApp.CreateBuilder();
		builder
			.UseMauiApp<App>()
			.UseMauiMaps()
			.ConfigureFonts(fonts => {
				fonts.AddFont("OpenSans-Regular.ttf", "OpenSansRegular");
				fonts.AddFont("OpenSans-Semibold.ttf", "OpenSansSemibold");
			});

		builder.Services.AddTransient<LoginPage>()
						.AddTransient<LoginViewModel>()
						.AddTransient<SplashPage>()
						.AddTransient<SplashViewModel>()
						.AddTransient<LanguageSelectionPage>()
						.AddTransient<LanguageSelectionViewModel>()
						.AddTransient<TermsAndConditionsPage>()
						.AddTransient<TermsAndConditionsViewModel>()
						.AddTransient<SignUpPage>()
						.AddTransient<SignUpViewModel>()
						.AddTransient<MainMenuPage>()
						.AddTransient<MainMenuViewModel>()
						.AddTransient<BranchDetailPage>()
						.AddTransient<AboutPage>()
						.AddTransient<AboutViewModel>()
						.AddTransient<BranchDetailViewModel>();

		builder.Services.AddHttpClient<SignUpViewModel>(client => {
				client.Timeout = TimeSpan.FromSeconds(40);
				client.BaseAddress = new("https://apinetmauinteligente22.azurewebsites.net");
			});
		;

		return builder.Build();
	}
}