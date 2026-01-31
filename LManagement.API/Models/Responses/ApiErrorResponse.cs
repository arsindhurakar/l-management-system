namespace LManagement.API.Models.Responses
{
    public class ApiErrorResponse<T> : ApiResponse<T>
    {
        public List<string>? Errors { get; set; } = new List<string>();

        public static ApiErrorResponse<T> FailResponse(string  message, IEnumerable<string>? errors = null)
        {
            return new()
            {
                Success = false,
                Message = message,
                Errors = errors?.ToList() ?? new List<string>()
            };
        }
    }
}
