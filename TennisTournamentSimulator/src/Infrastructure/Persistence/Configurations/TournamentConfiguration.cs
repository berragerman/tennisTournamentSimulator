﻿using Domain.Entities;
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
            builder.Property(t => t.Name)
                .HasMaxLength(100)
                .IsRequired();

            builder.HasMany(t => t.Players)
                    .WithMany(p => p.Tournaments)
                    .UsingEntity<PlayerTournament>(
                    t => t
                        .HasOne<Player>()
                        .WithMany()
                        .HasForeignKey("PlayerId")
                        .HasConstraintName("FK_PlayersTournaments_Players_PlayerId")
                        .OnDelete(DeleteBehavior.Cascade),
                    p => p
                        .HasOne<Tournament>()
                        .WithMany()
                        .HasForeignKey("TournamentId")
                        .HasConstraintName("FK_PlayersTournaments_Tournaments_TournamentId")
                        .OnDelete(DeleteBehavior.ClientCascade));
        }
    }
}
