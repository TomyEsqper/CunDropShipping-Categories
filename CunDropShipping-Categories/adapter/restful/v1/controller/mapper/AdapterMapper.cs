using CunDropShipping_Categories.adapter.restful.v1.controller.Entity;
using CunDropShipping_Categories.domain.Entity;

namespace CunDropShipping_Categories.adapter.restful.v1.controller.mapper;

public class AdapterMapper : IAdapterMapper
{
    public AdapterCategoriesEntity ToAdapterCategories(DomainCategoriesEntity domainCategories)
    {
        if (domainCategories == null) throw new ArgumentNullException(nameof(domainCategories));
        return new AdapterCategoriesEntity()
        {
            IdCategory = domainCategories.IdCategoriy,
            TypeCategory = domainCategories.TypeCategory
        };
    }

    public List<AdapterCategoriesEntity> ToAdapterCategoriesList(List<DomainCategoriesEntity> domainCategories)
    {
        var list = new List<AdapterCategoriesEntity>();
        if (domainCategories == null) return list;
        foreach (var d in domainCategories)
        {
            list.Add(ToAdapterCategories(d));
        }
        return list;
    }

    public DomainCategoriesEntity ToDomainCategories(AdapterCategoriesEntity adapterCategories)
    {
        if (adapterCategories == null) throw new ArgumentNullException(nameof(adapterCategories));
        return new DomainCategoriesEntity()
        {
            IdCategoriy = adapterCategories.IdCategory,
            TypeCategory = adapterCategories.TypeCategory
        };
    }
}