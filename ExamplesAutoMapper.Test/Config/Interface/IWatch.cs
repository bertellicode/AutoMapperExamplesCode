
using System;
using System.Collections.Generic;
using ExamplesAutoMapper.Mapper.Adapter;

namespace ExamplesAutoMapper.Test.Config.Interface
{
    public interface IWatch<T> where T : class
    {
        IEnumerable<T> AddWatch(Func<T> action, ITypeAdapter _typeAdapter);

        T AddWatchSingle(Func<T> action, ITypeAdapter _typeAdapter);
    }
}
