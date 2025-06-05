using AutoMapper;
using Entidades.Generales;
using Entidades.DTO.CurriculumVite;
using Entidades.Modelos.CurriculumVite;
using Negocios.Repositorios.CurriculumVite;
using Servicios.IRepositorios.CurriculumVite;

namespace Servicios.Repositorios.CurriculumVite
{
    public class DocenteServicios(DocenteNegocios docenteNegocios, IMapper mapper) : ISDocenteRepositorio
    {
        private readonly DocenteNegocios _docenteNegocios = docenteNegocios;
        private readonly IMapper _mapper = mapper;

        public async Task<ResultadoAcciones> InsertarDocente(DocenteDTO docenteDTO)
        {
            E_Docente docente = _mapper.Map<E_Docente>(docenteDTO);
            return await _docenteNegocios.InsertarDocente(docente);
        }

        public async Task<ResultadoAcciones> BorrarDocente(int idDocente)
        {
            if (idDocente <= 0)
                return new ResultadoAcciones
                {
                    Mensajes = { "El identificador del docente no es válido." },
                    Resultado = false
                };

            return await _docenteNegocios.BorrarDocente(idDocente);
        }

        public async Task<ResultadoAcciones> ModificarDocente(DocenteDTO docenteDTO)
        {
            E_Docente docente = _mapper.Map<E_Docente>(docenteDTO);
            return await _docenteNegocios.ModificarDocente(docente);
        }

        public async Task<ResultadoAcciones<T>> ObtenerDocente<T>(int idDocente) where T : class
        {
            try
            {
                var docente = await _docenteNegocios.ObtenerDocente(idDocente);

                if (!docente.Resultado || docente.Entidad == null)
                {
                    return new ResultadoAcciones<T>
                    {
                        Resultado = false,
                        Mensajes = docente.Mensajes,
                    };
                }

                // Mapear la entidad al DTO
                var dtoMapeado = _mapper.Map<T>(docente.Entidad);

                return new ResultadoAcciones<T>
                {
                    Mensajes = docente.Mensajes,
                    Entidad = dtoMapeado,
                    Resultado = true
                };
            }
            catch (Exception ex)
            {
                return new ResultadoAcciones<T>
                {
                    Mensajes = ["Error inesperado al procesar la solicitud. " + ex.Message],
                    Resultado = false
                };
            }
        }

        public async Task<IEnumerable<E_Docente>> ListarDocentes()
        {
            return await _docenteNegocios.ListarDocentes();
        }

        public async Task<IEnumerable<E_Docente>> ListarDocentes(string criterioBusqueda)
        {
            return await _docenteNegocios.ListarDocentes(criterioBusqueda);
        }
    }
} 