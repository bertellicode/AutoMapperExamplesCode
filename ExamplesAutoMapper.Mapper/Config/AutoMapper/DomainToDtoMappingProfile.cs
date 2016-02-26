
using AutoMapper;
using ExamplesAutoMapper.Model;
using ExamplesAutoMapper.Model.Dto;

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
        }
    }
}
