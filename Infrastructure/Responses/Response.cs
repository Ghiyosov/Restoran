using System.Net;

namespace Infrastructure.Responses;

public class Response<T>
{
    public int StatusCode { get; set; }
    public T? Data { get; set; }
    public string Message { get; set; }

    public Response(HttpStatusCode statusCode, string message)
    {
        StatusCode = (int)statusCode;
        Message = message;
        Data = default;
    }

    public Response(T? data)
    {
        Data = data;
        StatusCode = 200;
    }
}