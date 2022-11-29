using Vehiculo20200288.Data.Models;
using Microsoft.EntityFrameworkCore;

namespace Vehiculo20200288.Data.Context;

//Hereda MyDbContext en DbContext de la siguiente forma MyDbContext:DbContext
public class VEHICULO20200288DbContext:DbContext,IVEHICULO20200288DbContext
{

     #region Constructor
    public VEHICULO20200288DbContext(DbContextOptions options) : base(options)
    {

    }
    #endregion
    #region Tablas
    public DbSet<Vehiculo> Vehiculos => Set<Vehiculo>();
    #endregion
    #region Funciones
    public override Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
    {
        return base.SaveChangesAsync(cancellationToken);
    }
    #endregion
}