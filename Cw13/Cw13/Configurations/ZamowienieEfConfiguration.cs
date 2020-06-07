using Cw13.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Cw13.Configurations
{
    public class ZamowienieEfConfiguration : IEntityTypeConfiguration<Zamowienie>
    {
        public void Configure(EntityTypeBuilder<Zamowienie> builder)
        {
            builder.HasKey(z => z.IdZamowienia);

            builder.Property(z => z.DataPrzyjecia)
                   .IsRequired();

            builder.Property(z => z.DataRealizacji);

            builder.Property(z => z.Uwagi)
                   .HasMaxLength(300);
        }
    }
}
