using Microsoft.Extensions.Options;

namespace MauiInteligente2022.AppBase.Services.GoogleApis; 
public class GoogleDirectionsApiClient {
	private readonly HttpClient httpClient;
	private readonly GoogleDirectionsOptions googleDirectionsOptions;

	public GoogleDirectionsApiClient(HttpClient httpClient,
				IOptions<GoogleDirectionsOptions> options) {
		this.httpClient = httpClient;
		this.googleDirectionsOptions = options.Value;
	}
}