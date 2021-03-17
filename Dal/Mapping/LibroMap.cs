using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Datos
{
    public class libroMap : IEntityTypeConfiguration<Libro>
    {
        public void Configure(EntityTypeBuilder<Libro> builder)
        {
            builder.ToTable("Libro", schema: "Nexos")
              .HasKey(c => c.id_Libro);

            builder.HasOne(p => p.Autor)
            .WithMany(b => b.Libro)
             .HasForeignKey(i => i.id_autor);

            builder.HasOne(p => p.Editorial)
            .WithMany(b => b.Libro)
             .HasForeignKey(i => i.id_editorial);

        }

    }

}
