namespace LManagement.API.Models.Responses
{
    public class ApiResponse<T>
    {
        public bool Success { get; set; } = true;
        public string Message { get; set; } = string.Empty;
        public T? Data { get; set; }

        public static ApiResponse<T> SuccessResponse(T? data, string message = "")
        { 
            return new() { Success = true, Data = data, Message = message };
        }

        public static ApiResponse<T> FailResponse(string message = "")
        {
           return new() { Success = false, Message = message};
        }
    }
}
