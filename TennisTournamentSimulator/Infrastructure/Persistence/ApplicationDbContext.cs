﻿using Application.Common.Interfaces;
using Domain.Common;
using Domain.Entities;
using Infrastructure.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Persistence
{
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>, IApplicationDbContext
    {
        private readonly ICurrentUserService _currentUser;
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options, ICurrentUserService currentUserService)
            : base(options)
        {
            _currentUser = currentUserService;
        }

        public DbSet<Player>? Players { get; set; }



        public override Task<int> SaveChangesAsync(CancellationToken cancellationToken = new CancellationToken())
        {
            var now = DateTime.Now;

            foreach (var entry in ChangeTracker.Entries<AuditableEntity>())
            {
                switch (entry.State)
                {
                    case EntityState.Added:
                        entry.Entity.Created = now;
                        break;

                    case EntityState.Modified:
                        entry.Entity.Updated = now;
                        break;

                    case EntityState.Deleted:
                        entry.Entity.Inactive = true;
                        entry.Entity.Updated = now;
                        break;
                }
            }

            return base.SaveChangesAsync(cancellationToken);
        }
    }
}
