namespace HotelSystem.Application.Response
{
    public class AppError
    {
        public string Message { get; set; }
        public int StatusCode { get; set; }
        public AppError(string message, int statusCode)
        {
            Message = message;
            StatusCode = statusCode;
        }
    }
}
