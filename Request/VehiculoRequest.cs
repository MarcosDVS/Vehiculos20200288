using System.ComponentModel.DataAnnotations;

namespace Vehiculo20200288.Request;
//Elemento se utilizara para las peticiones de registro de vehiculos.
public class VehiculoRequest
{
    public VehiculoRequest()
    { 
        
    }
    public VehiculoRequest(string marca, string modelo, string color, int año)
    {
        Marca = marca;
        Modelo = modelo;
        Año = año;
        Color = color;
    }
    [Required(ErrorMessage = "La marca del vehiculo es obligatorio.!"), MaxLength(30)]
    public string Marca { get; set; } = null!;

    [Required(ErrorMessage = "El modelo del vehiculo es obligatorio.!"),MaxLength(30)]
    public string Modelo { get; set; } = null!;

    [Required(ErrorMessage = "El color del vehiculo es obligatorio.!"),MaxLength(30)]
    public string Color { get; set; } = null!;
    public int Año { get; set; } = 2002;

    
}