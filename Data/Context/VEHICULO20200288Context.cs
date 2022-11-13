using Vehiculo20200288.Data.Models;
using Microsoft.EntityFrameworkCore;

namespace Vehiculo20200288.Data.Context;

    public class VEHICULO20200288DbContext:DbContext,IVEHICULO20200288DbContext
    {
        public VEHICULO20200288DbContext(DbContextOptions options):base(options)
    {
        
    }
        public virtual DbSet<Vehiculo> Vehiculos { get; set; } = null!;
        public override int SaveChanges()
    {
        return base.SaveChanges();
    }
    public override Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
    {
        return base.SaveChangesAsync(cancellationToken);
    }
    }

public interface IVEHICULO20200288DbContext
{
   public DbSet<Vehiculo> Vehiculos { get; set; }
   public int SaveChanges();
   public Task<int> SaveChangesAsync(CancellationToken cancellationToken = default);
}