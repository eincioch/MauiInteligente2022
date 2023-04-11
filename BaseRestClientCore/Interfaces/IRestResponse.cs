using BaseRestClientCore.Enums;

namespace BaseRestClientCore.Interfaces;

public interface IRestResponse<U> where U : class {
    RestResponseStatus Status { get; }

    string? ResponseMessage { get; }

    U? ResponseContent { get; }
}