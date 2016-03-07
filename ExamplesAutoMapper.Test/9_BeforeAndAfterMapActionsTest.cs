

using System;
using System.Diagnostics;
using ExamplesAutoMapper.Mapper.Adapter;
using ExamplesAutoMapper.Mapper.Config.AutoMapper;
using ExamplesAutoMapper.Model.BeforeAndAfterMapActions;
using ExamplesAutoMapper.Test.Config;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace ExamplesAutoMapper.Test
{
    /// <summary>
    /// Summary description for Before And After Map Actions
    /// </summary>
    [TestClass]
    public class BeforeAndAfterMapActionsTest
    {

        private ITypeAdapter _typeAdapter;
        private IWatch<Destination> _watch;

        private Source source;

        public BeforeAndAfterMapActionsTest()
        {
            source = new Source
            {
                Name = "Kid",
                Value1 = 5,
                Value2 = 5
            };

            _watch = new Watch<Destination>();
        }

        [TestMethod]
        public void AutoMapperBeforeAndAfterMapActionsMethod()
        {

            _typeAdapter = new AutoMapperAdapter();

            AutoMapperConfiguration.RegisterMappings();

            Destination destination = _watch.AddWatch(() => _typeAdapter.Adapt<Source, Destination>(source), _typeAdapter);

            Asserts(destination);

        }

        public void Asserts(Destination destination)
        {

            Assert.IsInstanceOfType(destination, typeof(Destination));
            Assert.AreEqual(10, destination.Total);

        }

    }
}
