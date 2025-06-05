using Entidades.Generales;
using Entidades.DTO.CurriculumVite;
using Entidades.Modelos.CurriculumVite;

namespace Servicios.IRepositorios.CurriculumVite
{
    public interface ISDocenteRepositorio
    {
        Task<ResultadoAcciones> InsertarDocente(DocenteDTO docenteDTO);
        Task<ResultadoAcciones> BorrarDocente(int idDocente);
        Task<ResultadoAcciones> ModificarDocente(DocenteDTO docenteDTO);
        Task<ResultadoAcciones<T>> ObtenerDocente<T>(int idDocente) where T : class;
        Task<IEnumerable<E_Docente>> ListarDocentes();
        Task<IEnumerable<E_Docente>> ListarDocentes(string criterioBusqueda);
    }
} 