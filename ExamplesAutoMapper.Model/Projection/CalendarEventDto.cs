

using System;

namespace ExamplesAutoMapper.Model.Projection
{
    public class CalendarEventDto
    {

        public DateTime EventDate { get; set; }

        public int EventHour { get; set; }

        public int EventMinute { get; set; }

        public string Title { get; set; }

    }
}
