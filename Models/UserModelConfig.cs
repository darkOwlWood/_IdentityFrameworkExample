using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
namespace TestIdentity.Models;

public class UserModelConfig : IEntityTypeConfiguration<UserModel>
{
    public void Configure(EntityTypeBuilder<UserModel> builder)
    {
        builder
            .Property(u => u.Name)
            .HasColumnType("NVARCHAR")
            .HasMaxLength(80);

        builder
            .Property(u => u.LastName)
            .HasColumnType("NVARCHAR")
            .HasMaxLength(120);

        builder
            .Property(u => u.Active)
            .HasColumnType("BIT")
            .HasDefaultValue(true);

        builder
            .Property(u => u.CreateDate)
            .HasColumnType("DATETIMEOFFSET")
            .HasDefaultValueSql("SYSDATETIMEOFFSET()");

        builder
            .Property(u => u.UpdateDate)
            .HasColumnType("DATETIMEOFFSET")
            .HasDefaultValueSql("SYSDATETIMEOFFSET()");
    }
}