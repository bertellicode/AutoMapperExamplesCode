

using System;
using System.Collections.Generic;
using System.Diagnostics;
using ExamplesAutoMapper.Mapper.Adapter;
using ExamplesAutoMapper.Mapper.Config.AutoMapper;
using ExamplesAutoMapper.Model.Dto;
using ExamplesAutoMapper.Model.ListAndArrays;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace ExamplesAutoMapper.Test
{
    /// <summary>
    /// Summary description for ListAndArrays
    /// </summary>
    [TestClass]
    public class ListAndArrays
    {

        private ITypeAdapter _typeAdapter;

        private Source[] sources;
        private ParentSource[] sourcesPolymorphic;

        public ListAndArrays()
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
        }


        [TestMethod]
        public void AutoMapperListAndArraysMethod()
        {

            _typeAdapter = new AutoMapperAdapter();

            AutoMapperConfiguration.RegisterMappings();

            IEnumerable<DestinationDto> ienumerableDest = AddWatch(() => (IList<DestinationDto>) _typeAdapter.Adapt<Source[], IEnumerable<DestinationDto>>(sources));
            ICollection<DestinationDto> icollectionDest = AddWatch(() => (IList<DestinationDto>) _typeAdapter.Adapt<Source[], ICollection<DestinationDto>>(sources));
            IList<DestinationDto> ilistDest = AddWatch(() => _typeAdapter.Adapt<Source[], IList<DestinationDto>>(sources));
            List<DestinationDto> listDest = (List<DestinationDto>) AddWatch(() => _typeAdapter.Adapt<Source[], List<DestinationDto>>(sources));
            DestinationDto[] arrayDest = (DestinationDto[]) AddWatch(() => _typeAdapter.Adapt<Source[], DestinationDto[]>(sources));

        }

        [TestMethod]
        public void AutoMapperListAndArraysPolymorphicElementsMethod()
        {

            _typeAdapter = new AutoMapperAdapter();

            AutoMapperConfiguration.RegisterMappings();

            ParentDto[] destinations = (ParentDto[]) AddWatchPolymorphic(() => _typeAdapter.Adapt<ParentSource[], ParentDto[]>(sourcesPolymorphic));

            Assert.IsInstanceOfType(destinations[0], typeof(ParentDto));
            Assert.IsInstanceOfType(destinations[1], typeof(ChildDto));
            Assert.IsInstanceOfType(destinations[2], typeof(ParentDto));

        }


        public IList<DestinationDto> AddWatch(Func<IList<DestinationDto>> action)
        {
            var stopWatch = new Stopwatch();

            stopWatch.Start();

            var result = action();

            Debug.WriteLine("{0}: Tempo de Execução {1}", _typeAdapter.Name, stopWatch.Elapsed);

            return result;
        }

        public IList<ParentDto> AddWatchPolymorphic(Func<IList<ParentDto>> action)
        {
            var stopWatch = new Stopwatch();

            stopWatch.Start();

            var result = action();

            Debug.WriteLine("{0}: Tempo de Execução {1}", _typeAdapter.Name, stopWatch.Elapsed);

            return result;
        }

    }
}
