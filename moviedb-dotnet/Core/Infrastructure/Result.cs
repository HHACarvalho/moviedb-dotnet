namespace moviedb_dotnet.Core.Infrastructure
{
    public class Result<T> where T : class
    {
        public bool IsSuccess { get; }
        public string? Error { get; }
        public T? Value { get; }

        public Result(bool isSuccess, string? error, T? value)
        {
            IsSuccess = isSuccess;
            Error = error;
            Value = value;
        }

        public static Result<T> Ok(T value)
        {
            return new Result<T>(true, null, value);
        }

        public static Result<T> Fail(string error)
        {
            return new Result<T>(false, error, null);
        }
    }
}
