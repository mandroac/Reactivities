using System;

namespace Application.DTOs
{
    public class PartialActivityDto : BaseDto<Guid>
    {
        public string Title { get; set; }
        public string Category { get; set; }
        public DateTime Date { get; set; }

        [Newtonsoft.Json.JsonIgnore]
        public string HostUsername { get; set; }
    }
}