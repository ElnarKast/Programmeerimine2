namespace KooliProjekt.WinFormsApp.Api;

public class Result<T> : Result
{
    public T Value { get; set; }

    public Result()
    {
    }

    private Result(T value) : base(null)
    {
        Value = value;
    }

    private Result(string error) : base(error)
    {
        Value = default;
    }

    public static Result<T> Success<T>(T value) => new Result<T>(value);
    public static Result<T> Failure<T>(string error) => new Result<T>(error);
}