namespace MauiInteligente2022.ViewModels {
    public class AboutViewModel : BaseViewModel {
        public AboutViewModel() {
            PageId = ABOUT_PAGE_ID;
            Title = "ABOUT";
            SubTitle = "Info About";
        }

        public string AppName => AppInfo.Name;
        public string AppVersion => $"AppVersion {AppInfo.VersionString}";
        public string DeviceName => DeviceInfo.Name;
        public string DeviceManufacturer => DeviceInfo.Manufacturer;
        public string DevicePlatform => DeviceInfo.Platform.ToString();
        public string DeviceModel => DeviceInfo.Model;
        public string SystemVersion => DeviceInfo.VersionString;
    }
}
