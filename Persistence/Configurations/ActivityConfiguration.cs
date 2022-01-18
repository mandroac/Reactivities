using Domain.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistence.Configurations
{
    public class ActivityConfiguration : IEntityTypeConfiguration<Activity>
    {
        public void Configure(EntityTypeBuilder<Activity> builder)
        {
            builder.HasKey(a => a.Id);

            builder.Property(a => a.Category).IsRequired();
            builder.Property(a => a.City).IsRequired();
            builder.Property(a => a.Date).IsRequired();
            builder.Property(a => a.Description).IsRequired();
            builder.Property(a => a.Title).IsRequired();
            builder.Property(a => a.Venue).IsRequired();
        }
    }
}