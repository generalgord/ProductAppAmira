namespace ProductApp.Application.Common.Wrappers
{
    public class BaseResponse
    {
        public Guid Id { get; set; }
        public bool Succcess { get; set; }
        public string Message { get; set; }
    }
}
