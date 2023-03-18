using MauiInteligente2022.AppBase.LocalStorage;

namespace MauiInteligente2022.Managers; 
public class ReportManager {
    private readonly SQLiteAsyncClient _dbConnection;
    public ReportManager(SQLiteAsyncClient dbConnection) { 
        _dbConnection = dbConnection;
    }

    public async Task<PendingTransaction> SaveTrxLocalAsync
        (NewReportStep1ViewModel step1ViewModel, NewReportStep2ViewModel step2ViewModel, NewReportStep3ViewModel step3ViewModel) {

        PendingTransaction pendingTransaction = new() {
            Id = step1ViewModel.ReportId,
            ReportDate = DateTime.Now,
            Photo1 = step1ViewModel.PhotoPath1,
            Photo2 = step1ViewModel.PhotoPath2,
            Photo3 = step1ViewModel.PhotoPath3,
            Photo4 = step1ViewModel.PhotoPath4,
            ClientNumber = step2ViewModel.ClientNumber,
            ClientName = step2ViewModel.ClientName,
            ClientEmail = step2ViewModel.ClientEmail,
            ClientPhoneNumber = step2ViewModel.ClientPhoneNumber,
            //ClientCountry = step2ViewModel.SelectedCountry.CountryCode,
            ClientCity = step2ViewModel.ClientCity,
            ClientDocument = step2ViewModel.SelectedDocument,
            ClientDocumentNumber = step2ViewModel.ClientDocumentNumber,
            ReportDescription = step3ViewModel.ReportDescription,
            Amount = step3ViewModel.Amount
        };

        await _dbConnection.SaveValueAsync(pendingTransaction);

        return pendingTransaction;
    }
}