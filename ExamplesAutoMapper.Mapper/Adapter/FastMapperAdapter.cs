
using FastMapper;

namespace ExamplesAutoMapper.Mapper.Adapter
{
    public class FastMapperAdapter : ITypeAdapter
    {
        public string Name
        {
            get { return "FastMapper"; }
        }

        public TTarget Adapt<TSource, TTarget>(TSource source)
        {
            return TypeAdapter.Adapt<TSource, TTarget>(source);
        }
    }
}
