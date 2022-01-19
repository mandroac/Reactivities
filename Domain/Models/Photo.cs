namespace Domain.Models
{
    public class Photo : BaseEntity<string>
    {
        public string Url { get; set; }
        public bool IsMain { get; set; }
    }
}