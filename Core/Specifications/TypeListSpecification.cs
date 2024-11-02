using Core.Entities;

namespace Core.Specifications;

public class TypeListSpecification : BaseSpesification<Product, string>
{
    public TypeListSpecification()
    {
        AddSelect(x => x.Type);
        ApplyDisctinct();
    }
}
