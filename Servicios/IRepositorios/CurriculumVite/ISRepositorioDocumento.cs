using System.Collections.Generic;
using System.Threading.Tasks;
using Entidades.Modelos.CurriculumVite;

namespace Servicios.IRepositorios.CurriculumVite
{
    public interface ISRepositorioDocumento
    {
        Task<IEnumerable<E_Documento>> GetAllAsync();
        Task<E_Documento> GetByIdAsync(int id);
        Task AddAsync(E_Documento entity);
        Task UpdateAsync(E_Documento entity);
        Task DeleteAsync(int id);
    }
}
