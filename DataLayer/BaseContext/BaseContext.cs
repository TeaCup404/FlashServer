using FlashServer.DataLayer.BaseDataModels;
using Microsoft.EntityFrameworkCore;

namespace FlashServer.DataLayer.BaseContext
{
    public class BaseContext<context> : DbContext where context : DbContext
    {
        public BaseContext(DbContextOptions<context> options) : base(options) {}

        public override int SaveChanges()
        {
            var entries = ChangeTracker.Entries()
                .Where(e => e.Entity is BaseEntity && (e.State == EntityState.Added || e.State == EntityState.Modified)); 

            foreach (var entityEntry in entries)
            {
                ((BaseEntity)entityEntry.Entity).updatedDate = DateTime.Now;

                if(entityEntry.State == EntityState.Added)
                {
                    ((BaseEntity)entityEntry.Entity).updatedDate = DateTime.Now;
                }
            }

            return base.SaveChanges();
        }
    }
}