

using System;
using System.Diagnostics;
using ExamplesAutoMapper.Mapper.Adapter;
using ExamplesAutoMapper.Mapper.Config.AutoMapper;
using ExamplesAutoMapper.Model.Dto;
using ExamplesAutoMapper.Model.NestedMappings;
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

        private OuterSource outerSource;

        public NestedMappingsTest()
        {
            outerSource = new OuterSource
            {
                Value = 5,
                Inner = new InnerSource { OtherValue = 15 }
            };
        }


        [TestMethod]
        public void AutoMapperFlatteningMethod()
        {

            _typeAdapter = new AutoMapperAdapter();

            AutoMapperConfiguration.RegisterMappings();

            OuterDto outerDto = AddWatch(() => _typeAdapter.Adapt<OuterSource, OuterDto>(outerSource));

            Assert.AreEqual(5,outerDto.Value);
            Assert.IsNotNull(outerDto.Inner);
            Assert.AreEqual(15, outerDto.Inner.OtherValue);
            Assert.IsInstanceOfType(outerDto, typeof (OuterDto));

        }

        public OuterDto AddWatch(Func<OuterDto> action)
        {
            var stopWatch = new Stopwatch();

            stopWatch.Start();

            var result = action();

            Debug.WriteLine("{0}: Tempo de Execução {1}", _typeAdapter.Name, stopWatch.Elapsed);

            return result;
        }

    }
}
