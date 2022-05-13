using System.Net;
using System.Text.Json;

namespace TEST_API1.Middleware.Models.Response
{
    public class ResponseModel<T>
    {
        public int StatusCode { get; set; }
        public string? ErrorMessage { get; set; }
        public string? ErrorType { get; set; }
        public T? Result { get; set; }
        public override string ToString()
        {
            return JsonSerializer.Serialize(this);
        }
    }
}
