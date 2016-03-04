

using System;
using System.Diagnostics;
using ExamplesAutoMapper.Mapper.Adapter;
using ExamplesAutoMapper.Mapper.Config.AutoMapper;
using ExamplesAutoMapper.Model.BeforeAndAfterMapActions;
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

        private Source source;

        public BeforeAndAfterMapActionsTest()
        {
            source = new Source
            {
                Name = "Kid",
                Value1 = 5,
                Value2 = 5
            };
        }

        [TestMethod]
        public void AutoMapperBeforeAndAfterMapActionsMethod()
        {

            _typeAdapter = new AutoMapperAdapter();

            AutoMapperConfiguration.RegisterMappings();

            Destination destination = AddWatch(() => _typeAdapter.Adapt<Source, Destination>(source));

            Assert.IsInstanceOfType(destination, typeof(Destination));
            Assert.AreEqual(10, destination.Total);

        }


        public Destination AddWatch(Func<Destination> action)
        {
            var stopWatch = new Stopwatch();

            stopWatch.Start();

            var result = action();

            Debug.WriteLine("{0}: Tempo de Execução {1}", _typeAdapter.Name, stopWatch.Elapsed);

            return result;
        }

    }
}
