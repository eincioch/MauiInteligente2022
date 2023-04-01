using Microsoft.Maui.Maps;
using MauiMap = Microsoft.Maui.Controls.Maps;

namespace MauiInteligente2022.AppBase.Controls;
public class RouteMap : MauiMap.Map {
	public static readonly BindableProperty UserLocationProperty
		= BindableProperty.Create(nameof(UserLocation), typeof(Location), typeof(RouteMap),
			null, propertyChanged: OnUserLocationChanged);

	public Location UserLocation {
		get => (Location)GetValue(UserLocationProperty);
		set => SetValue(UserLocationProperty, value);
	}

	public static readonly BindableProperty RouteProperty
		= BindableProperty.Create(nameof(Route), typeof(IEnumerable<Location>), typeof(RouteMap),
			null, propertyChanged: OnRouteChanged);

	public IEnumerable<Location> Route {
		get => (IEnumerable<Location>)GetValue(RouteProperty);
		set => SetValue(RouteProperty, value);
	}

	public static readonly BindableProperty ColorPinsProperty
		= BindableProperty.Create(nameof(ColorPins), typeof(IEnumerable<ColorPin>), typeof(RouteMap),
			null);

	public IEnumerable<ColorPin> ColorPins {
		get => (IEnumerable<ColorPin>)GetValue(ColorPinsProperty);
		set => SetValue(ColorPinsProperty, value);
	}

	private static void OnUserLocationChanged(BindableObject bindable, object oldValue, object newValue) {
		MauiMap.Pin pin = new() {
			Label = Localization.Resources.CurrentLocationLabel,
			Location = (Location)newValue
		};

		if (bindable is MauiMap.Map routeMap) {
			routeMap.Pins.Add(pin);
			routeMap.MoveToRegion(MapSpan.FromCenterAndRadius((Location)newValue,
				Distance.FromKilometers(3)));
		}
	}

	private static void OnRouteChanged(BindableObject bindable, object oldValue, object newValue) {
		if (newValue is IEnumerable<Location> route) {
			MauiMap.Polyline polyline = new() {
				StrokeWidth = 5,
				StrokeColor = Colors.Red
			};

			if (bindable is MauiMap.Map routeMap) {
				routeMap.Pins.Clear();
				routeMap.MapElements.Clear();

				foreach (var location in route) {
					polyline.Geopath.Add(location);
				}

				routeMap.MapElements.Add(polyline);
				routeMap.MoveToRegion(MapSpan.FromCenterAndRadius(route.First(), Distance.FromKilometers(3)));
			}
		}
	}
}

public class ColorPin {
	public Color Color { get; set; }
	public string Label { get; set; }
	public Location Location { get; set; }
}