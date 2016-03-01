

using System;
using AutoMapper;

namespace ExamplesAutoMapper.Mapper.Config.AutoMapper.Converter
{
    public class DateTimeTypeConverter : ITypeConverter<string, DateTime>
    {
        public DateTime Convert(ResolutionContext context)
        {
            return System.Convert.ToDateTime(context.SourceValue);
        }
    }
}
