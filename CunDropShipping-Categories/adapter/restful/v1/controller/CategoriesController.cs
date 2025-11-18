using CunDropShipping_Categories.adapter.restful.v1.controller.Entity;
using CunDropShipping_Categories.adapter.restful.v1.controller.mapper;
using CunDropShipping_Categories.application.Service;
using Microsoft.AspNetCore.Mvc;


namespace CunDropShipping_Categories.adapter.restful.v1.controller;

[ApiController]
[Route("api/v1/Categories")]
public class CategoriesController : ControllerBase
{
    private readonly ICategoriesService _categoriesService;
    private readonly IAdapterMapper _adapterMapper;

    public CategoriesController(ICategoriesService categoriesService, IAdapterMapper adapterMapper)
    {
        _categoriesService = categoriesService;
        _adapterMapper = adapterMapper;
    }
    
    [HttpGet]
    public ActionResult<List<AdapterCategoriesEntity>> GetAllCategories()
    {
        return Ok(_adapterMapper.ToAdapterCategoriesList(_categoriesService.GetAllCategories()));
    }

    // Evitar conflicto de rutas con {id} y otras acciones: usar un segmento explícito
    [HttpGet("ByName/{TypeCategory}")]
    public ActionResult<List<AdapterCategoriesEntity>> GetCategoryByName(string TypeCategory)
    {
        var category = _categoriesService.GetCategoriesByName(TypeCategory);
        if (category == null || category.Count == 0) return NotFound();
        return Ok(_adapterMapper.ToAdapterCategoriesList(category));
    }

    [HttpPost]
    public ActionResult<AdapterCategoriesEntity> CreateCategory([FromBody] AdapterCategoriesEntity categories)
    {
        var domain = _adapterMapper.ToDomainCategories(categories);
        var createdCategory = _categoriesService.CreateCategory(domain);
        var adapterResult = _adapterMapper.ToAdapterCategories(createdCategory);
        // El nombre del parámetro de ruta en el atributo es "TypeCategory",
        // por eso debemos pasar la clave TypeCategory para que el enrutador pueda generar la URL.
        return CreatedAtAction(nameof(GetCategoryByName), new { TypeCategory = adapterResult.TypeCategory }, adapterResult);
    }

    [HttpPut("{id}")]
    public ActionResult<AdapterCategoriesEntity> UpdateCategory(int id, [FromBody] AdapterCategoriesEntity categories)
    {
        var domainCategory = _adapterMapper.ToDomainCategories(categories);
        var updatedCategory = _categoriesService.UpdateCategory(id, domainCategory);
        if (updatedCategory == null) return NotFound();
        var adapterResult = _adapterMapper.ToAdapterCategories(updatedCategory);
        return Ok(adapterResult);
    }
    
// Archivo: CategoriesController.cs (En el Microservicio)

    [HttpDelete("{id}")]
// ✅ CORREGIDO: Solo se pide la ID de la ruta.
    public ActionResult<AdapterCategoriesEntity> DeleteCategoryById(int id)
    {
        // 1. Llamada al servicio, solo con el ID.
        // OJO: Debes cambiar la firma de tu servicio interno para que solo acepte int id.
        var deletedCategory = _categoriesService.DeleteCategoryById(id); 
    
        if (deletedCategory == null) return NotFound();
    
        var adapterResult = _adapterMapper.ToAdapterCategories(deletedCategory);
        return Ok(adapterResult);
    }

    [HttpDelete("ByName/{TypeCategory}")]
    public ActionResult<List<AdapterCategoriesEntity>> DeleteCategoryByName(string TypeCategory)
    {
        var deletedCategory = _categoriesService.DeleteCategoryByName(TypeCategory);
        if (deletedCategory == null || deletedCategory.Count == 0) return NotFound();
        var adapterResult = _adapterMapper.ToAdapterCategoriesList(deletedCategory);
        return Ok(adapterResult);
    }
}