using Vehiculo20200288.Data.Models;
using Microsoft.EntityFrameworkCore;

namespace Vehiculo20200288.Data.Context;

    public class VEHICULO20200288DbContext:DbContext,IVEHICULO20200288DbContext
    {
        public virtual DbSet<Vehiculo> Vehiculos { get; set; } = null!;
    }

public interface IVEHICULO20200288DbContext
{
   public DbSet<Vehiculo> Vehiculos { get; set; }
}