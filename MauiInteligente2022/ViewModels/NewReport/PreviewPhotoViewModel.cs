using MauiInteligente2022.AppBase.Helpers;

namespace MauiInteligente2022.ViewModels; 
public class PreviewPhotoViewModel : BaseViewModel {
    private readonly MediaHelper _mediaHelper;

    public PreviewPhotoViewModel(MediaHelper mediaHelper) {
        _mediaHelper = mediaHelper;
        
    }

    public Command TakePhotoCommand { get; set; }
    public Command AcceptCommand { get; set; }
    private async Task AcceptAsync() => await AppShell.Current.GoToAsync("..");
}