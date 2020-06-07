using Cw13.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Cw13.Configurations
{
    public class PracownikEfConfiguration : IEntityTypeConfiguration<Pracownik>
    {
        public void Configure(EntityTypeBuilder<Pracownik> builder)
        {
            builder.HasKey(p => p.IdPracownik);

            builder.Property(b => b.Imie)
                   .HasMaxLength(50)
                   .IsRequired();

            builder.Property(b => b.Nazwisko)
                   .HasMaxLength(60)
                   .IsRequired();

            builder.HasMany(p => p.Zamowienia)
                   .WithOne(z => z.Pracownik)
                   .HasForeignKey(z => z.IdPracownik);
        }
    }
}
