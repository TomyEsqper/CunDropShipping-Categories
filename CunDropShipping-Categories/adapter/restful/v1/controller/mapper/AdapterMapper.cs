using CunDropShipping_Categories.adapter.restful.v1.controller.Entity;
using CunDropShipping_Categories.domain.Entity;

namespace CunDropShipping_Categories.adapter.restful.v1.controller.mapper;

public class AdapterMapper : IAdapterMapper
{
    public AdapterCategoriesEntity ToAdapterCategories(DomainCategoriesEntity domainCategories)
    {
        if (domainCategories == null) throw new ArgumentNullException(nameof(domainCategories));
        return new AdapterCategoriesEntity();
        {
            // IdCategories = domainCategories.IdCategories,
                
        }
    }
}