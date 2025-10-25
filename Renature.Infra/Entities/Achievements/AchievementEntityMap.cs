using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Renature.Infra.Entities.Achievements;

public class AchievementEntityMap : IEntityTypeConfiguration<Achievement>
{
    public void Configure(EntityTypeBuilder<Achievement> builder)
    {
        builder.ToTable("achievement");
        
        builder.HasKey(x => x.Id);

        builder.Property(x => x.Title)
            .IsRequired();
        
        builder.Property(x => x.Description)
            .IsRequired();
        
        builder.Property(x => x.Image)
            .IsRequired();
    }
}