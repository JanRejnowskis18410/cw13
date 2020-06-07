using Cw13.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Cw13.Configurations
{
    public class KlientEfConfiguration : IEntityTypeConfiguration<Klient>
    {
        public void Configure(EntityTypeBuilder<Klient> builder)
        {
            builder.HasKey(k => k.IdKlient);

            builder.Property(k => k.Imie)
                   .HasMaxLength(50)
                   .IsRequired();

            builder.Property(k => k.Nazwisko)
                   .HasMaxLength(60)
                   .IsRequired();

            builder.HasMany(k => k.Zamowienia)
                   .WithOne(z => z.Klient)
                   .HasForeignKey(z => z.IdKlient);
        }
    }
}
