using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Entidades.Modelos.CurriculumVite;

namespace Entidades.Configuraciones.CurriculumVite
{
    public class E_ContactoProfesorConfig : IEntityTypeConfiguration<E_ContactoProfesor>
    {
        public void Configure(EntityTypeBuilder<E_ContactoProfesor> builder)
        {
            builder.ToTable("ContactoProfesor", "CV");
            builder.HasKey(e => e.IdContacto);
            
            // Propiedades requeridas
            builder.Property(e => e.IdDocente).IsRequired();
            builder.Property(e => e.IdTpoContacto).IsRequired();
            builder.Property(e => e.Url).IsRequired().HasMaxLength(500);
            
            // Relaciones
            builder.HasOne(e => e.Docente)
                .WithMany()
                .HasForeignKey(e => e.IdDocente)
                .OnDelete(DeleteBehavior.Cascade);
                
            builder.HasOne(e => e.TipoContacto)
                .WithMany(t => t.ContactosProfesores)
                .HasForeignKey(e => e.IdTpoContacto)
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
} 