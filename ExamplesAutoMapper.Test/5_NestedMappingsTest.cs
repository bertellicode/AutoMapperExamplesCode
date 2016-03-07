

using ExamplesAutoMapper.Mapper.Adapter;
using ExamplesAutoMapper.Mapper.Config.AutoMapper;
using ExamplesAutoMapper.Model.Dto;
using ExamplesAutoMapper.Model.NestedMappings;
using ExamplesAutoMapper.Test.Config;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace ExamplesAutoMapper.Test
{
    /// <summary>
    /// Summary description for Nested Mappings
    /// </summary>
    [TestClass]
    public class NestedMappingsTest
    {

        private ITypeAdapter _typeAdapter;
        private IWatch<OuterDto> _watch;

        private OuterSource outerSource;

        public NestedMappingsTest()
        {
            outerSource = new OuterSource
            {
                Value = 5,
                Inner = new InnerSource { OtherValue = 15 }
            };

            _watch = new Watch<OuterDto>();
        }


        [TestMethod]
        public void AutoMapperFlatteningMethod()
        {

            _typeAdapter = new AutoMapperAdapter();

            AutoMapperConfiguration.RegisterMappings();

            OuterDto outerDto = _watch.AddWatch(() => _typeAdapter.Adapt<OuterSource, OuterDto>(outerSource), _typeAdapter);

            Asserts(outerDto);

        }

        public void Asserts(OuterDto outerDto)
        {

            Assert.AreEqual(5, outerDto.Value);
            Assert.IsNotNull(outerDto.Inner);
            Assert.AreEqual(15, outerDto.Inner.OtherValue);
            Assert.IsInstanceOfType(outerDto, typeof(OuterDto));

        }

    }
}
