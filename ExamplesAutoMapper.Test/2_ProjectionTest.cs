

using System;
using System.Diagnostics;
using ExamplesAutoMapper.Mapper.Adapter;
using ExamplesAutoMapper.Mapper.Config.AutoMapper;
using ExamplesAutoMapper.Model.Projection;
using ExamplesAutoMapper.Test.Config;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace ExamplesAutoMapper.Test
{
    /// <summary>
    /// Summary description for Projection
    /// </summary>
    [TestClass]
    public class ProjectionTest
    {
        private ITypeAdapter _typeAdapter;
        private IWatch<CalendarEventDto> _watch;

        private CalendarEvent calendarEvent;

        public ProjectionTest()
        {
            calendarEvent = new CalendarEvent
            {
                Date = new DateTime(2008, 12, 15, 20, 30, 0),
                Title = "Company Holiday Party"
            };

            _watch = new Watch<CalendarEventDto>();
        }

        [TestMethod]
        public void AutoMapperProjectionMethod()
        {

            _typeAdapter = new AutoMapperAdapter();

            AutoMapperConfiguration.RegisterMappings();

            CalendarEventDto calendarEventDto = _watch.AddWatch(() => _typeAdapter.Adapt<CalendarEvent, CalendarEventDto>(calendarEvent), _typeAdapter);

            Asserts(calendarEventDto);

        }

        [TestMethod]
        public void FastMapperProjectionMethod()
        {

            _typeAdapter = new FastMapperAdapter();

            CalendarEventDto calendarEventDto = _watch.AddWatch(() => _typeAdapter.Adapt<CalendarEvent, CalendarEventDto>(calendarEvent), _typeAdapter);

            Asserts(calendarEventDto);

        }

        public void Asserts(CalendarEventDto calendarEventDto)
        {

            Assert.AreEqual(new DateTime(2008, 12, 15), calendarEventDto.EventDate);
            Assert.AreEqual((20), calendarEventDto.EventHour);
            Assert.AreEqual((30), calendarEventDto.EventMinute);
            Assert.AreEqual("Company Holiday Party", calendarEventDto.Title);

        }

    }
}
