

using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq.Expressions;
using ExamplesAutoMapper.Test.Config.Interface;

namespace ExamplesAutoMapper.Test.Config
{
    public class Watch<T> : IWatch<T> where T : class
    {
        public IEnumerable<T> AddWatch(Expression<Func<T, bool>> action)
        {
            var stopWatch = new Stopwatch();

            stopWatch.Start();

            var expression = action;

            stopWatch.Stop();


        }
    }
}
