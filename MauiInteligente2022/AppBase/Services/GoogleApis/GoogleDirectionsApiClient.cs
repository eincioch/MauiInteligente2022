using Microsoft.Extensions.Options;
using System.Net.Http.Json;

namespace MauiInteligente2022.AppBase.Services.GoogleApis; 
public class GoogleDirectionsApiClient {
	private readonly HttpClient httpClient;
	private readonly GoogleDirectionsOptions googleDirectionsOptions;

	public GoogleDirectionsApiClient(HttpClient httpClient,
				IOptions<GoogleDirectionsOptions> options) {
		this.httpClient = httpClient;
		this.googleDirectionsOptions = options.Value;
	}

	public async Task<GoogleDirectionsApiResponse> GetGoogleDirectionsAsync
		(string origin, string destination) {
		string uri = string.Format(googleDirectionsOptions.Url, origin, destination, googleDirectionsOptions.ApiKey);

		using var response = await httpClient.GetAsync(uri);

		if (response.IsSuccessStatusCode) {
			var googleDirectionsResponse = await response.Content.ReadFromJsonAsync<GoogleDirectionsApiResponse>();
			return googleDirectionsResponse;
		}
		return null!;
	}
}