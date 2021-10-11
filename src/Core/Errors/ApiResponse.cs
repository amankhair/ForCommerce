namespace Core.Errors
{
    public class ApiResponse
    {
        public int StatusCode { get; set; }
        public string Message { get; set; }

        public ApiResponse(int statusCode, string message = null)
        {
            StatusCode = statusCode;
            Message = message ?? GetDefaultMessageForStatusCode(statusCode);
        }

        private string GetDefaultMessageForStatusCode(int statusCode)
        {
            return statusCode switch
            {
                400 => "Invalid syntax for this request was provided.",
                401 => "You are unauthorized to access the requested resource.",
                404 => "The resource you requested could not be found.",
                500 => "Unexpected internal server error.",
                _ => null
            };
        }
    }
}