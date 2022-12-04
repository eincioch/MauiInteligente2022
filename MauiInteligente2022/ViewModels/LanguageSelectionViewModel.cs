namespace MauiInteligente2022.ViewModels {
    public class LanguageSelectionViewModel : BaseViewModel {
        private readonly IServiceProvider sp;

        public LanguageSelectionViewModel(IServiceProvider sp) {
            this.sp = sp;
            PageId = LANGUAGE_PAGE_ID;
        }

        public Command EnglishSelectionCommand { get; set; }
        public Command SpanishSelectionCommand { get; set; }
        public Command NextCommand { get; set; }

        private bool canGoNext;

        public bool CanGoNext {
            get => canGoNext;
            set => SetProperty(ref canGoNext, value);
        }

        private void ChangeLanguage(Languages language) {

        }
    }
}
