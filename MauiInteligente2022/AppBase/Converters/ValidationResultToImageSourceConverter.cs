using MauiInteligente2022.AppBase.Validations;
using System.Globalization;

namespace MauiInteligente2022.AppBase.Converters;
public class ValidationResultToImageSourceConverter : IValueConverter {
    public object Convert(object value, Type targetType, object parameter, CultureInfo culture) {
        if(value is ValidationResult validationResult) {
            return validationResult switch {
                ValidationResult.None => null,
                ValidationResult.Valid => ImageSource.FromFile("correct"),
                ValidationResult.Invalid => ImageSource.FromFile("incorrect"),
                _ => null
            };
        }
        return null;
    }

    public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture) {
        throw new NotImplementedException();
    }
}