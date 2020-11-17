using Leilao.Entities;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace Leilao.Repositories.Configuration
{
    public class UsuarioConfiguration : IEntityTypeConfiguration<Usuario>
    {
        public void Configure(EntityTypeBuilder<Usuario> builder)
        {
            builder.HasKey(o => o.UsuarioID);

            builder.Property(o => o.UsuarioID)
                    .ValueGeneratedOnAdd();

            builder.Property(o => o.Username)
                    .IsRequired()
                    .HasMaxLength(50);

            builder.HasIndex(o => o.Username).IsUnique();

            builder.Property(t => t.Password)
                    .IsRequired()
                    .HasMaxLength(100);

            builder.Property(o => o.CreatedAt);
            builder.Property(o => o.CreatedBy).HasMaxLength(50);
            builder.Property(o => o.UpdatedAt);
            builder.Property(o => o.UpdatedBy).HasMaxLength(50);
        }
    }
}
