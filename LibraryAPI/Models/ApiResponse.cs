using System.Net;

namespace LibraryAPI.Models
{
    public class ApiResponse
    {
        public object? Data { get; set; }
        public HttpStatusCode StatusCode { get; set; }
        public bool IsSuccess { get; set; }
        public string? Message { get; set; }
    }
}
