using System;
using System.Linq.Expressions;

namespace Core.Interface;

public interface ISpesification<T>
{
    Expression<Func<T, bool>>? Criteria { get; }
    Expression<Func<T, object>>? OrderBy { get; }
    Expression<Func<T, object>>? OrderByDescending { get; }
    bool IsDistinct {get;}

}


public interface ISpesification<T, TResult> : ISpesification<T>
{
    Expression<Func<T, TResult>>? Select {get;}
    
}
