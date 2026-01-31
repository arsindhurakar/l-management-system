
using LManagement.Application.Enums;

namespace LManagement.Application.Models.Pagination
{
    public class PageRequest
    {
        private int _page = 1;
        private int _pageSize = 10;
        private string _sortBy = "CreatedAt";
        private SortDirection _sortOrder = SortDirection.Descending;
        private readonly HashSet<string> _validateSortFields;

        public PageRequest(IEnumerable<string> validateSortFields)
        {
            _validateSortFields = new HashSet<string>(validateSortFields, StringComparer.OrdinalIgnoreCase);
        }

        public int Page
        {
            get => _page;
            set => _page = value < 1 ? 1 : value;
        }

        public int PageSize
        {
            get => _pageSize;
            set => _pageSize = value < 10 ? 10 : Math.Min(value, 50);
        }

        public string SortBy
        {
            get => _sortBy;
            set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    return;
                }

                _sortBy = _validateSortFields
                    .FirstOrDefault(first => first.Equals(value, StringComparison.OrdinalIgnoreCase))
                    ?? _sortBy;
            }
        }

        public string SortOrder
        {
            get => _sortOrder == SortDirection.Descending ? "desc" : "asc";
            set => _sortOrder = value?.ToLower() switch
            {
                "desc" or "descending" => SortDirection.Descending,
                _ => SortDirection.Ascending,
            };
        }

        public bool IsDescending => _sortOrder == SortDirection.Descending;
    }
}
