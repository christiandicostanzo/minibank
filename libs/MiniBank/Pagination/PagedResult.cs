namespace MiniBank.Pagination;

public class PagedResult<T>
{
    public int PageNumber { get; set; }
    public int PageSize { get; set; }
    public IList<T> Items { get; set; } = new List<T>();
}
