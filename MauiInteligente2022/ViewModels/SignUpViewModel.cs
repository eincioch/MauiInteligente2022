using MauiInteligente2022.AppBase.Validations;

namespace MauiInteligente2022.ViewModels; 
public class SignUpViewModel : BaseViewModel {
    public SignUpViewModel() {
        PageId = SIGUP_PAGE_ID;
        Title = Resources.SignupTitle;
        SubTitle = Resources.SignupSubtitle;
    }

    private string userName;

    public string UserName {
        get => userName;
        set => SetProperty(ref userName, value);
    }

    private string password;

    public string Password {
        get => password;
        set => SetProperty(ref password, value);
    }

    private string address;

    public string Address {
        get => address;
        set => SetProperty(ref address, value);
    }

    private string email;

    public string Email {
        get => email;
        set => SetProperty(ref email, value);
    }

    private string phoneNumber;

    public string PhoneNumber {
        get => phoneNumber;
        set => SetProperty(ref phoneNumber, value);
    }

    private void CleanData() {
        UserName = string.Empty;
        Password = string.Empty;
        Email = string.Empty;
        Address = string.Empty;
        PhoneNumber = string.Empty;
    }

    private ValidationResult userNameValidationResult;

    public ValidationResult UserNameValidationResult {
        get => userNameValidationResult;
        set => SetProperty(ref userNameValidationResult, value, onChanged: ValidateAll);
    }

    private ValidationResult passwordValidationResult;

    public ValidationResult PasswordValidationResult {
        get => passwordValidationResult;
        set => SetProperty(ref passwordValidationResult, value, onChanged: ValidateAll);
    }

    private ValidationResult addressValidationResult;

    public ValidationResult AddressValidationResult {
        get => addressValidationResult;
        set => SetProperty(ref addressValidationResult, value, onChanged: ValidateAll);
    }

    private ValidationResult phoneNumberValidationResult;

    public ValidationResult PhoneNumberValidationResult {
        get => phoneNumberValidationResult;
        set => SetProperty(ref phoneNumberValidationResult, value, onChanged: ValidateAll);
    }

    private ValidationResult emailValidationResult;

    public ValidationResult EmailValidationResult {
        get => emailValidationResult;
        set => SetProperty(ref emailValidationResult, value, onChanged: ValidateAll);
    }

    private bool isValid;

    public bool IsValid {
        get => isValid;
        set => SetProperty(ref isValid, value);
    }

    private void ValidateAll() =>
        IsValid = UserNameValidationResult == ValidationResult.Valid
        && PasswordValidationResult == ValidationResult.Valid
        && AddressValidationResult == ValidationResult.Valid
        && EmailValidationResult == ValidationResult.Valid
        && PhoneNumberValidationResult == ValidationResult.Valid;
}