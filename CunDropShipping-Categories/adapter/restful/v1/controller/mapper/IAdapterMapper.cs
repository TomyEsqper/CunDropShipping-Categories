using CunDropShipping_Categories.adapter.restful.v1.controller.Entity;
using CunDropShipping_Categories.domain.Entity;

namespace CunDropShipping_Categories.adapter.restful.v1.controller.mapper;

public interface IAdapterMapper
{
    AdapterCategoriesEntity ToAdapterCategories(DomainCategoriesEntity domainCategories);
    List<AdapterCategoriesEntity> ToAdapterCategoriesList(List<DomainCategoriesEntity> domainCategories);
    DomainCategoriesEntity ToDomainCategories(AdapterCategoriesEntity adapterCategories);
    
}