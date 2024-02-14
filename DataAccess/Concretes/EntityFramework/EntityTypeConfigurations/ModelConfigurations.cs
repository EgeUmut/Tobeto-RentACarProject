using Entities.Concretes;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Concretes.EntityFramework.EntityTypeConfigurations;

public class ModelConfigurations : IEntityTypeConfiguration<Model>
{
    public void Configure(EntityTypeBuilder<Model> builder)
    {
        builder.ToTable("Models").HasKey(p => p.Id);
        builder.Property(p => p.Id).HasColumnName("id");
        builder.Property(p => p.BrandId).HasColumnName("BrandId");
        builder.Property(p => p.Name).HasColumnName("name");
        builder.Property(p => p.CreatedDate).HasColumnName("CreatedDate");
        builder.Property(p => p.DeletedTime).HasColumnName("DeletedDate");
        builder.Property(p => p.UpdatedTime).HasColumnName("UpdatedDate");
        builder.Property(p => p.DeleteStatus).HasColumnName("DeleteStatus");

        builder.HasOne(p => p.Brand);
        builder.HasMany(p => p.Cars);
    }
}
