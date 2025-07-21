namespace Cdb.Domain.Result
{
    public class Result
    {
        public int StatusCode { get; }
        public object Value { get; }
        public string ErrorMessage { get; }

        private Result(int statusCode, object value)
        {
            StatusCode = statusCode;
            Value = value;
        }

        private Result(int statusCode, string errorMessage)
        {
            StatusCode = statusCode;
            ErrorMessage = errorMessage;
        }

        // Resultado de sucesso
        public static Result Success(object value, int statusCode = 200)
            => new Result(statusCode, value);

        // Resultado de falha
        public static Result Failure(string errorMessage, int statusCode = 400)
            => new Result(statusCode, errorMessage);
    }
}
