

using AutoMapper;
using ExamplesAutoMapper.Model;
using ExamplesAutoMapper.Model.Dto;
using ExamplesAutoMapper.Model.Flattening;

namespace ExamplesAutoMapper.Mapper.Config.AutoMapper
{
    public class DtoToDomainMappingProfile : Profile
    {
        public override string ProfileName
        {
            get { return "DtoToDomainMappingProfile"; }
        }

        protected override void Configure()
        {
            global::AutoMapper.Mapper.CreateMap<OrderDto, Order>();
        }
    }
}
