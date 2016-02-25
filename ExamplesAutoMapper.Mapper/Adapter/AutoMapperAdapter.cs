
namespace ExamplesAutoMapper.Mapper.Adapter
{
    public class AutoMapperAdapter : ITypeAdapter
    {
        public string Name
        {
            get { return "AutoMapper"; }
        }

        public TTarget Adapt<TSource, TTarget>(TSource source)
        {
            return AutoMapper.Mapper.Map<TTarget>(source);
        }
    }
}
