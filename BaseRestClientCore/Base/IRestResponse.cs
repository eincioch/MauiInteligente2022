namespace BaseRestClientCore.Base;

public interface IRestResponse<U> where U : class {
    RestResponseStatus Status { get; set; }

    string? ResponseMessage { get; set; }

    U? ResponseContent { get; set; }
}