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
            builder.Property(t => t.Name)
                .HasMaxLength(100)
                .IsRequired();

            builder.HasMany(p => p.Tournaments)
                   .WithMany(t => t.Players)
                   .UsingEntity<PlayerTournament>(
                   p => p
                       .HasOne<Tournament>()
                       .WithMany()
                       .HasForeignKey("TournamentId")
                       .HasConstraintName("FK_PlayersTournaments_Tournaments_TournamentId")
                       .OnDelete(DeleteBehavior.ClientCascade),
                    t => t
                       .HasOne<Player>()
                       .WithMany()
                       .HasForeignKey("PlayerId")
                       .HasConstraintName("FK_PlayersTournaments_Players_PlayerId")
                       .OnDelete(DeleteBehavior.Cascade));
        }
    }
}
