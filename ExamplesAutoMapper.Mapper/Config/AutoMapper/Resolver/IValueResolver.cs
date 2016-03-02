

using AutoMapper;

namespace ExamplesAutoMapper.Mapper.Config.AutoMapper.Resolver
{
    public interface IValueResolver
    {

        ResolutionResult Resolve(ResolutionResult source);

    }
}
