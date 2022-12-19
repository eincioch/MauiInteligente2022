using System.Globalization;

namespace MauiInteligente2022.ViewModels {
    public class LanguageSelectionViewModel : BaseViewModel {
        private readonly IServiceProvider sp;

        public LanguageSelectionViewModel(IServiceProvider sp) {
            this.sp = sp;
            PageId = LANGUAGE_PAGE_ID;
            EnglishSelectionCommand = new(() => ChangeLanguage(Languages.English));
            SpanishSelectionCommand = new(() => ChangeLanguage(Languages.Spanish));
            NextCommand = new(async () => await GoNextAsync());
        }

        public Command EnglishSelectionCommand { get; set; }
        public Command SpanishSelectionCommand { get; set; }
        public Command NextCommand { get; set; }

        private bool canGoNext;

        public bool CanGoNext {
            get => canGoNext;
            set => SetProperty(ref canGoNext, value);
        }

        private string nextButtonText;

        public string NextButtonText {
            get => nextButtonText;
            set => SetProperty(ref nextButtonText, value);
        }

        private void ChangeLanguage(Languages language) {
            AppConfiguration.AppLanguage = language;

            CultureInfo cultureInfo = language switch {
                Languages.Spanish => new("es"),
                _ => new("en")
            };

            Resources.Culture = cultureInfo;
            Thread.CurrentThread.CurrentCulture = cultureInfo;
            Thread.CurrentThread.CurrentUICulture = cultureInfo;

            AppConfiguration.HasLanguageSelection = true;

            CanGoNext = true;
            Title = Resources.LanguagePageTitle;
            SubTitle = Resources.LanguagePageSubtitle;
            NextButtonText = Resources.NextButton;
        }

        private async Task GoNextAsync() {
            var nextPage = sp.GetRequiredService<TermsAndConditionsPage>();
            await Application.Current.MainPage.Navigation.PushAsync(nextPage);
        }
    }
}