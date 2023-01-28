namespace MauiInteligente2022.ViewModels {
    public class MainMenuViewModel : BaseViewModel {
        public MainMenuViewModel() {
            Title = Resources.MainMenuTitle;
            SubTitle = Resources.MainMenuSubtitle;
            PageId = MAIN_MENU_PAGE_ID;


        }

        public Command AboutCommand { get; set; }

        public Command LocationsCommand { get; set; }
    }
}