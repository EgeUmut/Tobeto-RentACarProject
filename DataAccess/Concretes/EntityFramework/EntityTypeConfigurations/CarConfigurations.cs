using Entities.Concretes;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Concretes.EntityFramework.EntityTypeConfigurations;

public class CarConfigurations : IEntityTypeConfiguration<Car>
{
    public void Configure(EntityTypeBuilder<Car> builder)
    {
        builder.ToTable("Cars").HasKey(p => p.Id);
        builder.Property(p => p.Id).HasColumnName("id");
        builder.Property(p => p.ModelId).HasColumnName("ModelId");
        builder.Property(p => p.ModelYear).HasColumnName("ModelYear");
        builder.Property(p => p.State).HasColumnName("State");
        builder.Property(p => p.DailyPrice).HasColumnName("DailyPrice");
        builder.Property(p => p.Plate).HasColumnName("Plate");
        builder.Property(p => p.CreatedDate).HasColumnName("CreatedDate");
        builder.Property(p => p.DeletedTime).HasColumnName("DeletedDate");
        builder.Property(p => p.UpdatedTime).HasColumnName("UpdatedDate");
        builder.Property(p => p.DeleteStatus).HasColumnName("DeleteStatus");


        builder.HasOne(p => p.Model);
    }
}
