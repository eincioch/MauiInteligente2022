﻿using System.IO.MemoryMappedFiles;
using System.Runtime.InteropServices;

namespace MauiInteligente2022.AppBase.Controls; 
public partial class RouteMap {
    public RouteMap() {
    }

    private IMKAnnotation CreateAnnotation(ColorPin colorPin) {
        var annotation = new ColorPointAnnotation(colorPin.Color.ToPlatform()) {
            Title = colorPin.Label,
            Coordinate = new CoreLocation.CLLocationCoordinate2D(
                colorPin.Location.Latitude, colorPin.Location.Longitude)
        };
        return annotation;
    }

    protected override void OnHandlerChanged() {
        base.OnHandlerChanged();
        if (Handler.PlatformView is MapKit.MkMapView mapView)
            mapView.GetViewForAnnotation = GetViewForAnnotation;
    }

    MKAnnotationView GetViewForAnnotation(MKMapView mapView, IMKAnnotation annotation) {
        var colorAnnotation = annotation as ColorPointAnnotation;
        MKMarkerAnnotationView view = null;

        if (colorAnnotation is not null) {
            var identifier = "colorAnnotation";
            view = mapView.DequeueReusableAnnotation(identifier) as MKMarkerAnnotationView;

            if (view is null)
                view = new(colorAnnotation, identifier);

            view.CanShowCallout = true;
            view.MarkerTintColor = colorAnnotation.Color;
        }
        return view;
    }

    void AddColorPins() {
        if (Handler.PlatformView is MapKit.MKMapView mapView) {
            foreach (var colorPin in ColorPins) {
                var annotation = CreateAnnotation(colorPin);
                mapView.AddAnnotation(annotation);
            }
        }
    }
}

public class ColorPointAnnotation : MKPointAnnotation {
    public UIColor Color { get; private set; }
    public ColorPointAnnotation(UIColor color) => Color = color;
}