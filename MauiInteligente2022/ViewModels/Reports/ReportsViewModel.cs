using MauiInteligente2022.AppBase.LocalStorage;
using MauiInteligente2022.Models;

namespace MauiInteligente2022.ViewModels; 
public class ReportsViewModel : BaseViewModel {
	private readonly SQLiteAsyncClient _dbConnection;
	public ReportsViewModel(SQLiteAsyncClient dbConnection) {
		Title = Resources.ReportsTitle;
		PageId = REPORTS_ID;
		_dbConnection = dbConnection;
		LoadAsync();
	}

	private async Task LoadAsync()
		=> Transactions = await _dbConnection.GetAllValuesAsync<CompletedTransaction>();

	private List<CompletedTransaction> transactions;

	public List<CompletedTransaction> Transactions {
		get => transactions;
		set => SetProperty(ref transactions, value);
	}
}