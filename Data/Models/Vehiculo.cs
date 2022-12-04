using System.ComponentModel.DataAnnotations;
using Vehiculo20200288.Data.Context;
using Vehiculo20200288.Request;

namespace Vehiculo20200288.Data.Models;


public class Vehiculo
{
    [Key]//Clave primaria de la base de datos
    public int VehiculoID { get; set; } 
    [Required, MaxLength(30)]//Campo obligatorio, máximo de caracteres 30.
    public string Marca { get; set; } = null!;
    [Required, MaxLength(30)]//Campo obligatorio, máximo de caracteres 30.
    public string Modelo { get; set; } = null!;
    public int Año { get; set; }
    public string Color { get; set; } = null!;

    //Para crear una variable tipo contacto, se utiliza el request para recibir los datos.
    public static Vehiculo Crear(VehiculoRequest datos) => new()
    {
        /*Esta funcion es llama en VehiculoService para registrar
        la informacion en la base de datos*/
        Marca = datos.Marca,
        Modelo = datos.Modelo,
        Color = datos.Color,
        Año = datos.Año
    };

    public void Update(string marca, string modelo, string color, int año)
    {
        Marca = marca;
        Modelo = modelo;
        Color = color;
        Año = año;
    }
}