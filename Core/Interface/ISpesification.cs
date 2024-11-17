using System;
using System.Linq.Expressions;

namespace Core.Interface;

public interface ISpesification<T>
{
    Expression<Func<T, bool>>? Criteria { get; }
    Expression<Func<T, object>>? OrderBy { get; }
    Expression<Func<T, object>>? OrderByDescending { get; }
    List<Expression<Func<T, object>>> Includes {get;}
    List<string> IncludeStrings {get;} //For Then include
    bool IsDistinct {get;}
    int Take{get;}
    int Skip{get;}
    bool IsPagingEnabled{get;}
    IQueryable<T> ApplyCriteria(IQueryable<T> query);

}


public interface ISpesification<T, TResult> : ISpesification<T>
{
    Expression<Func<T, TResult>>? Select {get;}
    
}
