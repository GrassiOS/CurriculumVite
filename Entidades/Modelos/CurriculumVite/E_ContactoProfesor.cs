using System.ComponentModel.DataAnnotations;

namespace Entidades.Modelos.CurriculumVite
{
    public class E_ContactoProfesor
    {
        public int IdContacto { get; set; }
        public int IdDocente { get; set; }
        public int IdTpoContacto { get; set; }
        
        [Required]
        [StringLength(500)]
        public string Url { get; set; } = string.Empty;
        
        // Navigation properties
        public E_Docente? Docente { get; set; }
        public E_TipoContacto? TipoContacto { get; set; }
    }
} 