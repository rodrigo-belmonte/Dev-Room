using DevRoom.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DevRoom.Persistence.Configuration
{
    public class ContentConfiguration : IEntityTypeConfiguration<Content>
    {
        public void Configure(EntityTypeBuilder<Content> builder)
        {
            builder.Property(t => t.Title)
                .HasMaxLength(1000)
                .IsRequired();

            builder.Property(t => t.SubHeading)
                .HasMaxLength(2000);

            builder.Property(t => t.Tags)
               .HasMaxLength(1000);

            builder.Property(t => t.TotalBookmarks)
               .HasDefaultValue(0);

            builder.Property(t => t.TotalViews)
               .HasDefaultValue(0);

            builder.Property(t => t.TotalLikes)
               .HasDefaultValue(0);

            builder.Property(t => t.TotalComments)
               .HasDefaultValue(0);

            builder.Property(t => t.Status)
               .HasDefaultValue(1);

            builder.Property(t => t.Spotlight)
               .HasDefaultValue(false);

            builder.Property(t => t.SpotlightOrder)
             .HasDefaultValue(0);
        }
    }
}
