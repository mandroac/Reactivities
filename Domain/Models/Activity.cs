using System;
using System.Collections.Generic;

namespace Domain.Models
{
    public class Activity : BaseEntity<Guid>
    {
        public new Guid Id { get; set; } = Guid.NewGuid();
        public string Title { get; set; }
        public DateTime Date { get; set; }
        public string Description { get; set; }  
        public string Category { get; set; }
        public string City { get; set; }
        public string Venue { get; set; }   
        public bool IsCancelled { get; set; } 
        public ICollection<ActivityAttendee> Attendees { get; set; } = new List<ActivityAttendee>();
        public ICollection<Comment> Comments { get; set; }= new List<Comment>();
    }
}