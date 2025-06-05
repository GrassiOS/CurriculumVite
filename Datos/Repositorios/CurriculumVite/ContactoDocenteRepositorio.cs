using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Entidades.Modelos.CurriculumVite;
using Datos.IRepositorios.CurriculumVite;

namespace Datos.Repositorios.CurriculumVite
{
    public class ContactoDocenteRepositorio : IRepositorioContactoDocente
    {
        private readonly ContextoBD _context;

        public ContactoDocenteRepositorio(ContextoBD context)
        {
            _context = context;
        }

        public async Task<IEnumerable<E_ContactoDocente>> GetAllAsync()
        {
            return await _context.ContactoDocentes
                .Include(c => c.TipoContacto)
                .Include(c => c.Docente)
                .ToListAsync();
        }

        public async Task<E_ContactoDocente> GetByIdAsync(int id)
        {
            return await _context.ContactoDocentes
                .Include(c => c.TipoContacto)
                .Include(c => c.Docente)
                .FirstOrDefaultAsync(c => c.IdContacto == id);
        }

        public async Task AddAsync(E_ContactoDocente entity)
        {
            await _context.ContactoDocentes.AddAsync(entity);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateAsync(E_ContactoDocente entity)
        {
            _context.ContactoDocentes.Update(entity);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
            var entity = await _context.ContactoDocentes.FindAsync(id);
            if (entity != null)
            {
                _context.ContactoDocentes.Remove(entity);
                await _context.SaveChangesAsync();
            }
        }

        public async Task<IEnumerable<E_ContactoDocente>> GetContactosByDocenteIdAsync(int idDocente)
        {
            return await _context.ContactoDocentes
                .Include(c => c.TipoContacto)
                .Where(c => c.IdDocente == idDocente)
                .OrderBy(c => c.TipoContacto.Nombre)
                .ToListAsync();
        }

        public async Task<bool> ExisteContactoConTipoParaDocenteAsync(int idDocente, int idTipoContacto)
        {
            return await _context.ContactoDocentes
                .AnyAsync(c => c.IdDocente == idDocente && c.IdTpoContacto == idTipoContacto);
        }
    }
}
