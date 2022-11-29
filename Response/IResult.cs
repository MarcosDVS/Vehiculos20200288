namespace Vehiculo20200288.Response;

public interface IResult
{
    bool Exitoso {get; set;}
    string Mensaje {get; set;}
}

public interface IResult<TData>:IResult
{
    public TData? Datos {get; set;}
}