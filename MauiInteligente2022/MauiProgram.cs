using MauiInteligente2022.AppBase.LocalStorage;
using MauiInteligente2022.AppBase.Services.GoogleApis;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
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
                        .AddTransient<AboutPage>()
                        .AddTransient<AboutViewModel>()
                        .AddTransient<BranchDetailPage>()						
						.AddTransient<BranchDetailViewModel>()
						.AddTransient<GoogleDirectionsApiClient>()
						.AddTransient<LocationsViewModel>()
						.AddTransient<LocationsPage>()
						.AddTransient<ReportsViewModel>()
						.AddTransient<ReportsPage>()
                        .AddTransient<SyncViewModel>()
                        .AddTransient<SyncPage>();

		string dbPath = Path.Combine(FileSystem.AppDataDirectory, "mauiinteligente.db3");

		builder.Services.AddSingleton(s => ActivatorUtilities.CreateInstance<SQLiteAsyncClient>(s, dbPath));

		builder.Services.AddHttpClient<SignUpViewModel>(client => {
				client.Timeout = TimeSpan.FromSeconds(40);
				client.BaseAddress = new($"{builder.Configuration["Api:Uri"]}{builder.Configuration["Api:Signup"]}");
		});
        builder.Services.AddHttpClient<LoginViewModel>(client => {
            client.Timeout = TimeSpan.FromSeconds(40);
            client.BaseAddress = new($"{builder.Configuration["Api:Uri"]}{builder.Configuration["Api:Login"]}");
        });

		builder.Services.Configure<GoogleDirectionsOptions>
			(builder.Configuration.GetSection(GoogleDirectionsOptions.GoogleDirections));

#if DEBUG
		builder.Logging.AddDebug();
#endif

		return builder.Build();
	}
}