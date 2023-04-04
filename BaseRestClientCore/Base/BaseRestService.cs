using System.Net.Http.Json;

namespace BaseRestClientCore.Base;

public class BaseRestService {
    private readonly HttpClient _httpClient;

    public BaseRestService(HttpClient httpClient) {
        _httpClient = httpClient;
    }

    public BaseRestService(HttpClient httpClient, string token)
        : this(httpClient) {
        _httpClient.DefaultRequestHeaders.Authorization = new("bearer", token);
    }

    protected async Task<HttpResponseMessage> SendHttpRequestAsync<V>
        (HttpMethod httpMethod, string uri = "", V content = null!)
        where V : class {
        HttpRequestMessage httpRequestMessage = new(httpMethod, uri);

        if (content is not null)
            httpRequestMessage.Content = JsonContent.Create(content);

        return await _httpClient.SendAsync(httpRequestMessage);
    }

    public async Task<IRestResponse<W>> SendReceiveRequestAsync<V, W>(HttpMethod httpMethod, string uri = "", V content = null!)
        where V : class
        where W : class {
        GenericRestResponse<W> result = new() {
            Status = RestResponseStatus.Error,
            ResponseMessage = "Unexpected error"
        };

        try {
            HttpResponseMessage httpResponseMessage = await SendHttpRequestAsync(httpMethod, uri, content);
            if (httpResponseMessage.IsSuccessStatusCode) {
                result.ResponseMessage = "Ok";
                result.Status = RestResponseStatus.Success;

                if (httpResponseMessage.StatusCode == System.Net.HttpStatusCode.OK)
                    result.ResponseContent = await httpResponseMessage.Content.ReadFromJsonAsync<W>();
            } else {
                result.ResponseMessage = $"StatusCode {httpResponseMessage.StatusCode} Reason: {httpResponseMessage.ReasonPhrase}";
                result.Status = RestResponseStatus.Error;
            }
        } catch (TimeoutException) {
            result.ResponseMessage = "Timeout";
            result.Status = RestResponseStatus.Timeout;
        } catch (Exception ex) {
            result.ResponseMessage = ex.Message;
            result.Status = RestResponseStatus.Exception;
        }

        return result;
    }
}