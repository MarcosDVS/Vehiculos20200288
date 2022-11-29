namespace Vehiculo20200288.Response;

public class VehiculoRecord
{
    public int VehiculoID { get; set; } 
    public string Marca { get; set; } = null!;
    public string Modelo { get; set; } = null!;
    public int Año { get; set; }
    public string Color { get; set; } = null!;
}