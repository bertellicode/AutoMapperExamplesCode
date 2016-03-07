

using System.Collections.Generic;
using ExamplesAutoMapper.Mapper.Adapter;
using ExamplesAutoMapper.Mapper.Config.AutoMapper;
using ExamplesAutoMapper.Model.ListAndArrays;
using ExamplesAutoMapper.Test.Config;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace ExamplesAutoMapper.Test
{
    /// <summary>
    /// Summary description for ListAndArrays
    /// </summary>
    [TestClass]
    public class ListAndArraysTest
    {

        private ITypeAdapter _typeAdapter;
        private IWatch<IList<DestinationDto>> _watch;
        private IWatch<IList<ParentDto>> _watchPolymorphic;

        private Source[] sources;
        private ParentSource[] sourcesPolymorphic;

        public ListAndArraysTest()
        {
            sources = new[]
            {
                new Source { SomeValuefff = 5 },
                new Source { SomeValuefff = 6 },
                new Source { SomeValuefff = 7 }
            };

            sourcesPolymorphic = new[]
            {
                new ParentSource(),
                new ChildSource(),
                new ParentSource()
            };

            _watch = new Watch<IList<DestinationDto>>();

            _watchPolymorphic = new Watch<IList<ParentDto>>();

        }


        [TestMethod]
        public void AutoMapperListAndArraysMethod()
        {

            _typeAdapter = new AutoMapperAdapter();

            AutoMapperConfiguration.RegisterMappings();

            IEnumerable<DestinationDto> ienumerableDest = _watch.AddWatch(() => (IList<DestinationDto>)_typeAdapter.Adapt<Source[], IEnumerable<DestinationDto>>(sources), _typeAdapter);
            ICollection<DestinationDto> icollectionDest = _watch.AddWatch(() => (IList<DestinationDto>)_typeAdapter.Adapt<Source[], ICollection<DestinationDto>>(sources), _typeAdapter);
            IList<DestinationDto> ilistDest = _watch.AddWatch(() => _typeAdapter.Adapt<Source[], IList<DestinationDto>>(sources), _typeAdapter);
            List<DestinationDto> listDest = (List<DestinationDto>)_watch.AddWatch(() => _typeAdapter.Adapt<Source[], List<DestinationDto>>(sources), _typeAdapter);
            DestinationDto[] arrayDest = (DestinationDto[])_watch.AddWatch(() => _typeAdapter.Adapt<Source[], DestinationDto[]>(sources), _typeAdapter);

        }

        [TestMethod]
        public void AutoMapperListAndArraysPolymorphicElementsMethod()
        {

            _typeAdapter = new AutoMapperAdapter();

            AutoMapperConfiguration.RegisterMappings();

            ParentDto[] destinations = (ParentDto[])_watchPolymorphic.AddWatch(() => _typeAdapter.Adapt<ParentSource[], ParentDto[]>(sourcesPolymorphic), _typeAdapter);

            AssertsPolymorphic(destinations);

        }

        public void AssertsPolymorphic(ParentDto[] destinations)
        {
            Assert.IsInstanceOfType(destinations[0], typeof(ParentDto));
            Assert.IsInstanceOfType(destinations[1], typeof(ChildDto));
            Assert.IsInstanceOfType(destinations[2], typeof(ParentDto));
        }

    }
}
