
using System;
using System.Diagnostics;
using ExamplesAutoMapper.Mapper.Adapter;
using ExamplesAutoMapper.Mapper.Config.AutoMapper;
using ExamplesAutoMapper.Model.CustomValueResolvers;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace ExamplesAutoMapper.Test
{
    /// <summary>
    /// Summary description for Custom Value Resolvers
    /// </summary>
    [TestClass]
    public class CustomValueResolversTest
    {

        private ITypeAdapter _typeAdapter;

        private Source source;

        public CustomValueResolversTest()
        {
            source = new Source
            {
                Value1 = 5,
                Value2 = 7
            };
        }


        [TestMethod]
        public void AutoMapperFlatteningMethod()
        {

            _typeAdapter = new AutoMapperAdapter();

            AutoMapperConfiguration.RegisterMappings();

            Destination destination = AddWatch(() => _typeAdapter.Adapt<Source, Destination>(source));

            Assert.IsInstanceOfType(destination, typeof(Destination));
            Assert.AreEqual(12, destination.Total);

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
