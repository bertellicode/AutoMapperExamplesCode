
using System;
using AutoMapper;
using ExamplesAutoMapper.Mapper.Config.AutoMapper.Converter;
using ExamplesAutoMapper.Mapper.Config.AutoMapper.Resolver;
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

            global::AutoMapper.Mapper.CreateMap<Model.CustomTypeConverters.Source, Destination>();

            //Custom value resolvers
            global::AutoMapper.Mapper.CreateMap<Model.CustomValueResolvers.Source, Model.CustomValueResolvers.Destination>()
                                        .ForMember(dest => dest.Total, opt => opt.ResolveUsing<CustomResolver>());

            //Null substitution
            global::AutoMapper.Mapper.CreateMap<Model.NullSubstitution.Source, Model.NullSubstitution.Destination>()
                                        .ForMember(dest => dest.Value, opt => opt.NullSubstitute(10));

            //Before and after map actions
            global::AutoMapper.Mapper.CreateMap<Model.BeforeAndAfterMapActions.Source, Model.BeforeAndAfterMapActions.Destination>()
                                        .BeforeMap((src, dest) => dest.Total = src.Value1 + src.Value2)
                                        .AfterMap((src, dest) => dest.Name = "John");

                //Maneira incorreta
            //global::AutoMapper.Mapper.CreateMap<Model.BeforeAndAfterMapActions.Source, Model.BeforeAndAfterMapActions.Destination>()
            //                            .ForMember(dest => dest.Total, opt => opt.MapFrom(src => src.Value1 + src.Value2))
            //                            .ForMember(dest => dest.Name, opt => opt.MapFrom(src => src.Name));




        }
    }
}
