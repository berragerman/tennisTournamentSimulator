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
    public class PlayerTournamentConfiguration : IEntityTypeConfiguration<Domain.Entities.PlayerTournament>
    {
        public void Configure(EntityTypeBuilder<PlayerTournament> builder)
        {
            builder.HasKey(pt => pt.Id);

            builder.HasOne(pt => pt.Player) 
                    .WithMany(p => p.PlayerTournaments)
                    .HasForeignKey(pt => pt.PlayerId)
                    .OnDelete(DeleteBehavior.NoAction);

            builder.HasOne(pt => pt.Tournament)
                    .WithMany(p => p.PlayerTournaments)
                    .HasForeignKey(pt => pt.TournamentId)
                    .OnDelete(DeleteBehavior.NoAction);
        }
    }
}
