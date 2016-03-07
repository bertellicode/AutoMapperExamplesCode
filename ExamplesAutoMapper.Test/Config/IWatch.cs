

using System;
using ExamplesAutoMapper.Mapper.Adapter;

namespace ExamplesAutoMapper.Test.Config
{
    public interface IWatch<TEntity> where TEntity : class
    {

        TEntity AddWatch(Func<TEntity> action, ITypeAdapter typeAdapter);

    }
}
