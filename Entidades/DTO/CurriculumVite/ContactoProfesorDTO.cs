using System.ComponentModel.DataAnnotations;

namespace Entidades.DTO.CurriculumVite
{
    public class ContactoProfesorDTO
    {
        public int IdContacto { get; set; }
        public int IdDocente { get; set; }
        
        [Required(ErrorMessage = "El tipo de contacto es requerido")]
        public int IdTpoContacto { get; set; }
        
        [Required(ErrorMessage = "La URL es requerida")]
        [StringLength(500, ErrorMessage = "La URL no puede exceder 500 caracteres")]
        [Url(ErrorMessage = "Debe ser una URL válida")]
        public string Url { get; set; } = string.Empty;
        
        // Propiedades adicionales para la vista
        public string? TipoContactoNombre { get; set; }
        public string? NombreDocente { get; set; }
    }
} 