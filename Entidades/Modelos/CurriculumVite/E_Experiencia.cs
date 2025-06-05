using System;

namespace Entidades.Modelos.CurriculumVite
{
    public class E_Experiencia
    {
        public int IdExperiencia { get; set; }
        public int IdDocente { get; set; }
        public string? Puesto { get; set; }
        public string? Institucion { get; set; }
        public string? Descripcion { get; set; }
        public DateTime? FechaInicio { get; set; }
        public DateTime? FechaFin { get; set; }
        
        // Navigation property
        public virtual E_Docente? Docente { get; set; }
    }
}
