using System.Globalization;

namespace MauiInteligente2022.AppBase.Converters;

public class EmptyToBoolConverter : IValueConverter {
    public object Convert(object value, Type targetType, object parameter, CultureInfo culture) {
        return !string.IsNullOrWhiteSpace(value?.ToString());
    }

    public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture) {
        throw new NotImplementedException();
    }
}