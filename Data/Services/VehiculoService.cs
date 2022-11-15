using Vehiculo20200288.Data.Context;
using Vehiculo20200288.Data.Models;
using Microsoft.EntityFrameworkCore;

namespace Vehiculo20200288.Data.Services;

public class VehiculoService:IVehiculoService
{
    private readonly VEHICULO20200288DbContext _context;

    public VehiculoService(VEHICULO20200288DbContext context)
    {
        _context = context;
    }

    public async Task<Result<int>> Crear(string marca, string modelo, int año, string color)
    {
        try
        {
            var vehiculo = Vehiculo.Crear(marca, modelo, año, color);
            _context.Vehiculos.Add(vehiculo);
            await _context.SaveChangesAsync();
            return Result<int>.Success(vehiculo.VehiculoID);
        }
        catch (Exception E)
        {
            return Result<int>.Failed(E.Message);
        }
    }
    public async Task<Result<List<Vehiculo>>> Consultar(string filtro = "")
    {
        try
        {
            
            var vehiculos = await _context.Vehiculos
            .Where(p=>p.Marca.Contains(filtro))
            .ToListAsync();
            
            return Result<List<Vehiculo>>.Success(vehiculos);
        }
        catch (Exception E)
        {
            return Result<List<Vehiculo>>.Failed(E.Message);
        }
    }

    public async Task Editar(int Id,string marca, string modelo, int año, string color){
        var vehiculo = await _context.Vehiculos
        .FirstOrDefaultAsync(p=>p.VehiculoID == Id);
        if(vehiculo!=null){
        vehiculo.Update(marca,modelo,año,color);
        await _context.SaveChangesAsync();
        }
    }
    public async Task Eliminar(int Id){
        var vehiculo = await _context.Vehiculos
        .FirstOrDefaultAsync(p=>p.VehiculoID == Id);
        if(vehiculo!=null){
        _context.Vehiculos.Remove(vehiculo);
        await _context.SaveChangesAsync();
        }
    }
}

public interface IVehiculoService
{
    public Task<Result<int>> Crear(string marca, string modelo, int año, string color);
    public Task<Result<List<Vehiculo>>> Consultar(string filtro = "");
    public Task Editar(int Id, string marca, string modelo, int año, string color);
    public Task Eliminar(int Id);
}