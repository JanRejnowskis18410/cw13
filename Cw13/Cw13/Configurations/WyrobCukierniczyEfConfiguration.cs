using Cw13.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Cw13.Configurations
{
    public class WyrobCukierniczyEfConfiguration : IEntityTypeConfiguration<WyrobCukierniczy>
    {
        public void Configure(EntityTypeBuilder<WyrobCukierniczy> builder)
        {
            builder.HasKey(wc => wc.IdWyrobuCukierniczego);

            builder.Property(wc => wc.Nazwa)
                   .HasMaxLength(200)
                   .IsRequired();

            builder.Property(wc => wc.CenaZaSzt)
                   .IsRequired();

            builder.Property(wc => wc.Typ)
                   .HasMaxLength(40)
                   .IsRequired();
        }
    }
}
