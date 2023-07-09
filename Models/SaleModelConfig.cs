using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
namespace TestIdentity.Models;

public class SaleModelConfig : IEntityTypeConfiguration<SaleModel>
{
    public void Configure(EntityTypeBuilder<SaleModel> builder)
    {
        builder.ToTable("Sale");

        builder
            .Property(s => s.SaleModelId)
            .HasColumnName("SaleId");

        builder
            .Property(s => s.ProductName)
            .HasColumnType("NVARCHAR")
            .HasMaxLength(120);

        builder
            .Property(s => s.TotalAmount)
            .HasColumnType("DECIMAL")
            .HasPrecision(10, 2);

        builder
            .Property(s => s.UserModelId)
            .HasColumnName("UserIdFk");

        builder
            .Property(s => s.Active)
            .HasColumnType("BIT")
            .HasDefaultValue(true);

        builder
            .Property(s => s.CreateDate)
            .HasColumnType("DATETIMEOFFSET")
            .HasDefaultValueSql("SYSDATETIMEOFFSET()");

        builder
            .Property(s => s.UpdateDate)
            .HasColumnType("DATETIMEOFFSET")
            .HasDefaultValueSql("SYSDATETIMEOFFSET()");
    }
}
