
using System;
using System.Collections.Generic;
using System.Diagnostics;
using ExamplesAutoMapper.Mapper.Adapter;
using ExamplesAutoMapper.Test.Config.Interface;

namespace ExamplesAutoMapper.Test.Config
{
    public class Watch<T> : IWatch<T> where T : class
    {
        public IEnumerable<T> AddWatch(Func<T> action, ITypeAdapter _typeAdapter)
        {
            var stopWatch = new Stopwatch();

            stopWatch.Start();

            var result = action();

            Debug.WriteLine("{0}: Tempo de Execução {1}", _typeAdapter.Name, stopWatch.Elapsed);

            //stopWatch.Stop();

            return (IEnumerable<T>) result;
        }

        public T AddWatchSingle(Func<T> action, ITypeAdapter _typeAdapter)
        {
            var stopWatch = new Stopwatch();

            stopWatch.Start();

            var result = action();

            Debug.WriteLine("{0}: Tempo de Execução {1}", _typeAdapter.Name, stopWatch.Elapsed);

            //stopWatch.Stop();

            return result;
        }
    }
}
