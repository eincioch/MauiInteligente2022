using MauiInteligente2022.AppBase.Services.GoogleApis;
using System.Diagnostics;

namespace MauiInteligente2022.ViewModels {
    public class BranchDetailViewModel : BaseViewModel {
        private GoogleDirectionsApiClient _directionsApiClient;
        public BranchDetailViewModel(GoogleDirectionsApiClient googleDirectionsApiClient) {
            Title = Resources.BranchDetailTitle;
            PageId = BRANCH_DETAIL_ID;
            _directionsApiClient = googleDirectionsApiClient;
            Location = "Calz. Vallejo 1090, Sta Cruz de las Salinas, Azcapotzalco, 02300 Ciudad de México, CDMX";
            ShowRouteCommand = new(async () => await ShowRouteAsync());
        }

        private string name;
        public string Name {
            get => name;
            set => SetProperty(ref name, value);
        }

        private string location;
        public string Location {
            get => location;
            set => SetProperty(ref location, value);
        }

        private Location currentLocation;
        public Location CurrentLocation {
            get => currentLocation;
            set => SetProperty(ref currentLocation, value);
        }

        private IEnumerable<Location> route;
        public IEnumerable<Location> Route {
            get => route;
            set => SetProperty(ref route, value);
        }

        public override async Task OnAppearing() => await GetCurrentLocationAsync();

        private async Task GetCurrentLocationAsync() {
            try {
                var geolocationRequest = new GeolocationRequest(GeolocationAccuracy.Medium, TimeSpan.FromSeconds(30));
                var location = await Geolocation.GetLocationAsync(geolocationRequest);
                if (location is not null)
                    currentLocation = location;
            } catch (FeatureNotSupportedException fnsEx) {
                await Application.Current.MainPage.DisplayAlert(
                    Resources.GetLocationErrorTitle, Resources.GetLocationNotSupportedError, Resources.AcceptButton);
            } catch (FeatureNotEnabledException fneEx) {
                await Application.Current.MainPage.DisplayAlert(
                    Resources.GetLocationErrorTitle, Resources.GetLocationNotEnabledError, Resources.AcceptButton);
            } catch (PermissionException pEx) {
                await Application.Current.MainPage.DisplayAlert(
                    Resources.GetLocationErrorTitle, Resources.GetLocationPermissionError, Resources.AcceptButton);
            } catch (Exception ex) {
                await Application.Current.MainPage.DisplayAlert(
                    Resources.GetLocationErrorTitle, Resources.ErrorMessage, Resources.AcceptButton);
            }
        }

        public Command ShowRouteCommand { get; set; }
        private async Task ShowRouteAsync() {
            if (!IsBusy) {
                try {
                    var placemarks = await Geocoding.GetPlacemarksAsync(currentLocation);
                    string origin;

                    if (placemarks is not null) {
                        var placemark = placemarks.ToList()[2];
                        origin = $"{placemark.FeatureName} {placemark.SubLocality} {placemark.Locality}, " +
                                $"{placemark.CountryName}, {placemark.PostalCode}";
                    } else {
                        origin = $"{currentLocation.Latitude}, {currentLocation.Longitude}";
                    }
                    var directions = await _directionsApiClient.GetGoogleDirectionsAsync(origin, Location);

                    var steps = directions?.routes.FirstOrDefault()?.legs?.FirstOrDefault()?.steps;

                    List<Location> route = new();
                    foreach (var step in steps) {
                        var decodedPoint = GooglePoints.Decode(step?.polyline?.points);

                        foreach (var point in decodedPoint)
                            route.Add(new(point.Latitude, point.Longitude));
                    }

                    Route = route;
                } catch (Exception ex) {
                    await Application.Current.MainPage.DisplayAlert(
                        Resources.GetLocationErrorTitle, ex.Message, Resources.AcceptButton);
                }
                IsBusy = false;
            }
        }
    }
}