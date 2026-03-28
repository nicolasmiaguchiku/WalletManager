namespace WalletManager.Domain.Base
{
    public class Result
    {
        public bool IsSuccess { get; }
        public bool IsFaiulure => !IsSuccess;
        public Error Error { get; }

        protected Result(bool isSuccess, Error error)
        {
            IsSuccess = isSuccess;
            Error = error;
        }

        public static Result Success() => new(true, Error.None);
        public static Result Failure(Error error) => new(false, error);
    }

    public class Result<T> : Result
    {
        private readonly T _value;

        private Result(T valule, bool isSuccess, Error error) : base(isSuccess, error)
        {
            _value = valule;
        }

        public T Data => _value;
        public static Result<T> Success(T value) => new(value, true, Error.None);
        public static new Result<T> Failure(Error error) => new(default!, false, error);
        public static Result<T> Failure(Error error, T value) => new(value, false, error);
    }

    public sealed record Error(string Code, string Message)
    {
        public static readonly Error None = new(string.Empty, string.Empty);
    }
}