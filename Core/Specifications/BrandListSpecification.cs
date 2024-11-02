using Core.Entities;

namespace Core.Specifications;

public class BrandListSpecification : BaseSpesification<Product, string>
{
    public BrandListSpecification()
    {
        AddSelect(x => x.Brand);
        ApplyDisctinct();
    }
}
