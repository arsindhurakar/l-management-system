namespace LManagement.Application.Dtos
{
    public class PageRequestDto
    {
        public int Page { set; get; } = 1;
        public int PageSize { set; get; } = 10;
        public string SortBy { set; get; } = "CreatedAt";
        public string SortOrder { set; get; } = "desc";
    }
}
