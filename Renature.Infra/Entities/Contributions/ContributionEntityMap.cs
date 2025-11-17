using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Renature.Infra.Entities.Contributions.Enums;

namespace Renature.Infra.Entities.Contributions;

public class ContributionEntityMap : IEntityTypeConfiguration<Contribution>
{
    public void Configure(EntityTypeBuilder<Contribution> builder)
    {
        builder.ToTable("Contributions");
        
        builder.HasKey(x => x.Id);

        builder.Property(x => x.UserId)
            .IsRequired();

        builder.Property(x => x.WasteType)
            .HasConversion(new EnumToStringConverter<WasteType>());
        
        builder.Property(x => x.Product)
            .IsRequired();

        builder.Property(x => x.Quantity)
            .IsRequired();
        
        builder.Property(x => x.AdquiredPoints)
            .IsRequired();
        
        builder.Property(x => x.Date)
            .IsRequired();

        builder.HasOne(x => x.User)
            .WithMany()
            .HasForeignKey(x => x.UserId)
            .OnDelete(DeleteBehavior.Restrict);
    }

}