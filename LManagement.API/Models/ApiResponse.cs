namespace LManagement.API.Models
{
    public class ApiResponse<T>
    {
        public bool Success { get; set; } = true;
        public string Message { get; set; } = string.Empty;
        public T? Data { get; set; }
        public List<string>? Errors { get; set; }
    }

    public class ApiPagedResponse<T> : ApiResponse<T>
    {
        public PaginationMeta? Meta { get; set; }
    }
}
