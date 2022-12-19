namespace MauiInteligente2022.Views;

public partial class TermsAndConditionsPage : BindedPage {
	IServiceProvider sp;
	public TermsAndConditionsPage(TermsAndConditionsViewModel viewModel) {
		InitializeComponent();
		BindingContext = viewModel;
	}

    protected override async void OnAppearing() {
        base.OnAppearing();

		var termsPage = AppConfiguration.AppLanguage switch {
			Languages.Spanish => "TermsAndConditionsES.html",
			_ => "TermsAndConditionsEN.html"
		};

		using var stream = await FileSystem.OpenAppPackageFileAsync(termsPage);
		using var reader = new StreamReader(stream);
		var contents = reader.ReadToEnd();

		var htmlSource = new HtmlWebViewSource {
			Html = contents
		};

		browser.Source = htmlSource;
    }
}