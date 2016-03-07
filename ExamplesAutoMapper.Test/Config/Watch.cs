
using System;
using System.Diagnostics;
using ExamplesAutoMapper.Mapper.Adapter;

namespace ExamplesAutoMapper.Test.Config
{
    public class Watch<TEntity> : IWatch<TEntity> where TEntity : class
    {

        //Metodo generico utilizado para saber o tempo exato da função de conversão de um tipo para outro
        public TEntity AddWatch(Func<TEntity> action, ITypeAdapter typeAdapter)
        {
            var stopWatch = new Stopwatch();

            stopWatch.Start();

            var result = action();

            Debug.WriteLine("{0}: Tempo de Execução {1}", typeAdapter.Name, stopWatch.Elapsed);

            return result;
        }

    }
}
