using System.Collections.Generic;
using System.Threading.Tasks;
using Entidades.Modelos.CurriculumVite;
using Servicios.IRepositorios.CurriculumVite;
using Datos.IRepositorios.CurriculumVite;   
using System.Text.Json;
using Microsoft.EntityFrameworkCore;
using Datos;

namespace Servicios.Repositorios.CurriculumVite
{
    public class DocumentoServicios : ISRepositorioDocumento
    {
        private readonly IRepositorioDocumento _repo;
        private readonly ContextoBD _context;

        public DocumentoServicios(IRepositorioDocumento repo, ContextoBD context)
        {
            _repo = repo;
            _context = context;
        }

        public async Task<IEnumerable<E_Documento>> GetAllAsync()
        {
            return await _repo.GetAllAsync();
        }

        public async Task<E_Documento> GetByIdAsync(int id)
        {
            return await _repo.GetByIdAsync(id);
        }

        public async Task AddAsync(E_Documento entity)
        {
            await _repo.AddAsync(entity);
        }

        public async Task UpdateAsync(E_Documento entity)
        {
            await _repo.UpdateAsync(entity);
        }

        public async Task DeleteAsync(int id)
        {
            await _repo.DeleteAsync(id);
        }

        public async Task<IEnumerable<E_Documento>> GetDocumentosByPublicacionAsync(int idPublicacion)
        {
            return await _repo.GetDocumentosByPublicacionAsync(idPublicacion);
        }

        public async Task<E_Documento> CreateDocumentoForPublicacionAsync(int idDocente, int idPublicacion, string titulo, string url, string descripcion)
        {
            try
            {
                // Validar que las foreign keys existan
                Console.WriteLine($"🇲🇽 Validando foreign keys antes de crear documento...");
                
                // Verificar que IdDocente existe en CEF.Docentes
                var docenteExists = await _context.Docentes.AnyAsync(d => d.IdDocente == idDocente);
                if (!docenteExists)
                {
                    throw new InvalidOperationException($"🇲🇽 ERROR: El docente con ID {idDocente} no existe en la base de datos");
                }
                Console.WriteLine($"🇲🇽 ✓ Docente con ID {idDocente} existe");
                
                // Verificar que IdPublicacion existe en CV.Publicaciones
                var publicacionExists = await _context.Publicaciones.AnyAsync(p => p.IdPublicacion == idPublicacion);
                if (!publicacionExists)
                {
                    throw new InvalidOperationException($"🇲🇽 ERROR: La publicación con ID {idPublicacion} no existe en la base de datos");
                }
                Console.WriteLine($"🇲🇽 ✓ Publicación con ID {idPublicacion} existe");
                
                var documento = new E_Documento
                {
                    IdDocente = idDocente,
                    IdPublicacion = idPublicacion,
                    Titulo = titulo,
                    Url = url,
                    Descripcion = descripcion,
                    FechaSubida = DateTime.Now
                };

                Console.WriteLine($"🇲🇽 Intentando guardar documento: IdDocente={idDocente}, IdPublicacion={idPublicacion}");
                Console.WriteLine("🇲🇽 JSON del documento:");
                Console.WriteLine(JsonSerializer.Serialize(documento, new JsonSerializerOptions { WriteIndented = true }));
                
                await _repo.AddAsync(documento);
                
                Console.WriteLine($"🇲🇽 ✓ Documento guardado correctamente con ID: {documento.IdDocumento}");
                return documento;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"🇲🇽 ❌ ERROR en DocumentoServicios.CreateDocumentoForPublicacionAsync:");
                Console.WriteLine($"🇲🇽 Mensaje: {ex.Message}");
                Console.WriteLine($"🇲🇽 InnerException: {ex.InnerException?.Message}");
                Console.WriteLine($"🇲🇽 StackTrace: {ex.StackTrace}");
                throw;
            }
        }
    }
}
