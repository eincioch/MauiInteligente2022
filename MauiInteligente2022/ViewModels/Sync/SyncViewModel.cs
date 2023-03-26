using MauiInteligente2022.AppBase.LocalStorage;

namespace MauiInteligente2022.ViewModels; 
public class SyncViewModel : BaseViewModel {
    private readonly SQLiteAsyncClient _dbConnection;
    public SyncViewModel(SQLiteAsyncClient dbConnection) {
        Title = Resources.SyncTitle;
        PageId = SYNC_ID;
        _dbConnection = dbConnection;
        LoadAsync();
    }

    private async Task LoadAsync()
        => Transactions = await _dbConnection.GetAllValuesAsync<PendingTransaction>();

    private List<PendingTransaction> transactions;

    public List<PendingTransaction> Transactions {
        get => transactions;
        set => SetProperty(ref transactions, value);
    }
}