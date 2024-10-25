using System.Net;

namespace PruebaTecnica.Response;

public class ApiResponse<T>
{
    public T Data { get; set; }
    public bool Success { get; set; }
    public string Message { get; set; }
    public HttpStatusCode StatusCode { get; set; }

    public ApiResponse()
    {
        Success = true;
        StatusCode = HttpStatusCode.OK;
        Message = "";
    }

    public void SetError(string errorMessage, HttpStatusCode statusCode)
    {
        Success = false;
        Message = errorMessage;
        StatusCode = statusCode;
    }
}