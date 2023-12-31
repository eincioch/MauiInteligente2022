﻿namespace MauiInteligente2022.Models;

public record LoginCredentials (string UserName, string Password);

public record Branch(int BranchId, string Name, string Location) {
    public Branch() : this(0, null!, null!) { 
    }
}

public record Country(int CountryId, string CountryCode) {
    public Country() : this(0, null!) {
    }
}