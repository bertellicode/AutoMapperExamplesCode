
using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace ExamplesAutoMapper.Test.Config.Interface
{
    public interface IWatch<T> where T : class
    {
        IEnumerable<T> AddWatch(Expression<Func<T, bool>> action);
    }
}
