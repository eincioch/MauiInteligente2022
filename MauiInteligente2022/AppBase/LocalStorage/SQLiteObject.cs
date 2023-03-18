
using SQLite;

namespace MauiInteligente2022.AppBase.LocalStorage; 
public class SQLiteObject : IKeyObject {
    [PrimaryKey]
    public string Id { get; set; }
}