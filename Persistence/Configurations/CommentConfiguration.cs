using Domain.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistence.Configurations
{
    public class CommentConfiguration : IEntityTypeConfiguration<Comment>
    {
        public void Configure(EntityTypeBuilder<Comment> builder)
        {
            builder.HasKey(c => c.Id);
            builder.HasOne(c => c.Activity).WithMany(a => a.Comments).OnDelete(DeleteBehavior.Cascade);
            builder.Property(c => c.Body).IsRequired();
        }
    }
}