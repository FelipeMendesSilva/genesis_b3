namespace Cdb.Domain.Result
{
    public class  Result
    {
        public int StatusCode { get; }
        public object? Data { get; }
        public string? ErrorMessage { get; }

        private Result(int statusCode, object? data)
        {
            StatusCode = statusCode;
            Data = data;
        }

        private Result(int statusCode, string errorMessage)
        {
            StatusCode = statusCode;
            ErrorMessage = errorMessage;
        }
        
        public static Result Success(object data, int statusCode = 200)
            => new Result(statusCode, data);

        public static Result Failure(string errorMessage, int statusCode = 400)
            => new Result(statusCode, errorMessage);
    }
}
