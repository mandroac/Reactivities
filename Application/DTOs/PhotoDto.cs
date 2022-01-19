namespace Application.DTOs
{
        public class PhotoDto : BaseDto<string>
    {
        public string Url { get; set; }
        public bool IsMain { get; set; }
    }
}