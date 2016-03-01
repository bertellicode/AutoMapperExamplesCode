
using System;
using AutoMapper;
using ExamplesAutoMapper.Mapper.Config.AutoMapper.Converter;
using ExamplesAutoMapper.Model.CustomTypeConverters;
using ExamplesAutoMapper.Model.ListAndArrays;
using ExamplesAutoMapper.Model.Dto;
using ExamplesAutoMapper.Model.Flattening;
using ExamplesAutoMapper.Model.NestedMappings;
using ExamplesAutoMapper.Model.Projection;
using Source = ExamplesAutoMapper.Model.ListAndArrays.Source;

namespace ExamplesAutoMapper.Mapper.Config.AutoMapper
{
    public class DomainToDtoMappingProfile : Profile
    {
        public override string ProfileName
        {
            get { return "DomainToDtoMappingProfile"; }
        }

        protected override void Configure()
        {
            global::AutoMapper.Mapper.CreateMap<Order, OrderDto>();

            global::AutoMapper.Mapper.CreateMap<CalendarEvent, CalendarEventDto>()
                .ForMember(dest => dest.EventDate, opt => opt.MapFrom(src => src.Date.Date))
                .ForMember(dest => dest.EventHour, opt => opt.MapFrom(src => src.Date.Hour))
                .ForMember(dest => dest.EventMinute, opt => opt.MapFrom(src => src.Date.Minute));

            global::AutoMapper.Mapper.CreateMap<Source, DestinationDto>();

            global::AutoMapper.Mapper.CreateMap<ParentSource, ParentDto>().Include<ChildSource, ChildDto>();

            global::AutoMapper.Mapper.CreateMap<ChildSource, ChildDto>();

            global::AutoMapper.Mapper.CreateMap<OuterSource, OuterDto>();

            global::AutoMapper.Mapper.CreateMap<InnerSource, InnerDto>();

            //Custom type converters
            global::AutoMapper.Mapper.CreateMap<string, int>().ConvertUsing(Int32.Parse);
            global::AutoMapper.Mapper.CreateMap<string, DateTime>().ConvertUsing(new DateTimeTypeConverter());
            global::AutoMapper.Mapper.CreateMap<string, Type>().ConvertUsing<TypeTypeConverter>();

            global::AutoMapper.Mapper.CreateMap<Source, Destination>();

        }
    }
}
