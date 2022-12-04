namespace MauiInteligente2022.ViewModels {
    public class TermsAndConditionsViewModel : BaseViewModel {
        private readonly IServiceProvider sp;
        public TermsAndConditionsViewModel(IServiceProvider sp) {
            PageId = TERMS_PAGE_ID;
            Title = Resources.TermsPageTitle;
            SubTitle = Resources.TermsPageSubtitle;
            this.sp = sp;
        }

        public Command AcceptTermsCommand { get; set; }

        //private void AcceptTerms {
        //    //AppConfiguration.UserAcceptTerms = true;
        //    //Application.Current.MainPage = new NavigationPage(sp.GetRequiredService<LoginPage>());
        //}
    }
}
