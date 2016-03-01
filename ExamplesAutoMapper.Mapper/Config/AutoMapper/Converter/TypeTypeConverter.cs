

using System;
using AutoMapper;

namespace ExamplesAutoMapper.Mapper.Config.AutoMapper.Converter
{
    public class TypeTypeConverter : ITypeConverter<string, Type>
    {
        public Type Convert(ResolutionContext context)
        {
            return context.SourceType;
        }
    }
}
