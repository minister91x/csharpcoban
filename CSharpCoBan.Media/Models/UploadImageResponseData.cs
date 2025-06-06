namespace CSharpCoBan.Media.Models
{
    public class ResponseData
    {
        public int ResponseCode { get; set; }
        public string? Description { get; set; }
    }
    public class UploadImageResponseData: ResponseData
    {
    }
}
