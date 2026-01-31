namespace LManagement.Application.Interfaces
{
    public interface ISortFieldsProvider
    {
        string[] GetSortFields<T>();
    }
}
