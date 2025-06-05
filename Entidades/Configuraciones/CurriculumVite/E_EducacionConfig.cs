using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Entidades.Modelos.CurriculumVite;

namespace Entidades.Configuraciones.CurriculumVite
{
    public class E_EducacionConfig : IEntityTypeConfiguration<E_Educacion>
    {
        public void Configure(EntityTypeBuilder<E_Educacion> builder)
        {
            builder.ToTable("Educacion", "CV");
            builder.HasKey(e => e.IdEducacion);
            builder.Property(e => e.IdDocente).IsRequired();
            builder.Property(e => e.Nivel).HasMaxLength(50).IsRequired();
            builder.Property(e => e.Titulo).HasMaxLength(200);
            builder.Property(e => e.Institucion).HasMaxLength(200);
            builder.Property(e => e.Especialidad).HasMaxLength(200);
            builder.Property(e => e.Pais).HasMaxLength(100);
            builder.Property(e => e.AnioInicio);
            builder.Property(e => e.AnioFin);
            
            // Configurar la relación con E_Docente
            builder.HasOne<E_Docente>()
                .WithMany(d => d.Educaciones)
                .HasForeignKey(edu => edu.IdDocente)
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
