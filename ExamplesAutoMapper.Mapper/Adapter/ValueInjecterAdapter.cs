

namespace ExamplesAutoMapper.Mapper.Adapter
{
    public class ValueInjecterAdapter : ITypeAdapter
    {
        public string Name
        {
            get { return "ValueInjecter"; }
        }

        public TTarget Adapt<TSource, TTarget>(TSource source)
        {
            return Omu.ValueInjecter.Mapper.Map<TSource, TTarget>(source);
        }
    }
}
