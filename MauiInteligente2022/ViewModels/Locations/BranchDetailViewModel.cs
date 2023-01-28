using Microsoft.Maui.Devices.Sensors;

namespace MauiInteligente2022.ViewModels {
    public class BranchDetailViewModel : BaseViewModel {
        public BranchDetailViewModel() {
            Title = Resources.BranchDetailTitle;
            PageId = BRANCH_DETAIL_ID;

        }

        public Command ShowRoute { get; set; }

        private Location currentLocation;
        public Location CurrentLocation {
            get => currentLocation;
            set => SetProperty(ref currentLocation, value);
        }

        public override async Task OnAppearing() => await GetCurrentLocationAsync();

        private async Task GetCurrentLocationAsync() {
            try {
                var geolocationRequest = new GeolocationRequest(GeolocationAccuracy.Medium, TimeSpan.FromSeconds(30));
                var location = await Geolocation.GetLocationAsync(geolocationRequest);
                if (location is not null)
                    currentLocation = location;
            } catch (FeatureNotSupportedException fnsEx) {
                await Application.Current.MainPage.DisplayAlert(Resources.GetLocationErrorTitle, Resources.GetLocationNotSupportedError, Resources.AcceptButton);
            } catch (FeatureNotEnabledException fneEx) {
                await Application.Current.MainPage.DisplayAlert(Resources.GetLocationErrorTitle, Resources.GetLocationNotEnabledError, Resources.AcceptButton);
            } catch (PermissionException pEx) {
                await Application.Current.MainPage.DisplayAlert(Resources.GetLocationErrorTitle, Resources.GetLocationPermissionError, Resources.AcceptButton);
            } catch (Exception ex) {
                await Application.Current.MainPage.DisplayAlert(Resources.GetLocationErrorTitle, Resources.ErrorMessage, Resources.AcceptButton);
            }
        }

        private async Task ShowRouteAsync() {
            try {
                var placemarks = await Geocoding.GetPlacemarksAsync(currentLocation);
                string origin;

                if(placemarks is not null) {

                }
            } catch {

            }
        }
    }    
}