namespace LManagement.API.Models
{
    public class ApiResponse<T>
    {
        public bool Success { get; set; } = true;
        public string Message { get; set; } = string.Empty;
        public T? Data { get; set; }
        public int? Count => Data != null && Data is IEnumerable<object> enumerableData ? enumerableData.Count() : (int?)null;
        public List<string>? Errors { get; set; }
    }
}
