using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Persistence.Configurations
{
    internal class TournamentConfiguration : IEntityTypeConfiguration<Tournament>
    {
        public void Configure(EntityTypeBuilder<Tournament> builder)
        {
            builder.HasKey(t => t.Id);

            builder.HasOne(t => t.Winner)
                    .WithMany()
                    .HasForeignKey(t => t.Id)
                    .OnDelete(DeleteBehavior.NoAction);

            builder.Property(t => t.Name)
                .HasMaxLength(100)
                .IsRequired();

           
        }
    }
}
