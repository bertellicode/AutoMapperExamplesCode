

using System;
using System.Diagnostics;
using ExamplesAutoMapper.Mapper.Adapter;
using ExamplesAutoMapper.Mapper.Config.AutoMapper;
using ExamplesAutoMapper.Model.ConditionalMapping;
using ExamplesAutoMapper.Test.Config;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace ExamplesAutoMapper.Test
{
    /// <summary>
    /// Summary description for Conditional Mapping
    /// </summary>
    [TestClass]
    public class ConditionalMappingTest
    {

        private ITypeAdapter _typeAdapter;
        private IWatch<Destination> _watch;

        private Source source;

        public ConditionalMappingTest()
        {
            source = new Source
            {
                Value = 5
            };

            _watch = new Watch<Destination>();
        }

        [TestMethod]
        public void AutoMapperCustomTypeConvertersMethod()
        {

            _typeAdapter = new AutoMapperAdapter();

            AutoMapperConfiguration.RegisterMappings();

            Destination destination;

            destination = _watch.AddWatch(() => _typeAdapter.Adapt<Source, Destination>(source), _typeAdapter);

            Asserts(destination);

            source.Value = 0;

            destination = _watch.AddWatch(() => _typeAdapter.Adapt<Source, Destination>(source), _typeAdapter);

            Asserts(destination);

        }

        public void Asserts(Destination destination)
        {

            Assert.IsInstanceOfType(destination, typeof(Destination));
            Assert.AreEqual(0, destination.Value);

        }

    }
}
