namespace API.Errors
{
    public class ApiResponse
    {
        public string? Message { get; set; }

        public ApiResponse(int statusCode, string? message = null)
        {
            Message = message ?? GetDefaultMessageForStatusCode(statusCode);
        }

        private string? GetDefaultMessageForStatusCode(int statusCode)
        {
            return statusCode switch
            {
                400 => "A bad request, you have made!",
                401 => "Authorized, you are not!",
                404 => "Resourse was not found!",
                500 => "Server Error",
                _ => null
            };
        }
    }
}