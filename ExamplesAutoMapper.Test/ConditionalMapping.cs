

using System;
using System.Diagnostics;
using ExamplesAutoMapper.Mapper.Adapter;
using ExamplesAutoMapper.Mapper.Config.AutoMapper;
using ExamplesAutoMapper.Model.ConditionalMapping;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace ExamplesAutoMapper.Test
{
    /// <summary>
    /// Summary description for Conditional Mapping
    /// </summary>
    [TestClass]
    public class ConditionalMapping
    {

        private ITypeAdapter _typeAdapter;

        private Source source;

        public ConditionalMapping()
        {
            source = new Source
            {
                Value = 5
            };
        }

        [TestMethod]
        public void AutoMapperCustomTypeConvertersMethod()
        {
            Destination destination;

            _typeAdapter = new AutoMapperAdapter();

            AutoMapperConfiguration.RegisterMappings();

            destination = AddWatch(() => _typeAdapter.Adapt<Source, Destination>(source));

            Assert.IsInstanceOfType(destination, typeof(Destination));
            Assert.AreEqual(0, destination.Value);

            source.Value = 0;

            destination = AddWatch(() => _typeAdapter.Adapt<Source, Destination>(source));

            Assert.IsInstanceOfType(destination, typeof(Destination));
            Assert.AreEqual(0, destination.Value);

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
