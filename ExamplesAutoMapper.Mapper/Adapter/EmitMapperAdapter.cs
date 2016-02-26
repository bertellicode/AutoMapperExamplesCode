
using EmitMapper;

namespace ExamplesAutoMapper.Mapper.Adapter
{
    public class EmitMapperAdapter : ITypeAdapter
    {
        public string Name
        {
            get { return "EmitMapper"; }
        }

        public TTarget Adapt<TSource, TTarget>(TSource source)
        {
            return ObjectMapperManager.DefaultInstance.GetMapper<TSource, TTarget>().Map(source); 
        }
    }
}
