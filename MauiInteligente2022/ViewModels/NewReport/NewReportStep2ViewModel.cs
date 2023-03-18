namespace MauiInteligente2022.ViewModels; 
public class NewReportStep2ViewModel : BaseViewModel {
    public string ClientNumber { get; internal set; }
    public string ClientName { get; internal set; }
    public string ClientPhoneNumber { get; internal set; }
    public object SelectedCountry { get; internal set; }
    public string ClientEmail { get; internal set; }
    public string ClientCity { get; internal set; }
    public string ClientDocumentNumber { get; internal set; }
    public string SelectedDocument { get; internal set; }

    private void LoadCatalogs() {
    }
}