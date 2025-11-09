using MongoDB.Driver;
using System.Linq.Expressions;

namespace MiniBank.Specification;

public interface Specification<T>
{
    public Specification<T> And<TField>(Expression<Func<T, TField>> expression, TField? value = default);
    public Specification<T> Or<TField>(Expression<Func<T, TField>> expression, TField? value = default);
    public Specification<T> Eq<TField>(Expression<Func<T, TField>> expression, TField? value = default);
}

public class MongoDbSpecification<T> : Specification<T>
{

    FilterDefinition<T> _filterDefinition;

    public MongoDbSpecification()
    {
        _filterDefinition  = Builders<T>.Filter.Empty;
    }

    public FilterDefinition<T> Filter
    { 
        get => _filterDefinition;
    }
    
    public Specification<T> And<TField>(Expression<Func<T, TField>> expression, TField value)
    {
        var _right = Builders<T>.Filter.Eq(expression, value);
        _filterDefinition = Builders<T>.Filter.And(_filterDefinition, _right);
        return this;
    }

    public Specification<T> Or<TField>(Expression<Func<T, TField>> expression, TField value)
    {
        var _right = Builders<T>.Filter.Eq(expression, value);
        _filterDefinition = Builders<T>.Filter.Or(_filterDefinition, _right);
        return this;
    }

    public Specification<T> Eq<TField>(Expression<Func<T, TField>> expression, TField value)
    {
        _filterDefinition = Builders<T>.Filter.Eq(expression, value);
        return this;
    }
  
}
