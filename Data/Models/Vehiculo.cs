using System.ComponentModel.DataAnnotations;
using Vehiculo20200288.Data.Context;
using Vehiculo20200288.Request;

namespace Vehiculo20200288.Data.Models;


public class Vehiculo
{
    [Key]//Clave primaria de la base de datos
    public int VehiculoID { get; set; } 
    [Required, MaxLength(100)]//Campo obligatorio, máximo de caracteres 100.
    public string Marca { get; set; } = null!;
    [Required, MaxLength(100)]//Campo obligatorio, máximo de caracteres 100.
    public string Modelo { get; set; } = null!;
    public int Año { get; set; } = 2002;
    public string Color { get; set; } = null!;
    //Para crear una variable tipo contacto, se utiliza el request para recibir los datos.
    public static Vehiculo Crear(VehiculoRequest datos) => new()
    {
        Marca = datos.Marca,
        Modelo = datos.Modelo,
        Color = datos.Color,
        Año = datos.Año
    };
}