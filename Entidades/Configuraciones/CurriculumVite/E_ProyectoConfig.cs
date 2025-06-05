using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Entidades.Modelos.CurriculumVite;

namespace Entidades.Configuraciones.CurriculumVite
{
    public class E_ProyectoConfig : IEntityTypeConfiguration<E_Proyecto>
    {
        public void Configure(EntityTypeBuilder<E_Proyecto> builder)
        {
            builder.ToTable("Proyecto", "CV");
            builder.HasKey(e => e.IdProyecto);
            builder.Property(e => e.IdDocente).IsRequired();
            builder.Property(e => e.Titulo).HasMaxLength(255);
            builder.Property(e => e.Rol).HasMaxLength(100);
            builder.Property(e => e.Institucion).HasMaxLength(200);
            builder.Property(e => e.Financiamiento).HasMaxLength(200);
            builder.Property(e => e.PeriodoInicio);
            builder.Property(e => e.PeriodoFin).IsRequired();
            
            // Configurar la relación con E_Docente
            builder.HasOne<E_Docente>()
                .WithMany(d => d.Proyectos)
                .HasForeignKey(p => p.IdDocente)
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
