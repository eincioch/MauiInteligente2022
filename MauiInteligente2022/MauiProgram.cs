using Microsoft.Extensions.Configuration;
using System.Reflection;

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

		using var jsonConfig = Assembly.GetExecutingAssembly()
					.GetManifestResourceStream("MauiInteligente2022.appsettings.json");
		var config = new ConfigurationBuilder().AddJsonStream(jsonConfig).Build();
		builder.Configuration.AddConfiguration(config);

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
						.AddTransient<BranchDetailViewModel>()
						.AddTransient<LocationsViewModel>()
						.AddTransient<LocationsPage>();

		builder.Services.AddHttpClient<SignUpViewModel>(client => {
				client.Timeout = TimeSpan.FromSeconds(40);
				client.BaseAddress = new($"{builder.Configuration["Api:Uri"]}{builder.Configuration["Api:Signup"]}");
		});
        builder.Services.AddHttpClient<LoginViewModel>(client => {
            client.Timeout = TimeSpan.FromSeconds(40);
            client.BaseAddress = new($"{builder.Configuration["Api:Uri"]}{builder.Configuration["Api:Login"]}");
        });

        return builder.Build();
	}
}