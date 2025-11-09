using System.Reflection.Metadata.Ecma335;

namespace MiniBank.ResultPattern;

public static class Result
{
    public static Result<T> Success<T>(T payload)
    {
        return new Result<T>
        {
            Payload = payload,
        };
    }

    public static Result<Error> Failure(string message)
    {
        var result = new Result<Error>(new Error(message));
        return result;
    }

    public static Result<Error> Failure(int code, string message)
    {
        var result = new Result<Error>(new Error(code, message));

        return result;
    }
}


public class Result<T> //: ResultBase
{
    private Error _error;
    private string _message;

    public bool IsSuccess => _error == null;
    public bool IsError => _error != null;
    public string Message => _message;
    public Error Error => _error;
    public T Payload { get; set; }

    public Result()
    {
    }

    public Result(Error error) //: base(error)
    {
        _error = error;
    }

    public static implicit operator Result<T>(Result<Error> sourceResult) 
    {
        if(sourceResult.IsError)
            return new Result<T>(sourceResult.Error);

        return new Result<T>(new Error(""));
    }

}
    
public class Error
{
    public int? Code { get; private set; }
    public string Message { get; private set; }

    public Error(string message)
    {
        Message = message;
    }

    public Error(int code, string message) : this(message)
    {
        Code = code;
    }
}