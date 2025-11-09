namespace MiniBank.Cache;

public interface IMinibankEntityCache<T>
{
    List<T> GetList(string cacheKey);
    bool SaveList(string cacheKey, IList<T> entities);
    bool Invalidate(string cacheKey);
}
