using Microsoft.EntityFrameworkCore;
using Vehiculo20200288.Data.Context;
using Vehiculo20200288.Data.Models;
using Vehiculo20200288.Request;
using Vehiculo20200288.Response;


namespace Vehiculo20200288.Data.Services;

public interface IVehiculoService
{
    Task<Result<List<VehiculoRecord>>> Consultar(string filtro);
    Task<Result<int>> Registrar(VehiculoRequest datos);
    public Task Eliminar(int Id);
    public Task Editar(int Id, string marca, string modelo, string color, int año);
}

public class VehiculoService : IVehiculoService
{
    private VEHICULO20200288DbContext _database;
    public VehiculoService(VEHICULO20200288DbContext database)
    {
        _database = database;
    }
    //Tarea para registrar un Vehiculo nuevo en la base de datos...
    public async Task<Result<int>> Registrar(VehiculoRequest datos)
    {
        try
        {
            var vehiculo = Vehiculo.Crear(datos);

            _database.Vehiculos.Add(vehiculo);
            await _database.SaveChangesAsync(new());

            return Result<int>.Success(vehiculo.VehiculoID);
        }
        catch (Exception E)
        {
            return Result<int>.Fail(E.Message);
        }
    }
    //Tarea para consultar los vehiculos en la base de datos...
    public async Task<Result<List<VehiculoRecord>>> Consultar(string filtro)
    {
        try
        {
            //Se consulta en la base de datos segun el nombre del Vehiculo y el telefono.
            var vehiculosDB =
            await _database.Vehiculos.Where(vehiculo =>
                (!string.IsNullOrEmpty(filtro) && (vehiculo.Marca.ToLower().Contains(filtro.ToLower())) || vehiculo.Modelo.Contains(filtro))
            )
            .ToListAsync(new());
            //Se convierten los datos para poder devolverlos.
            var vehiculosMapeados = vehiculosDB.Select(c => new VehiculoRecord() { 
                VehiculoID = c.VehiculoID, 
                Marca = c.Marca, 
                Modelo = c.Modelo,
                Color = c.Color,
                Año = c.Año
                })
                .ToList();
            //Se devuelven los datos convertidos al tipo de dato esperado.
            return Result<List<VehiculoRecord>>.Success(vehiculosMapeados);
        }
        catch (Exception E)
        {
            return Result<List<VehiculoRecord>>.Fail(E.Message);
        }
    }
    public async Task Eliminar(int Id)
    {
        var vehiculo = await _database.Vehiculos.FirstOrDefaultAsync(v=>v.VehiculoID == Id);
        if(vehiculo!=null)
        {
        _database.Vehiculos.Remove(vehiculo);
        await _database.SaveChangesAsync();
        }
    }
     public async Task Editar(int Id, string marca, string modelo, string color, int año)
    {
        var vehiculo = await _database.Vehiculos.FirstOrDefaultAsync(v=>v.VehiculoID == Id);
        if(vehiculo!=null)
        {
        vehiculo.Update(marca,modelo,color,año);
        await _database.SaveChangesAsync();
        }
    }
}