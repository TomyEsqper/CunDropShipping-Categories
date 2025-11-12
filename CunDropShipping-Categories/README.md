# CunDropShipping-Categories

Microservicio REST para gestión de categorías (Categories).

Elevator pitch
--------------
Servicio pequeño y enfocado que ofrece CRUD sobre categorías. Ideal como componente de un sistema de e-commerce o catálogo: expone una API REST simple para listar, buscar, crear, actualizar y eliminar categorías almacenadas en MySQL.

Stack técnico
-------------
- Lenguaje / Runtime: C# / .NET 8
- Persistencia: Entity Framework Core (Pomelo.EntityFrameworkCore.MySql)
- Documentación API: Swagger (activo en Development)
- Contenerización: Docker

Arquitectura (resumen)
----------------------
El proyecto sigue una separación en capas clara:
- Adapter (API HTTP): controladores y DTOs en `adapter/restful/v1/controller`
- Application: contratos de servicio (`application/Service`)
- Domain: implementación de la lógica de negocio (`domain`)
- Infrastructure: `DbContext`, repositorio, entidades y mapeadores (`infrastructure`)

Quick start — ejecutar localmente
--------------------------------
Requisitos: .NET 8 SDK y acceso a una base de datos MySQL.

1) Restaurar y ejecutar:

```bash
dotnet restore CunDropShipping-Categories/CunDropShipping-Categories.csproj
dotnet run --project CunDropShipping-Categories/CunDropShipping-Categories.csproj
```

2) Sobrescribir la cadena de conexión (opcional):

```bash
export ConnectionStrings__DefaultConnection="server=HOST;port=3306;database=DB;user=USER;password=PASS;SslMode=none;"
```

Quick start — Docker
--------------------
Construir imagen:

```bash
docker build -t cundropshipping-categories -f CunDropShipping-Categories/Dockerfile .
```

Ejecutar (ejemplo):

```bash
docker run --rm -e ASPNETCORE_URLS="http://+:8080" \
  -e ConnectionStrings__DefaultConnection="server=HOST;port=3306;database=DB;user=USER;password=PASS;SslMode=none;" \
  -p 8080:8080 cundropshipping-categories
```

Explorar la API
---------------
- Swagger (solo en Development): `/swagger`
- Base path: `/api/v1/Categories`

Endpoints (resumen y ejemplos)
-----------------------------
1) GET /api/v1/Categories
- Devuelve todas las categorías.

Ejemplo:
```bash
curl -s http://localhost:8080/api/v1/Categories
```

2) GET /api/v1/Categories/ByName/{TypeCategory}
- Búsqueda case-insensitive por `TypeCategory`.

Ejemplo:
```bash
curl -s http://localhost:8080/api/v1/Categories/ByName/elect
```

3) POST /api/v1/Categories
- Crea una categoría.

Body ejemplo:
```json
{ "IdCategory": 0, "TypeCategory": "Electronics" }
```

4) PUT /api/v1/Categories/{id}
- Actualiza `TypeCategory` de la categoría indicada.

5) DELETE /api/v1/Categories/{id}
- Elimina por id.

6) DELETE /api/v1/Categories/ByName/{TypeCategory}
- Elimina la primera coincidencia por nombre.

Modelos (esencial)
-------------------
- `CategoriesEntity` (infrastructure)
    - `int IdCategory` (PK)
    - `string? TypeCategory`

- `AdapterCategoriesEntity` (API DTO)
    - `int IdCategory`
    - `string? TypeCategory`

- `DomainCategoriesEntity` (dominio)
    - `int IdCategoriy`  (nota: existe una tipografía en el nombre de la propiedad dentro del modelo de dominio)
    - `string? TypeCategory`

Notas clave
-----------
- La cadena de conexión por defecto aparece en `appsettings*.json`; puedes sobrescribirla mediante `ConnectionStrings__DefaultConnection`.
- Swagger está disponible en entorno de desarrollo para probar las rutas y ver contratos.
- El proyecto está encaminado a integrarse como microservicio en arquitecturas más grandes (API gateway, orquestador, CI/CD).

Licencia y contacto
-------------------
No se incluye licencia en el repositorio. Si vas a publicarlo, añade una licencia (por ejemplo MIT). Para cambios concretos en el código (p. ej. corregir la tipografía en el modelo de dominio o añadir pruebas), indícame la tarea y la implemento.

License
-------
Este proyecto se publica bajo la licencia MIT. Consulta el archivo `LICENSE` en la raíz del repositorio para el texto completo.
