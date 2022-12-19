namespace MauiInteligente2022;

public static class MauiProgram {
	public static MauiApp CreateMauiApp() {
		var builder = MauiApp.CreateBuilder();
		builder
			.UseMauiApp<App>()
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
						.AddTransient<SignUpPage>();

		return builder.Build();
	}
}