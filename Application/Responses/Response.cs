namespace SuplementShop.Application.Responses
{
    public class Response<T> where T : class
    {
        public T Value { get; set; }

        public string Message { get; set; }

        public static Response<T> Ok(T value)
        {
            return new Response<T>
            {
                Message = string.Empty,
                Value = value
            };
        }

        public static Response<T> Error(string message)
        {
            return new Response<T>
            {
                Message = message,
                Value = null
            };
        }
    }
}
