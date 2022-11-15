namespace Vehiculo20200288;

public class Result
{
    public string Message { get; set; } = null!;
    public bool Succeeded { get; set; }

    public static Result Success(string message = "") => new Result(){ Message = message, Succeeded = true};
    public static Result Failed(string message = "") => new Result(){ Message = message, Succeeded = false};
}
public class Result<TData>:Result
{
    public TData? Data { get; set; }
    public static Result<TData> Success(TData data, string message = "") => new Result<TData>(){ Message = message, Succeeded = true, Data = data};
    public static new Result<TData> Failed(string message = "") => new Result<TData>(){ Message = message, Succeeded = false};
}