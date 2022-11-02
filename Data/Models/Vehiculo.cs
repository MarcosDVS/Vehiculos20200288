namespace Models;

public class Vehiculo
{
    public int VehiculoID { get; set; }
    public string Marca { get; set; } = null!;
    public string Modelo { get; set; } = null!;
    public int Año { get; set; }
    public string Color { get; set; } = null!;
}