using System;
using System.Linq.Expressions;

namespace Core.Interface;

public interface ISpesification<T>
{
    Expression<Func<T, bool>>? Criteria { get; }
    Expression<Func<T, object>>? OrderBy { get; }
    Expression<Func<T, object>>? OrderByDescending { get; }
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
