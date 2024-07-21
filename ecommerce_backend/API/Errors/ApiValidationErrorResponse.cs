namespace API.Errors
{
    public class ApiValidationErrorResponse
    {
        public ApiValidationErrorResponse()
        {

        }

        public IEnumerable<string> Errors { get; set; } = new List<string>();
    }
}