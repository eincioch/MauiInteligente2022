using System.Globalization;

namespace MauiInteligente2022.AppBase.Converters;

public class ValidationResultToBoolConverter : IValueConverter {
    public object Convert(object value, Type targetType, object parameter, CultureInfo culture) {
        if (value is Validations.ValidationResult validationResult)
            return validationResult == Validations.ValidationResult.None ? false : true;
        return false;
    }

    public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture) {
        throw new NotImplementedException();
    }
}