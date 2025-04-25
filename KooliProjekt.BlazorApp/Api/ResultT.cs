using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KooliProjekt.BlazorApp.Api
{
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

        public static Result<T> Success(T value) => new Result<T>(value);
        public static Result<T> Failure(string error) => new Result<T>(error);
    }
}
