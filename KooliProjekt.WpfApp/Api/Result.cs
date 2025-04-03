namespace KooliProjekt.WpfApp.Api
{
    public class Result
    {
        public string Error { get; }
        public bool IsSuccess => string.IsNullOrEmpty(Error);
        public bool HasError => !IsSuccess;

         protected Result(string error)
        {
            Error = error;
        }

        public static Result Success() => new Result(null);
        public static Result Failure(string error) => new Result(error);
    }
}