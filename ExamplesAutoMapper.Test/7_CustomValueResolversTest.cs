
using System;
using System.Diagnostics;
using ExamplesAutoMapper.Mapper.Adapter;
using ExamplesAutoMapper.Mapper.Config.AutoMapper;
using ExamplesAutoMapper.Model.CustomValueResolvers;
using ExamplesAutoMapper.Test.Config;
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
        private IWatch<Destination> _watch;

        private Source source;

        public CustomValueResolversTest()
        {
            source = new Source
            {
                Value1 = 5,
                Value2 = 7
            };

            _watch = new Watch<Destination>();
        }


        [TestMethod]
        public void AutoMapperFlatteningMethod()
        {

            _typeAdapter = new AutoMapperAdapter();

            AutoMapperConfiguration.RegisterMappings();

            Destination destination = _watch.AddWatch(() => _typeAdapter.Adapt<Source, Destination>(source), _typeAdapter);

            Asserts(destination);

        }

        public void Asserts(Destination destination)
        {

            Assert.IsInstanceOfType(destination, typeof(Destination));
            Assert.AreEqual(12, destination.Total);

        }

    }
}
