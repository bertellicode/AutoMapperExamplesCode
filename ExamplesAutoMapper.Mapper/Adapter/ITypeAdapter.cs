

namespace ExamplesAutoMapper.Mapper.Adapter
{
    public interface ITypeAdapter
    {

        string Name { get; }

        TTarget Adapt<TSource, TTarget>(TSource source);

    }
}
