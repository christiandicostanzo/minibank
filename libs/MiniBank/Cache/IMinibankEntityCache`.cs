namespace MiniBank.Cache;

public interface IMinibankEntityCache<T>
{
    bool SaveList(IList<T> entities);
    List<T> GetList();
}
