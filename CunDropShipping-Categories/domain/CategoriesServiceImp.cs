using CunDropShipping_Categories.application.Service;
using CunDropShipping_Categories.domain.Entity;
using CunDropShipping_Categories.infrastructure.DbContext;

namespace CunDropShipping_Categories.domain;

public class CategoriesServiceImp : ICategoriesService
{
    private readonly Repository _repository;

    public CategoriesServiceImp(Repository repository)
    {
        _repository = repository;
    }
    public List<DomainCategoriesEntity> GetAllCategories()
    {
        return _repository.GetAllCategories();
    }

    public List<DomainCategoriesEntity>? GetCategoriesByName(string name)
    {
        return _repository.GetCategoriesByName(name);
    }

    public DomainCategoriesEntity CreateCategory(DomainCategoriesEntity category)
    {
        return _repository.CreateCategory(category);
    }

    public DomainCategoriesEntity? UpdateCategory(int id, DomainCategoriesEntity category)
    {
        return  _repository.UpdateCategory(id, category);
    }

    public DomainCategoriesEntity? DeleteCategoryById(int id)
    {
        return _repository.DeleteCategoryById(id);
    }

    public List<DomainCategoriesEntity>? DeleteCategoryByName(string name)
    {
        var deleted = _repository.DeleteCategoryByName(name);
        return deleted != null ? new List<DomainCategoriesEntity> { deleted } : null;
    }
}