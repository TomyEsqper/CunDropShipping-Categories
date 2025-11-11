using CunDropShipping_Categories.domain.Entity;

namespace CunDropShipping_Categories.application.Service;

public interface ICategoriesService
{
    List<DomainCategoriesEntity> GetAllCategories();
    DomainCategoriesEntity GetCategoriesByName(string name);
    DomainCategoriesEntity CreateCategories(DomainCategoriesEntity categories);
    DomainCategoriesEntity UpdateCategories(DomainCategoriesEntity categories);
    DomainCategoriesEntity DeleteCategories(int id);
    DomainCategoriesEntity DeleteCategories(DomainCategoriesEntity categories);
}