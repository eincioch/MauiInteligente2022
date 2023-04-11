using System.Net.Http.Json;
using BaseRestClientCore.Enums;
using BaseRestClientCore.Interfaces;

namespace BaseRestClientCore.Base;

public class BaseRestService {
    private readonly HttpClient _httpClient;

    public BaseRestService(HttpClient httpClient) => _httpClient = httpClient;

    public BaseRestService(HttpClient httpClient, string token)
        : this(httpClient) =>
        _httpClient.DefaultRequestHeaders.Authorization = new("bearer", token);

    protected async Task<HttpResponseMessage> SendHttpRequest<T>
        (HttpMethod httpMethod, T content = null!, string uri = "")
        where T : class {
        HttpRequestMessage httpRequestMessage = new(httpMethod, uri);

        if (content is not null)
            httpRequestMessage.Content = JsonContent.Create(content);

        return await _httpClient.SendAsync(httpRequestMessage);
    }

    public async Task<IRestResponse<U>> SendReceiveAsync<T, U>(HttpMethod httpMethod, T content = null!, string uri = "")
        where T : class
        where U : class {
        GenericRestResponse<U> restResponse = new() {
            Status = RestResponseStatus.Error,
            ResponseMessage = "Unexpected error"
        };

        try {
            HttpResponseMessage httpResponse = await SendHttpRequest<T>(httpMethod, content, uri);
            if (httpResponse.IsSuccessStatusCode) {
                restResponse.ResponseMessage = "Success";
                restResponse.Status = RestResponseStatus.Success;

                if (httpResponse.StatusCode == System.Net.HttpStatusCode.OK)
                    restResponse.ResponseContent = 
                        await httpResponse.Content.ReadFromJsonAsync<U>();
            } else {
                restResponse.ResponseMessage = 
                    $"StatusCode {httpResponse.StatusCode}: {httpResponse.ReasonPhrase}";
                restResponse.Status = RestResponseStatus.Error;
            }
        } catch (TimeoutException) {
            restResponse.ResponseMessage = "Timeout has ocurred";
            restResponse.Status = RestResponseStatus.Timeout;
        } catch (Exception ex) {
            restResponse.ResponseMessage = ex.Message;
            restResponse.Status = RestResponseStatus.Exception;
        }

        return restResponse;
    }
}