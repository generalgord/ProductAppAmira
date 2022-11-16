namespace ProductApp.Application.Common.Wrappers
{
    public class BaseResponse
    {
        internal BaseResponse(bool succeeded, IEnumerable<string> errors)
        {
            Succceded = succeeded;
            Errors = errors.ToArray();
        }
        //public Guid Id { get; set; }
        //public string Message { get; set; },

        public bool Succceded { get; set; }
        public string[] Errors { get; set; }

        public static BaseResponse Success()
        {
            return new BaseResponse(true, Array.Empty<string>());
        }

        public static BaseResponse Failure(IEnumerable<string> errors)
        {
            return new BaseResponse(false, errors);
        }
    }
}
