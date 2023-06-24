namespace DWFIAP.WebApp.DTOs
{
    public class RequestResponseDTO<T>
    {
        public T data { get; set; }
        public string message { get; set; }
        public bool isSuccess { get; set; }
        public List<ValidationError> Errors { get; set; }
    }

    public class ValidationError
    {
        public string Field { get; set; }
        public string Message { get; set; }
    }
}
