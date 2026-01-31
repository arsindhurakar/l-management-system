namespace LManagement.API.Models.Responses
{
    public class PaginatedApiResponse<T> : ApiResponse<T>
    {
        public PaginationMeta? Meta { get; set; } = null;

        public static PaginatedApiResponse<T> SuccessResponse(T data, PaginationMeta meta, string message )
        {
            return new() { Success = true, Data = data, Meta = meta, Message = message };
        }
      
    }
}
