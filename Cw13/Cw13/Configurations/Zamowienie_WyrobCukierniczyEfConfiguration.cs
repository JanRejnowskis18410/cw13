using Cw13.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Cw13.Configurations
{
    public class Zamowienie_WyrobCukierniczyEfConfiguration : IEntityTypeConfiguration<Zamowienie_WyrobCukierniczy>
    {
        public void Configure(EntityTypeBuilder<Zamowienie_WyrobCukierniczy> builder)
        {
            builder.Property(zwc => zwc.Uwagi)
                   .HasMaxLength(300);

            builder.Property(zwc => zwc.Ilosc)
                   .IsRequired();

            builder.HasKey(zwc => new { zwc.IdZamowienia, zwc.IdWyrobuCukierniczego });

            builder.HasOne(zwc => zwc.Zamowienie)
                   .WithMany(z => z.Zamowienia_WyrobyCukiernicze)
                   .HasForeignKey(zwc => zwc.IdZamowienia);

            builder.HasOne(zwc => zwc.WyrobCukierniczy)
                   .WithMany(wc => wc.Zamowienia_WyrobyCukiernicze)
                   .HasForeignKey(zwc => zwc.IdWyrobuCukierniczego);
        }
    }
}
