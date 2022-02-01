using System;

namespace Domain.Models
{
    public class UserFollowing
    {
        public Guid ObserverId { get; set; }
        public Guid TargetId { get; set; }
        public User Observer { get; set; }
        public User Target { get; set; }
    }
}