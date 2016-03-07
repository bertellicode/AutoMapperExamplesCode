

using System;
using System.Diagnostics;
using ExamplesAutoMapper.Mapper.Adapter;
using ExamplesAutoMapper.Mapper.Config.AutoMapper;
using ExamplesAutoMapper.Model.NullSubstitution;
using ExamplesAutoMapper.Test.Config;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace ExamplesAutoMapper.Test
{
    /// <summary>
    /// Summary description for Custom Value Resolvers
    /// </summary>
    [TestClass]
    public class NullSubstitutionTest
    {
        private ITypeAdapter _typeAdapter;
        private IWatch<Destination> _watch;

        private Source source;

        public NullSubstitutionTest()
        {
            source = new Source { Value = null };
            _watch = new Watch<Destination>();
        }

        [TestMethod]
        public void AutoMapperNullSubstitutionMethod()
        {

            _typeAdapter = new AutoMapperAdapter();

            AutoMapperConfiguration.RegisterMappings();

            Destination destination;

            destination = _watch.AddWatch(() => _typeAdapter.Adapt<Source, Destination>(source), _typeAdapter);

            Asserts(destination);

            source.Value = 5;

            destination = _watch.AddWatch(() => _typeAdapter.Adapt<Source, Destination>(source), _typeAdapter);

            Asserts(destination);

        }

        public void Asserts(Destination destination)
        {

            Assert.IsNotNull(destination.Value);
            Assert.AreEqual(10, destination.Value);

        }

    }
}
