using System.ComponentModel.DataAnnotations;
using Vehiculo20200288.Data.Context;

namespace Vehiculo20200288.Data.Models;


public class Vehiculo
{
    [Key] public int VehiculoID { get; set; }
    public string Marca { get; set; } = null!;
    public string Modelo { get; set; } = null!;
    public int Año { get; set; }
    public string Color { get; set; } = null!;

    public static Vehiculo Crear(string marca, string modelo, int año, string color)
    {
        return new Vehiculo(){
            VehiculoID = 0,
            Marca= marca,
            Modelo = modelo,
            Año = año,
            Color = color
            };
    }

    public void Update(string marca, string modelo, int año, string color)
    {
        Marca= marca;
        Modelo = modelo;
        Año = año;
        Color = color;
    }
}