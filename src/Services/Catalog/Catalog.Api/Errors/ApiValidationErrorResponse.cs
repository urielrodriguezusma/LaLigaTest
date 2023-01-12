namespace Catalog.Api.Errors
{
    public class ApiValidationErrorResponse : ApiResponse
    {
        public IEnumerable<string> Errors { get; set; }
        public ApiValidationErrorResponse(IEnumerable<string> errors) : base(StatusCodes.Status400BadRequest)
        {
            this.Errors = errors;
        }
    }
}
