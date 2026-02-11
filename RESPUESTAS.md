# RESPUESTAS.md - Proceso de Desarrollo y Validación

Para este ejercicio de Lenox, utilicé herramientas de IA de forma táctica para generar esqueletos de DTOs y agilizar el boilerplate, enfocando mi criterio técnico en la optimización de consultas y la estabilidad del sistema.

## 1. Prompts Principales
- "Generar estructura de respuesta paginada en C# siguiendo el formato: page, pageSize, total, items."
- "Estructura de proyección LINQ para obtener el último registro de una relación uno-a-muchos en EF Core."

## 2. Decisiones y Ajustes de Arquitectura
- **Proyección vs. Inclusión:** Decidí no utilizar `.Include()`, ya que Lenox solicita "traer solo los campos necesarios". Implementé un mapeo manual en el `.Select()` para generar un JOIN eficiente en SQL, evitando el over-fetching de datos.
- **Paginación Robusta:** Aseguré la paginación mediante un doble ordenamiento (`Nombre ASC`, `Id ASC`). Esto garantiza que, si dos empleados de Lenox tienen el mismo nombre, el resultado sea predecible y no se repitan items entre páginas.
- **Filtros de Búsqueda:** Implementé la búsqueda con normalización básica (`ToLower()`) y limpieza de strings para que la experiencia de búsqueda de RRHH sea más flexible.

## 3. Validación de Resultados de IA
- **Corrección de Excepciones:** La IA sugirió inicialmente usar `.Max(m => m.Fecha)`. Corregí este enfoque hacia `.FirstOrDefault()`, ya que en EF Core `.Max()` falla si un empleado no tiene movimientos registrados, mientras que mi solución maneja el valor nulo correctamente.
- **Ejecución del lado del Servidor:** Ajusté la lógica para asegurar que el filtrado por nombre/email ocurra dentro del `IQueryable`. Esto garantiza que el motor de base de datos procese la búsqueda y no se traigan todos los registros de la empresa a la memoria del servidor.
