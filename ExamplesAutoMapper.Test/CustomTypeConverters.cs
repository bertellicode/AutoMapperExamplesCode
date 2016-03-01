

using ExamplesAutoMapper.Mapper.Adapter;
using ExamplesAutoMapper.Model.CustomTypeConverters;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace ExamplesAutoMapper.Test
{
    /// <summary>
    /// Summary description for Custom Type Converters
    /// </summary>
    [TestClass]
    public class CustomTypeConverters
    {

        private ITypeAdapter _typeAdapter;

        private Source source;

        public CustomTypeConverters()
        {
            source = new Source
            {
                Value1 = "5",
                Value2 = "01/01/2000",
                Value3 = "AutoMapperSamples.GlobalTypeConverters.GlobalTypeConverters+Destination"
            };
        }

    }
}
