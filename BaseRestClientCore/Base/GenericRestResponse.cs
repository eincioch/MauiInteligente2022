namespace BaseRestClientCore.Base;

public class GenericRestResponse<U> : IRestResponse<U>
    where U : class {
    public RestResponseStatus Status { get; set; }
    public string? ResponseMessage { get; set; } = null!;
    public U? ResponseContent { get; set; } = null!;
}