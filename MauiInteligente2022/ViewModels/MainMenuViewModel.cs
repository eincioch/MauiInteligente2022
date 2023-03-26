namespace MauiInteligente2022.ViewModels {
    public class MainMenuViewModel : BaseViewModel {
        public MainMenuViewModel() {
            Title = Resources.MainMenuTitle;
            SubTitle = Resources.MainMenuSubtitle;
            PageId = MAIN_MENU_PAGE_ID;

            AboutCommand = new(async() => await NavigateToAsync(ABOUT_PAGE_ID));
            LocationsCommand = new(async () => await NavigateToAsync(BRANCH_DETAIL_ID));

            ReportsCommand = new(async () => await NavigateToAsync(REPORTS_ID));
            SyncCommand = new(async () => await NavigateToAsync(SYNC_ID));
        }

        public Command AboutCommand { get; set; }

        private async Task NavigateToAsync(string route)
            => await Shell.Current.GoToAsync(route);

        public Command LocationsCommand { get; set; }

        public Command ReportsCommand { get; set; }
        public Command SyncCommand { get; set; }
    }
}