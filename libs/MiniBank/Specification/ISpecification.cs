using System; 
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;
using MongoDB.Driver;
using MongoDB.Driver.Linq;
using StackExchange.Redis;

namespace MiniBank.Specification;

//public interface ISpecification<T>
//{
//    public ISpecification<T> And(Expression<Func<T, object>> expression, object value = null);
//    public ISpecification<T> Or(Expression<Func<T, object>> expression, object value = null);
//    public ISpecification<T> Eq(Expression<Func<T, object>> expression, object value = null);
//}

public class MongoDbSpecification<T> 
{

    FilterDefinition<T> _filterDefinition;
    System.Linq.Expressions.Expression<Func<T, bool>> _expression;


    public MongoDbSpecification()
    {
        _filterDefinition  = Builders<T>.Filter.Empty;
    }

    public FilterDefinition<T> Filter
    { 
        get => _filterDefinition;
    }

    public System.Linq.Expressions.Expression<Func<T, bool>> Expression
    { 
        get => Expression;
    }
    
    //System.Linq.Expressions.Expression<Func<Customer, bool>> documentIdExpression = (cust) => cust.Document.DocumentId == document.DocumentId;
    //System.Linq.Expressions.Expression<Func<Customer, bool>> docuemtnTypeExpression = (cust) => cust.Document.Type == document.Type;

    public MongoDbSpecification<T>  And(Expression<Func<T, bool>> expression)
    {
        return this;
    }

    public MongoDbSpecification<T> And<TField>(Expression<Func<T, TField>> expression, TField value)
    {
        var _right = Builders<T>.Filter.Eq(expression, value);
        _filterDefinition = Builders<T>.Filter.And(_filterDefinition, _right);
        return this;
    }

    public MongoDbSpecification<T> Or<TField>(Expression<Func<T, TField>> expression, TField value)
    {
        var _right = Builders<T>.Filter.Eq(expression, value);
        _filterDefinition = Builders<T>.Filter.Or(_filterDefinition, _right);
        return this;
    }

    public MongoDbSpecification<T> Eq<TField>(Expression<Func<T, TField>> expression, TField value)
    {
        _filterDefinition = Builders<T>.Filter.Eq(expression, value);
        return this;
    }

}
