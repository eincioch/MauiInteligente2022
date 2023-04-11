using BaseRestClientCore.Interfaces;

namespace BaseRestClientCore.Base;
public class GenericRestService<T, U> : BaseRestService, IRestService<T, U>
    where T: class
    where U : class {
    public GenericRestService(HttpClient httpClient)
        : base(httpClient) {
    }

    public GenericRestService(HttpClient httpClient, string token)
        : base(httpClient, token){ 
    }

    public async Task<IRestResponse<U>> DeleteAsync(int id, string uri) 
        => await SendReceiveAsync<T,U>(HttpMethod.Delete, uri:$"{uri}{id}");

    public async Task<IRestResponse<IEnumerable<U>>> GetAllAsync(string uri)
        => await SendReceiveAsync<T, IEnumerable<U>>(HttpMethod.Get, uri: uri);

    public async Task<IRestResponse<U>> GetAsync(int id, string uri)
        => await SendReceiveAsync<T, U>(HttpMethod.Get, uri: $"{uri}{id}");
    public async Task<IRestResponse<U>> PostAsync(T content, string uri)
        => await SendReceiveAsync<T, U>(HttpMethod.Post, content, uri);

    public async Task<IRestResponse<U>> PutAsync(int id, T content, string uri)
        => await SendReceiveAsync<T, U>(HttpMethod.Put, content, $"{uri}{id}");
}