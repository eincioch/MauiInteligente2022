using BaseRestClientCore.Base;

namespace MauiInteligente2022.RestServices;
public class BranchRestService : GenericRestService<Branch, Branch> {
    public BranchRestService(HttpClient httpClient)
        : base(httpClient, AppConfiguration.UserToken) {
    }
}