﻿// <auto-generated />
using System;
using DataAccess.Concretes.EntityFramework.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace DataAccess.Migrations
{
    [DbContext(typeof(BaseDbContext))]
    [Migration("20240216220130_ModelsNullUpdate")]
    partial class ModelsNullUpdate
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.2")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("Entities.Concretes.Brand", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("id");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<DateTime?>("CreatedDate")
                        .HasColumnType("datetime2")
                        .HasColumnName("CreatedDate");

                    b.Property<bool?>("DeleteStatus")
                        .HasColumnType("bit")
                        .HasColumnName("DeleteStatus");

                    b.Property<DateTime?>("DeletedDate")
                        .HasColumnType("datetime2")
                        .HasColumnName("DeletedDate");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("name");

                    b.Property<DateTime?>("UpdatedDate")
                        .HasColumnType("datetime2")
                        .HasColumnName("UpdatedDate");

                    b.HasKey("Id");

                    b.ToTable("Brands", (string)null);
                });

            modelBuilder.Entity("Entities.Concretes.Car", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("id");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<DateTime?>("CreatedDate")
                        .HasColumnType("datetime2")
                        .HasColumnName("CreatedDate");

                    b.Property<double>("DailyPrice")
                        .HasColumnType("float")
                        .HasColumnName("DailyPrice");

                    b.Property<bool?>("DeleteStatus")
                        .HasColumnType("bit")
                        .HasColumnName("DeleteStatus");

                    b.Property<DateTime?>("DeletedDate")
                        .HasColumnType("datetime2")
                        .HasColumnName("DeletedDate");

                    b.Property<int?>("ModelId")
                        .HasColumnType("int")
                        .HasColumnName("ModelId");

                    b.Property<int>("ModelYear")
                        .HasColumnType("int")
                        .HasColumnName("ModelYear");

                    b.Property<string>("Plate")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("Plate");

                    b.Property<int>("State")
                        .HasColumnType("int")
                        .HasColumnName("State");

                    b.Property<DateTime?>("UpdatedDate")
                        .HasColumnType("datetime2")
                        .HasColumnName("UpdatedDate");

                    b.HasKey("Id");

                    b.HasIndex("ModelId");

                    b.ToTable("Cars", (string)null);
                });

            modelBuilder.Entity("Entities.Concretes.Model", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("id");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int?>("BrandId")
                        .HasColumnType("int")
                        .HasColumnName("BrandId");

                    b.Property<DateTime?>("CreatedDate")
                        .HasColumnType("datetime2")
                        .HasColumnName("CreatedDate");

                    b.Property<bool?>("DeleteStatus")
                        .HasColumnType("bit")
                        .HasColumnName("DeleteStatus");

                    b.Property<DateTime?>("DeletedDate")
                        .HasColumnType("datetime2")
                        .HasColumnName("DeletedDate");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("name");

                    b.Property<DateTime?>("UpdatedDate")
                        .HasColumnType("datetime2")
                        .HasColumnName("UpdatedDate");

                    b.HasKey("Id");

                    b.HasIndex("BrandId");

                    b.ToTable("Models", (string)null);
                });

            modelBuilder.Entity("Entities.Concretes.Car", b =>
                {
                    b.HasOne("Entities.Concretes.Model", "Model")
                        .WithMany("Cars")
                        .HasForeignKey("ModelId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.Navigation("Model");
                });

            modelBuilder.Entity("Entities.Concretes.Model", b =>
                {
                    b.HasOne("Entities.Concretes.Brand", "Brand")
                        .WithMany("Models")
                        .HasForeignKey("BrandId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.Navigation("Brand");
                });

            modelBuilder.Entity("Entities.Concretes.Brand", b =>
                {
                    b.Navigation("Models");
                });

            modelBuilder.Entity("Entities.Concretes.Model", b =>
                {
                    b.Navigation("Cars");
                });
#pragma warning restore 612, 618
        }
    }
}
