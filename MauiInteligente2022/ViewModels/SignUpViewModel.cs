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

}