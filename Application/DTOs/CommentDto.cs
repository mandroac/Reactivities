using System;

namespace Application.DTOs
{
    public class CommentDto : BaseDto<int>
    {
        public DateTime CreatedAt { get; set; }
        public string Body { get; set; }
        public string Username { get; set; }
        public string DisplayName { get; set; }
        public string Image { get; set; }
        public Guid ActivityId { get; set; }
    }
}