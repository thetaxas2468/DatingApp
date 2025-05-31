namespace DatingAppBackend
{
  public class ApiException
  {
    public int StatusCode { get; set; }
    public string Message { get; set; }
    public string?  Details { get; set; }
    public ApiException(int status, string message, string? details)
    {
      this.StatusCode = status;
      this.Message = message;
      this.Details = details;
    }
  }
}
