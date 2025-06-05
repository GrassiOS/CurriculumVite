namespace Entidades.DTO.CurriculumVite
{
    public class ProyectoDTO
    {
        public int IdProyecto { get; set; }
        public int IdDocente { get; set; }
        public string? Titulo { get; set; }
        public string? Rol { get; set; }
        public string? Institucion { get; set; }
        public string? Financiamiento { get; set; }
        public int? PeriodoInicio { get; set; }
        public int PeriodoFin { get; set; }
        
        // Propiedades calculadas
        public string NombreDocente { get; set; } = null!;
        public string PeriodoFormateado => $"{PeriodoInicio ?? 0} - {PeriodoFin}";
        public bool EsActivo => PeriodoFin >= DateTime.Now.Year;
        public int DuracionAnios => PeriodoInicio.HasValue ? 
            PeriodoFin - PeriodoInicio.Value + 1 : 1;
        public string TituloCorto => Titulo?.Length > 80 ? Titulo[..77] + "..." : Titulo ?? "";
        public bool TieneFinanciamiento => !string.IsNullOrEmpty(Financiamiento);
        public string EstadoProyecto => EsActivo ? "En curso" : "Finalizado";
    }
}
