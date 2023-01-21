namespace MauiInteligente2022.ViewModels {
    public class AboutViewModel : BaseViewModel {
        public AboutViewModel() {
            PageId = ABOUT_PAGE_ID;
            Title = Resources.AboutTitle;
            SubTitle = AppInfo.Name;
        }
    }
}
