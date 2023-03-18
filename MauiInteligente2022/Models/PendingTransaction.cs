using MauiInteligente2022.AppBase.LocalStorage;

namespace MauiInteligente2022.Models; 
public class PendingTransaction : SQLiteObject {
    public string ReportId => Id;
    public DateTime ReportDate { get; set; }
    public string Photo1 { get; set; }
    public string Photo2 { get; set; }
    public string Photo3 { get; set; }
    public string Photo4 { get; set; }
    public string Photo1Azure { get; set; }
    public string Photo2Azure { get; set; }
    public string Photo3Azure { get; set; }
    public string Photo4Azure { get; set; }
    public string ClientNumber { get; set; }
    public string ClientName { get; set; }
    public string ClientPhoneNumber { get; set; }
    public string ClientEmail { get; set; }
    public string ClientCountry { get; set; }
    public string ClientCity { get; set; }
    public string ClientDocument { get; set; }
    public string ClientDocumentNumber { get; set; }
    public string ReportDescription { get; set; }
    public decimal Amount { get; set; }
}