using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Entidades.Modelos.CurriculumVite;
using Datos.IRepositorios.CurriculumVite;

namespace Datos.Repositorios.CurriculumVite
{
    public class DocumentoRepositorio : IRepositorioDocumento
    {
        private readonly ContextoBD _context;

        public DocumentoRepositorio(ContextoBD context)
        {
            _context = context;
        }

        public async Task<IEnumerable<E_Documento>> GetAllAsync()
        {
            return await _context.Documentos.ToListAsync();
        }

        public async Task<E_Documento> GetByIdAsync(int id)
        {
            return await _context.Documentos.FindAsync(id);
        }

        public async Task AddAsync(E_Documento entity)
        {
            try
            {
                Console.WriteLine($"🇲🇽 DocumentoRepositorio: Agregando entidad al contexto");
                Console.WriteLine($"🇲🇽 Entity: IdDocente={entity.IdDocente}, IdPublicacion={entity.IdPublicacion}");
                
                await _context.Documentos.AddAsync(entity);
                
                Console.WriteLine($"🇲🇽 DocumentoRepositorio: Llamando SaveChangesAsync...");
                await _context.SaveChangesAsync();
                
                Console.WriteLine($"🇲🇽 DocumentoRepositorio: SaveChanges completado. ID generado: {entity.IdDocumento}");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"🇲🇽 ERROR en DocumentoRepositorio.AddAsync:");
                Console.WriteLine($"🇲🇽 Exception Type: {ex.GetType().Name}");
                Console.WriteLine($"🇲🇽 Message: {ex.Message}");
                
                // Capturar inner exceptions
                var currentEx = ex;
                int level = 0;
                while (currentEx != null)
                {
                    Console.WriteLine($"🇲🇽 [Level {level}] {currentEx.GetType().Name}: {currentEx.Message}");
                    currentEx = currentEx.InnerException;
                    level++;
                }
                
                // Si es DbUpdateException, mostrar detalles específicos
                if (ex is Microsoft.EntityFrameworkCore.DbUpdateException dbEx)
                {
                    Console.WriteLine($"🇲🇽 DbUpdateException detalles:");
                    foreach (var entry in dbEx.Entries)
                    {
                        Console.WriteLine($"🇲🇽 Entry Type: {entry.Entity.GetType().Name}");
                        Console.WriteLine($"🇲🇽 Entry State: {entry.State}");
                    }
                }
                
                throw; // Re-lanzar para mantener el comportamiento original
            }
        }

        public async Task UpdateAsync(E_Documento entity)
        {
            _context.Documentos.Update(entity);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
            var entity = await _context.Documentos.FindAsync(id);
            if (entity != null)
            {
                _context.Documentos.Remove(entity);
                await _context.SaveChangesAsync();
            }
        }

        public async Task<IEnumerable<E_Documento>> GetDocumentosByPublicacionAsync(int idPublicacion)
        {
            return await _context.Documentos
                .Where(d => d.IdPublicacion == idPublicacion)
                .OrderByDescending(d => d.FechaSubida)
                .ToListAsync();
        }
    }
}
