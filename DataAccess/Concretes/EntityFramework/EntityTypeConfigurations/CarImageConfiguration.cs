using Entities.Concretes;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Concretes.EntityFramework.EntityTypeConfigurations;

public class CarImageConfiguration : IEntityTypeConfiguration<CarImage>
{
    public void Configure(EntityTypeBuilder<CarImage> builder)
    {
        builder.ToTable("CarImages").HasKey(p => p.Id);
        builder.Property(p => p.Id).HasColumnName("id");
        builder.Property(p => p.CarId).HasColumnName("CarId");
        builder.Property(p => p.ImagePath).HasColumnName("ImagePath");
        builder.Property(p => p.CreatedDate).HasColumnName("CreatedDate");
        builder.Property(p => p.DeletedDate).HasColumnName("DeletedDate");
        builder.Property(p => p.UpdatedDate).HasColumnName("UpdatedDate");
        builder.Property(p => p.DeleteStatus).HasColumnName("DeleteStatus");

        builder.HasOne(p => p.Car);
    }
}
