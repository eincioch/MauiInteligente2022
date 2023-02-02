namespace MauiInteligente2022.AppBase.Validations;

public enum ValidationType {
    None,
    Email,
    Password,
    Phone,
    Empty
}

public enum ValidationResult {
    None,
    Valid,
    Invalid
}