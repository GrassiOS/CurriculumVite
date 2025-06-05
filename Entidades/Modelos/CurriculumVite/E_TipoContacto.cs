using System.ComponentModel.DataAnnotations;

namespace Entidades.Modelos.CurriculumVite
{
    public class E_TipoContacto
    {
        public int TipoContactoId { get; set; }
        
        [Required]
        [StringLength(200)]
        public string Nombre { get; set; } = string.Empty;
        
        // Navigation properties
        public ICollection<E_ContactoProfesor>? ContactosProfesores { get; set; }
    }
}
