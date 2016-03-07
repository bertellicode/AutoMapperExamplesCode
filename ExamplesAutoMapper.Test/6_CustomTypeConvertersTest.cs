

using ExamplesAutoMapper.Mapper.Adapter;
using ExamplesAutoMapper.Mapper.Config.AutoMapper;
using ExamplesAutoMapper.Model.CustomTypeConverters;
using ExamplesAutoMapper.Test.Config;
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
        private IWatch<Destination> _watch;

        private Source source;

        public CustomTypeConvertersTest()
        {
            source = new Source
            {
                Value1 = "5",
                Value2 = "01/01/2000",
                Value3 = "ExamplesAutoMapper.Model.CustomTypeConverters+Destination"
            };

            _watch = new Watch<Destination>();
        }

        [TestMethod]
        public void AutoMapperCustomTypeConvertersMethod()
        {

            _typeAdapter = new AutoMapperAdapter();

            AutoMapperConfiguration.RegisterMappings();

            Destination destination = _watch.AddWatch(() => _typeAdapter.Adapt<Source, Destination>(source), _typeAdapter);

            Asserts(destination);

        }

        public void Asserts(Destination destination)
        {

            Assert.IsInstanceOfType(destination, typeof(Destination));
            Assert.IsInstanceOfType(destination.Value3, typeof(Destination));

        }

    }
}
