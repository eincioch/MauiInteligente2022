namespace MauiInteligente2022.Models; 
public class CompletedTransaction : PendingTransaction {
    public CompletedTransaction(PendingTransaction pendingTransaction) {
        Id = pendingTransaction.Id;
        Photo1 = pendingTransaction.Photo1Azure;
        Photo2 = pendingTransaction.Photo2Azure;
        Photo3 = pendingTransaction.Photo3Azure;
        Photo4 = pendingTransaction.Photo4Azure;
        ClientNumber = pendingTransaction.ClientNumber;
        ClientName = pendingTransaction.ClientName;
        ClientEmail = pendingTransaction.ClientEmail;
        ClientPhoneNumber = pendingTransaction.ClientPhoneNumber;
        ClientCountry = pendingTransaction.ClientCountry;
        ClientCity = pendingTransaction.ClientCity;
        ClientDocument = pendingTransaction.ClientDocument;
        ClientDocumentNumber = pendingTransaction.ClientDocumentNumber;
        ReportDescription = pendingTransaction.ReportDescription;
        Amount = pendingTransaction.Amount;
        ReportDate = pendingTransaction.ReportDate;
    }
    public CompletedTransaction() { }
}