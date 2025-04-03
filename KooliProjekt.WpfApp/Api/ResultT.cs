namespace KooliProjekt.WpfApp.Api
{
    public class Result<T> : Result
    {
        public T Value { get; }

        private Result(T value) : base(null)
        {
            Value = value;
        }

        private Result(string error) : base(error)
        {
            Value = default;
        }

        public static Result<T> Success(T value) => new Result<T>(value);
        public static Result<T> Failure(string error) => new Result<T>(error);
    }
}