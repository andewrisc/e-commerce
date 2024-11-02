using System.Linq.Expressions;
using Core.Interface;

namespace Core.Specifications;

public class BaseSpesification<T> : ISpesification<T>
{
    protected BaseSpesification() : this(null) { }
    private readonly Expression<Func<T, bool>>? criteria;
    public BaseSpesification(Expression<Func<T, bool>>? criteria)
    {
        this.criteria = criteria;
    }
    public Expression<Func<T, bool>>? Criteria => criteria;

    public Expression<Func<T, object>>? OrderBy { get; private set; }

    public Expression<Func<T, object>>? OrderByDescending {get; private set;}

    public bool IsDistinct {get; private set;}

    protected void AddOrderBy(Expression<Func<T, object>> OrderByExpression)
    {
        OrderBy = OrderByExpression;
    }
    protected void AddOrderByDescending(Expression<Func<T, object>> OrderByDescExpression)
    {
        OrderByDescending = OrderByDescExpression;
    }
    protected void ApplyDisctinct()
    {
        IsDistinct = true;
    }
}

public class BaseSpesification<T, TResult>(Expression<Func<T, bool>>? criteria)
: BaseSpesification<T>(criteria), ISpesification<T, TResult>
{
    protected BaseSpesification() : this(null) { }
    public Expression<Func<T, TResult>>? Select {get; private set;}

    protected void AddSelect(Expression<Func<T, TResult>> selectExpression){
        Select = selectExpression;
    }
}
