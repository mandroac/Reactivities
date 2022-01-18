using System;

namespace Domain.Models
{
    public class ActivityAttendee
    {
        public Guid UserId { get; set; }
        public Guid ActivityId { get; set; }
        public User User { get; set; }
        public Activity Activity { get; set; }
        public bool IsHost { get; set; }
    }
}