using CunDropShipping_Categories.domain.Entity;
using CunDropShipping_Categories.infrastructure.Entity;

namespace CunDropShipping_Categories.infrastructure.Mapper;

public class InfrastructureMapper : IInfrastructureMapper
{
    public CategoriesEntity ToInfrastructureCategories(DomainCategoriesEntity domainCategories)
    {
        return new CategoriesEntity
        {
            IdCategory = domainCategories.IdCategoriy,
            TypeCategory = domainCategories.TypeCategory,
        };
    }

    public List<CategoriesEntity> ToInfrastructureCategoriesList(List<DomainCategoriesEntity> domainCategories)
    {
        var list = new List<CategoriesEntity>();
        foreach (var d in domainCategories)
        {
            list.Add(ToInfrastructureCategories(d));
        }
        return list;
    }

    public DomainCategoriesEntity ToDomainCategories(CategoriesEntity categoriesEntity)
    {
        return new DomainCategoriesEntity
        {
            IdCategoriy = categoriesEntity.IdCategory,
            TypeCategory = categoriesEntity.TypeCategory,
        };
    }

    public List<DomainCategoriesEntity> ToDomainCategoriesList(List<CategoriesEntity> categoriesList)
    {
        var list = new List<DomainCategoriesEntity>();
        foreach (var c in categoriesList)
        {
            list.Add(ToDomainCategories(c));
        }
        return list;
    }
}