using Microsoft.EntityFrameworkCore;
using Vehiculo20200288.Data.Models;

namespace Vehiculo20200288.Data.Context;

public interface IVEHICULO20200288DbContext
{
  DbSet<Vehiculo> Vehiculos { get; }

    Task<int> SaveChangesAsync(CancellationToken cancellationToken = default);
}