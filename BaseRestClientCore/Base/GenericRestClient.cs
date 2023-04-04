namespace BaseRestClientCore.Base;

public class GenericRestClient<T, U> : BaseRestService, IRestService<T, U>
    where T : class
    where U : class {
    public GenericRestClient(HttpClient httpClient)
        : base(httpClient) {
    }

    public GenericRestClient(HttpClient httpClient, string token)
        : base(httpClient, token) {
    }

    public async Task<IRestResponse<U>> GetAsync(int id, string uri = "")
       => await SendReceiveRequestAsync<U, U>(HttpMethod.Get, $"{uri}{id}");

    public async Task<IRestResponse<IEnumerable<U>>> GetAllAsync(string uri = "")
    => await SendReceiveRequestAsync<U, IEnumerable<U>>(HttpMethod.Get, $"{uri}");

    public async Task<IRestResponse<U>> PostAsync(T content, string uri = "")
     => await SendReceiveRequestAsync<T, U>(HttpMethod.Post, $"{uri}", content);

    public async Task<IRestResponse<U>> DeleteAsync(int id, string uri = "")
       => await SendReceiveRequestAsync<U, U>(HttpMethod.Delete, $"{uri}{id}");

    public async Task<IRestResponse<U>> PutAsync(int id, T content, string uri = "")
     => await SendReceiveRequestAsync<T, U>(HttpMethod.Put, $"{uri}{id}", content);
}