

using System;
using System.Diagnostics;
using ExamplesAutoMapper.Mapper.Adapter;
using ExamplesAutoMapper.Mapper.Config.AutoMapper;
using ExamplesAutoMapper.Model.CustomTypeConverters;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace ExamplesAutoMapper.Test
{
    /// <summary>
    /// Summary description for Custom Type Converters
    /// </summary>
    [TestClass]
    public class CustomTypeConvertersTest
    {

        private ITypeAdapter _typeAdapter;

        private Source source;

        public CustomTypeConvertersTest()
        {
            source = new Source
            {
                Value1 = "5",
                Value2 = "01/01/2000",
                Value3 = "ExamplesAutoMapper.Model.CustomTypeConverters+Destination"
            };
        }

        [TestMethod]
        public void AutoMapperCustomTypeConvertersMethod()
        {

            _typeAdapter = new AutoMapperAdapter();

            AutoMapperConfiguration.RegisterMappings();

            Destination destination = AddWatch(() => _typeAdapter.Adapt<Source, Destination>(source));

            Assert.IsInstanceOfType(destination, typeof(Destination));
            Assert.IsInstanceOfType(destination.Value3, typeof(Destination));

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
