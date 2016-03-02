

using AutoMapper;
using ExamplesAutoMapper.Model.CustomValueResolvers;

namespace ExamplesAutoMapper.Mapper.Config.AutoMapper.Resolver
{
    public class CustomResolver : ValueResolver<Source, int>
    {
        protected override int ResolveCore(Source source)
        {
            return source.Value1 + source.Value2;
        }
    }
}
