namespace NetCore.API.Models
{
    public class ResponseData
    {
        public int ResponseCode { get; set; }
        public string? Description { get; set; }
    }
    public class User_UploadImageResponseData : ResponseData
    {
    }
}
