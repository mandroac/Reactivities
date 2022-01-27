using System;

namespace Domain.Models
{
    public class Comment : BaseEntity<int>
    {
        public string Body { get; set; }
        public User Author { get; set; }
        public Activity Activity { get; set; }
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
    }
}