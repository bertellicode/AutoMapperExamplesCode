

using System;
using System.Diagnostics;
using ExamplesAutoMapper.Mapper.Adapter;
using ExamplesAutoMapper.Mapper.Config.AutoMapper;
using ExamplesAutoMapper.Model.NullSubstitution;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace ExamplesAutoMapper.Test
{
    /// <summary>
    /// Summary description for Custom Value Resolvers
    /// </summary>
    [TestClass]
    public class NullSubstitution
    {
        private ITypeAdapter _typeAdapter;

        private Source source;

        public NullSubstitution()
        {
            source = new Source { Value = null };
        }

        [TestMethod]
        public void AutoMapperNullSubstitutionMethod()
        {

            _typeAdapter = new AutoMapperAdapter();

            AutoMapperConfiguration.RegisterMappings();

            Destination destination;

            destination = AddWatch(() => _typeAdapter.Adapt<Source, Destination>(source));

            Assert.IsNotNull(destination.Value);
            Assert.AreEqual(10, destination.Value);

            source.Value = 5;

            destination = AddWatch(() => _typeAdapter.Adapt<Source, Destination>(source));

            Assert.IsNotNull(destination.Value);
            Assert.AreEqual(10, destination.Value);

        }

        public Destination AddWatch(Func<Destination> action)
        {
            var stopWatch = new Stopwatch();

            stopWatch.Start();

            var result = action();

            Debug.WriteLine("{0}: Tempo de Execução {1}", _typeAdapter.Name, stopWatch.Elapsed);

            return result;
        }

    }
}
