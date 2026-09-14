namespace EcoScope.Result
{
    public class DataResult<T>
    {
        public bool IsSuccess { get; set; }
        public T? Data { get; set; }
        public string? Message { get; set; }
    }
}
