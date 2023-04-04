namespace BaseRestClientCore.Base;

public interface IRestService<T, U>
        where U : class
        where T : class {

    Task<IRestResponse<IEnumerable<U>>> GetAllAsync(string uri);

    Task<IRestResponse<U>> GetAsync(int id, string uri);

    Task<IRestResponse<U>> PostAsync(T content, string uri);

    Task<IRestResponse<U>> PutAsync(int id, T content, string uri);

    Task<IRestResponse<U>> DeleteAsync(int id, string uri);
}