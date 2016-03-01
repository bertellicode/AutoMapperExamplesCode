

using System;
using System.Diagnostics;
using ExamplesAutoMapper.Mapper.Adapter;
using ExamplesAutoMapper.Mapper.Config.AutoMapper;
using ExamplesAutoMapper.Model.Dto;
using ExamplesAutoMapper.Model.Projection;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace ExamplesAutoMapper.Test
{
    /// <summary>
    /// Summary description for Projection
    /// </summary>
    [TestClass]
    public class Projection
    {
        private ITypeAdapter _typeAdapter;

        private CalendarEvent calendarEvent;

        public Projection()
        {
            calendarEvent = new CalendarEvent
            {
                Date = new DateTime(2008, 12, 15, 20, 30, 0),
                Title = "Company Holiday Party"
            };
        }

        [TestMethod]
        public void AutoMapperProjectionMethod()
        {

            _typeAdapter = new AutoMapperAdapter();

            AutoMapperConfiguration.RegisterMappings();

            CalendarEventDto calendarEventDto = AddWatch(() => _typeAdapter.Adapt<CalendarEvent, CalendarEventDto>(calendarEvent));

            Assert.AreEqual(new DateTime(2008, 12, 15), calendarEventDto.EventDate);
            Assert.AreEqual((20), calendarEventDto.EventHour);
            Assert.AreEqual((30), calendarEventDto.EventMinute);
            Assert.AreEqual("Company Holiday Party", calendarEventDto.Title);

        }

        [TestMethod]
        public void FastMapperProjectionMethod()
        {

            _typeAdapter = new FastMapperAdapter();

            CalendarEventDto calendarEventDto = AddWatch(() => _typeAdapter.Adapt<CalendarEvent, CalendarEventDto>(calendarEvent));

            Assert.AreEqual(new DateTime(2008, 12, 15), calendarEventDto.EventDate);
            Assert.AreEqual((20), calendarEventDto.EventHour);
            Assert.AreEqual((30), calendarEventDto.EventMinute);
            Assert.AreEqual("Company Holiday Party", calendarEventDto.Title);

        }

        public CalendarEventDto AddWatch(Func<CalendarEventDto> action)
        {
            var stopWatch = new Stopwatch();

            stopWatch.Start();

            var result = action();

            Debug.WriteLine("{0}: Tempo de Execução {1}", _typeAdapter.Name, stopWatch.Elapsed);

            return result;
        }

    }
}
