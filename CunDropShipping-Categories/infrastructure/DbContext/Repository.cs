using CunDropShipping_Categories.domain.Entity;
using CunDropShipping_Categories.infrastructure.Mapper;

namespace CunDropShipping_Categories.infrastructure.DbContext;

public class Repository
{
    private readonly AppDbContext _context;
    private readonly IInfrastructureMapper _mapper;

    public Repository(AppDbContext context, IInfrastructureMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }

    public List<DomainCategoriesEntity> GetAllCategories()
    {
        var entities = _context.categories.ToList();
        var list = new List<DomainCategoriesEntity>();
        foreach (var e in entities)
        {
            list.Add(_mapper.ToDomainCategories(e));
        }

        return list;
    }

    public List<DomainCategoriesEntity>? GetCategoriesByName(string name)
    {
        if (string.IsNullOrWhiteSpace(name)) return null;
        
        var existingCategory = name.Trim().ToLower();

        var foundCategory = _context.categories
            .Where(t => t.TypeCategory.ToLower().Contains(existingCategory))
            .ToList();
        
        return _mapper.ToDomainCategoriesList(foundCategory);
    }

    public DomainCategoriesEntity CreateCategory(DomainCategoriesEntity domainCategory)
    {
        var newEntity = _mapper.ToInfrastructureCategories(domainCategory);
        _context.categories.Add(newEntity);
        _context.SaveChanges();
        return _mapper.ToDomainCategories(newEntity);
    }

    public DomainCategoriesEntity? UpdateCategory(int id, DomainCategoriesEntity domainCategory)
    {
        var existingCategory = _context.categories.Find(id);
        if (existingCategory == null) return null;
        
        existingCategory.TypeCategory = domainCategory.TypeCategory;
        _context.SaveChanges();
        return _mapper.ToDomainCategories(existingCategory);
    }

    public DomainCategoriesEntity? DeleteCategoryById(int id, DomainCategoriesEntity domainCategory)
    {
        var existingProduct = _context.categories.Find(id);
        if (existingProduct == null) return null;
        
        _context.categories.Remove(existingProduct);
        _context.SaveChanges();
        return _mapper.ToDomainCategories(existingProduct);
    }

    public DomainCategoriesEntity? DeleteCategoryByName(string name)
    {
        if (string.IsNullOrWhiteSpace(name)) return null;
        
        var existingCategory = name.Trim().ToLower();

        var foundCategory = _context.categories
            .FirstOrDefault(t => t.TypeCategory.ToLower().Contains(existingCategory));

        if (foundCategory == null) return null;

        _context.categories.Remove(foundCategory);
        _context.SaveChanges();

        return _mapper.ToDomainCategories(foundCategory);
    }
}