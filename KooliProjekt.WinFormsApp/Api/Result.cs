namespace KooliProjekt.WinFormsApp.Api
{
    public class Result
    {
        public string Error { get; }
        public bool IsSuccess => string.IsNullOrEmpty(Error);
        public bool HasError => !IsSuccess;

        public Result()
        {
        }

        protected Result(string error)
        {
            Error = error;
        }

        public static Result Success() => new Result(null);
        public static Result Failure(string error) => new Result(error);
    }
}