namespace BigCalculator.Core
{
    public abstract class Result<T>
    {
        public abstract ResultType ResultType { get; }

        public abstract List<string> Errors { get; }

        public abstract T Data { get; }
    }

    public class InvalidResult<T> : Result<T>
    {
        private string _error;

        public InvalidResult(string error)
        {
            _error = error;
        }

        public override ResultType ResultType => ResultType.Invalid;

        public override List<string> Errors => new List<string> { _error ?? "The input was invalid." };

        public override T Data => default(T);
    }

    public class IncorrectCalculus<T>: Result<T>
    {
        private readonly T _data;

        public IncorrectCalculus(T data)
        {
            _data = data;
        }

        public override ResultType ResultType => ResultType.IncorrectOutcome;

        public override List<string> Errors => new List<string>();

        public override T Data => _data;
    }

    public class SuccessResult<T> : Result<T>
    {
        private readonly T _data;

        public SuccessResult(T data)
        {
            _data = data;
        }

        public override ResultType ResultType => ResultType.Ok;

        public override List<string> Errors => new List<string>();

        public override T Data => _data;
    }

    public enum ResultType
    {
        Ok,
        Invalid,
        Unauthorized,
        PartialOk,
        NotFound,
        PermissionDenied,
        Unexpected,
        IncorrectOutcome
    }
}
