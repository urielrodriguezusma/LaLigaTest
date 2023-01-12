namespace Catalog.Api.Errors
{
    public class ApiValidationErrorResponse : ApiResponse
    {
        public IEnumerable<string> Errors { get; set; }
        public ApiValidationErrorResponse() : base(StatusCodes.Status400BadRequest)
        {
        }
    }
}
