# 📚 Gestor de Publicaciones - Flujo de Trabajo Integrado

## 🎯 Descripción General

El **Gestor de Publicaciones** está integrado en el flujo de trabajo de Curriculum Vitae de UABC. Forma parte del proceso secuencial de gestión de docentes después de la configuración de contactos.

## 🚀 Características Principales

### ✅ Gestión de Publicaciones
- **CRUD Completo**: Crear, leer, actualizar y eliminar publicaciones
- **Tipos de Publicación**: Artículos, libros, capítulos, memorias de congreso, tesis, reportes técnicos
- **Campos Completos**: Título, autores, fuente, año, enlace, tipo
- **Filtrado por Docente**: Solo muestra publicaciones del docente actual

### 📁 Subida de Documentos
- **Integración con Google Drive**: Subida automática de archivos PDF/DOC/DOCX
- **Organización Automática**: Carpetas por empleado y tipo de documento
- **Metadatos Completos**: URL, ID de archivo, ruta en Drive
- **Validación de Archivos**: Tamaño máximo 10MB, tipos permitidos

### 🎨 Interfaz de Usuario
- **Diseño UABC**: Colores institucionales (#2D6B3C, #4BB463, #F4BF3A)
- **Responsive**: Adaptable a móviles, tablets y desktop
- **Cards Animadas**: Efectos hover y transiciones suaves
- **Filtros Avanzados**: Por título, tipo, año, autores, fuente
- **Breadcrumbs**: Navegación contextual del flujo

## 🔧 Arquitectura Técnica

### 📂 Estructura de Capas (Ubicación Correcta)

```
Presentacion/Areas/CV/Docentes/
├── GestorPublicaciones.razor          # Página principal del gestor
├── DocumentosPublicacion.razor        # Vista de documentos por publicación
├── GestionContactos.razor            # Paso anterior en el flujo
└── GestionDocente.razor              # Vista principal de docente

Presentacion/Components/Shared/
└── ModalPublicacion.razor             # Modal reutilizable para crear/editar

Servicios/
├── IRepositorios/
│   ├── IDocumentRepository.cs         # Interface para subida de documentos
│   └── CurriculumVite/
│       ├── ISRepositorioPublicacion.cs
│       └── ISRepositorioDocumento.cs
└── Repositorios/
    ├── DocumentRepository.cs          # Servicio de subida a Google Drive
    └── CurriculumVite/
        ├── PublicacionServicios.cs
        └── DocumentoServicios.cs
```

### 🔗 Rutas del Sistema

```
/CV/Docentes/{idDocente}/Contactos                                    # Paso 1
/CV/Docentes/{idDocente}/Publicaciones                               # Paso 2 ✨
/CV/Docentes/{idDocente}/Publicaciones/{idPublicacion}/Documentos    # Vista detalle
/CV/Docentes/{idDocente}/Proyectos                                   # Paso 3 (futuro)
/CV/Docentes/{idDocente}/Distinciones                               # Paso 4 (futuro)
```

## 🎯 Flujo de Usuario Completo

### 1. **Flujo Secuencial de CV**
```
Docentes → Seleccionar Docente → Contactos → Publicaciones → Proyectos → Distinciones
```

### 2. **Gestión de Contactos (Paso 1)**
- Usuario completa información de contacto
- Hace clic en **"Continuar a Publicaciones"**
- Sistema navega automáticamente a `/CV/Docentes/{id}/Publicaciones`

### 3. **Gestión de Publicaciones (Paso 2)**
- **Dashboard contextual** con estadísticas del docente
- **Crear nueva publicación** con modal integrado
- **Subir documentos** durante la creación
- **Filtrar y buscar** publicaciones existentes
- **Ver/gestionar documentos** de cada publicación

### 4. **Navegación del Flujo**
- **Volver a Contactos**: Botón para retroceder
- **Continuar a Proyectos**: Siguiente paso (en desarrollo)
- **Breadcrumbs**: Navegación contextual completa

## 🗃️ Base de Datos

### Relaciones Establecidas
```sql
-- Publicaciones por docente
CV.Publicacion.IdDocente → CEF.Docentes.IdDocente

-- Documentos por publicación
CV.Documento.IdPublicacion → CV.Publicacion.IdPublicacion
CV.Documento.IdDocente → CEF.Docentes.IdDocente
```

## 🎨 Elementos de UI Mejorados

### Header Contextual
- **Breadcrumbs completos**: Docentes → [Nombre] → Contactos → Publicaciones
- **Información del docente**: Nombre completo siempre visible
- **Indicador de paso**: "Paso 2 de 4 - Publicaciones"

### Estadísticas Dashboard
- **Total de publicaciones** del docente
- **Publicaciones con enlace** 
- **Documentos de evidencia** totales

### Navegación Intuitiva
- **Botones de flujo**: Volver/Continuar con colores UABC
- **Estados claros**: Indicador visual del progreso
- **Navegación consistente**: Misma estructura en todos los pasos

## 🚦 Estados de la Aplicación

### Carga de Datos
- **Spinner UABC**: Colores institucionales
- **Datos del docente**: Carga automática por ID
- **Filtrado automático**: Solo publicaciones del docente actual

### Validaciones de Seguridad
- **Verificación de docente**: Solo puede ver/editar sus propias publicaciones
- **Validación de relaciones**: Documentos solo del docente correcto

## 🔄 Integración Completa

### Componentes Reutilizados
- **ModalPublicacion**: Usado desde `Components/Shared/`
- **DocumentRepository**: Servicio centralizado para todos los módulos
- **Servicios de Docente**: Integración completa con datos existentes

### Datos Contextuales
- **Información del docente**: Cargada automáticamente
- **Número de empleado**: Para subida de documentos
- **Filtrado automático**: Solo datos relevantes al docente

## 📋 Lista de Verificación

### ✅ Completado
- [x] Integración en flujo de trabajo secuencial
- [x] Ubicación correcta en `Areas/CV/Docentes/`
- [x] Navegación desde gestión de contactos
- [x] Botón "Continuar a Publicaciones" funcional
- [x] Breadcrumbs contextuales completos
- [x] Filtrado por docente automático
- [x] Datos del docente cargados dinámicamente
- [x] Modal de publicaciones integrado
- [x] Vista de documentos por publicación
- [x] Diseño consistente con otras páginas CV
- [x] Compilación exitosa

### 🔄 Para Futuras Mejoras
- [ ] Integración con gestor de proyectos
- [ ] Integración con gestor de distinciones
- [ ] Exportación completa del CV
- [ ] Vista previa del CV generado
- [ ] Drag & drop para reordenar publicaciones
- [ ] Integración con servicios bibliográficos

## 🎓 Notas Técnicas

### Parámetros de Ruta
- `{idDocente:int}`: ID del docente en todas las rutas
- `{idPublicacion:int}`: ID específico para documentos

### Servicios Inyectados
```csharp
ISRepositorioPublicacion PublicacionServicios
ISRepositorioDocumento DocumentoServicios  
ISDocenteRepositorio DocenteServicios
IDocumentRepository DocumentRepository (Modal)
```

### Navegación Programática
```csharp
// Desde contactos a publicaciones
Navigation.NavigateTo($"/CV/Docentes/{IdDocente}/Publicaciones");

// Desde publicaciones a documentos
Navigation.NavigateTo($"/CV/Docentes/{IdDocente}/Publicaciones/{idPublicacion}/Documentos");
```

---

**Implementado para UABC - Universidad Autónoma de Baja California**  
*Sistema de Gestión de Curriculum Vitae v2024*  
*Flujo de trabajo integrado y funcional* 