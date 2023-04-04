using BaseRestClientCore.Base;

namespace MauiInteligente2022.RestServices;
public class BranchRestService : GenericRestClient<Branch, Branch> {
    public BranchRestService(HttpClient httpClient)
        : base(httpClient, AppConfiguration.UserToken) {
    }
}