using System.Text.RegularExpressions;
using static MauiInteligente2022.AppBase.Constants.Validations;

namespace MauiInteligente2022.AppBase.Validations;

public static partial class ValidationRegex {
    [GeneratedRegex(EMAIL)]
    public static partial Regex EmailRegex();

    [GeneratedRegex(PHONE)]
    public static partial Regex PhoneRegex();

    [GeneratedRegex(PASSWORD)]
    public static partial Regex PasswordRegex();

    [GeneratedRegex(EMPTY)]
    public static partial Regex EmptyRegex();
}