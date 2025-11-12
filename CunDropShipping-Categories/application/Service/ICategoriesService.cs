using CunDropShipping_Categories.domain.Entity;

namespace CunDropShipping_Categories.application.Service;

public interface ICategoriesService
{
    List<DomainCategoriesEntity> GetAllCategories();
    List<DomainCategoriesEntity>? GetCategoriesByName(string name);
    DomainCategoriesEntity CreateCategory(DomainCategoriesEntity category);
    DomainCategoriesEntity? UpdateCategory(int id, DomainCategoriesEntity category);
    DomainCategoriesEntity? DeleteCategoryById(int id, DomainCategoriesEntity category);
    List<DomainCategoriesEntity>? DeleteCategoryByName(string name);
}