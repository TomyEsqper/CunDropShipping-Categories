using CunDropShipping_Categories.domain.Entity;
using CunDropShipping_Categories.infrastructure.Entity;

namespace CunDropShipping_Categories.infrastructure.Mapper;

public interface IInfrastructureMapper
{
    CategoriesEntity ToInfrastructureCategories(DomainCategoriesEntity domainCategories);
    List<CategoriesEntity> ToInfrastructureCategoriesList(List<DomainCategoriesEntity> domainCategories);
    DomainCategoriesEntity ToDomainCategories(CategoriesEntity categoriesEntity);
    List<DomainCategoriesEntity> ToDomainCategoriesList(List<CategoriesEntity> categoriesList);
}