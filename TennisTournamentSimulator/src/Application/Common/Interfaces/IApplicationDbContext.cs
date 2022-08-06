using Microsoft.EntityFrameworkCore;

namespace Application.Common.Interfaces
{
    public interface IApplicationDbContext
    {
        DbSet<Domain.Entities.Player> Players { get; set; }

        DbSet<Domain.Entities.Tournament> Tournaments { get; set; }

        Task<int> SaveChangesAsync(CancellationToken cancellationToken);

    }
}
