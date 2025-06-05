namespace Entidades.DTO.CurriculumVite
{
    public class PublicacionDTO
    {
        public int IdPublicacion { get; set; }
        public int IdDocente { get; set; }
        public string? Titulo { get; set; }
        public string? TipoPublicacion { get; set; }
        public string? Autores { get; set; }
        public string? Fuente { get; set; }
        public int? Anio { get; set; }
        public string? Enlace { get; set; }
        
        // Propiedades calculadas
        public string NombreDocente { get; set; } = null!;
        public bool TieneEnlace => !string.IsNullOrEmpty(Enlace);
        public string TituloCorto => Titulo?.Length > 100 ? Titulo[..97] + "..." : Titulo ?? "";
        public List<string> ListaAutores => 
            string.IsNullOrEmpty(Autores) ? new List<string>() : 
            Autores.Split(',').Select(a => a.Trim()).ToList();
        public int CantidadAutores => ListaAutores.Count;
        public string AutoresFormateados => 
            CantidadAutores > 3 ? 
                string.Join(", ", ListaAutores.Take(3)) + " et al." : 
                Autores ?? "";
    }
}
