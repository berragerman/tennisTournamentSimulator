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
    public class PlayerConfiguration : IEntityTypeConfiguration<Player>
    {
        public void Configure(EntityTypeBuilder<Player> builder)
        {
            builder.HasKey(t => t.Id);

            builder.Property(t => t.Name)
                .HasMaxLength(100)
                .IsRequired();

            builder
            .HasMany(t => t.Tournaments)
            .WithMany(p => p.Players)
            .UsingEntity<PlayerTournament>(
                j => j
                    .HasOne(pt => pt.Tournament)
                    .WithMany(p => p.PlayerTournaments)
                    .HasForeignKey(pt => pt.TournamentId)
                    .OnDelete(DeleteBehavior.NoAction),
                j => j
                    .HasOne(pt => pt.Player)
                    .WithMany(t => t.PlayerTournaments)
                    .HasForeignKey(pt => pt.PlayerId)
                    .OnDelete(DeleteBehavior.NoAction),
                j =>
                {
                    j.Property(pt => pt.Created).HasDefaultValueSql("CURRENT_TIMESTAMP");
                    j.HasKey(t => new { t.PlayerId, t.TournamentId });
                });
        }
    }
}
