﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using MyWebApi.Data;

namespace MyWebApi.Migrations
{
    [DbContext(typeof(DataContext))]
    [Migration("20230515141511_AddingPropertyRelatedEntities")]
    partial class AddingPropertyRelatedEntities
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.17")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("MyWebApi.Models.City", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Country")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("LastUpdatedBy")
                        .HasColumnType("int");

                    b.Property<DateTime>("LastUpdatedOn")
                        .HasColumnType("datetime2");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Cities");
                });

            modelBuilder.Entity("MyWebApi.Models.FurnishingType", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("LastUpdatedBy")
                        .HasColumnType("int");

                    b.Property<DateTime>("LastUpdatedOn")
                        .HasColumnType("datetime2");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("FurnishingTypes");
                });

            modelBuilder.Entity("MyWebApi.Models.Photo", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("ImageUrl")
                        .HasColumnType("int");

                    b.Property<bool>("IsPrimary")
                        .HasColumnType("bit");

                    b.Property<int>("LastUpdatedBy")
                        .HasColumnType("int");

                    b.Property<DateTime>("LastUpdatedOn")
                        .HasColumnType("datetime2");

                    b.Property<int>("PropertyId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("PropertyId");

                    b.ToTable("Photos");
                });

            modelBuilder.Entity("MyWebApi.Models.Property", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Address")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Address2")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Age")
                        .HasColumnType("int");

                    b.Property<int>("BHK")
                        .HasColumnType("int");

                    b.Property<int>("BuiltArea")
                        .HasColumnType("int");

                    b.Property<int>("CarpetArea")
                        .HasColumnType("int");

                    b.Property<int>("CityId")
                        .HasColumnType("int");

                    b.Property<string>("Description")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("EstPossessionOn")
                        .HasColumnType("datetime2");

                    b.Property<int>("FloorNo")
                        .HasColumnType("int");

                    b.Property<int>("FurnishingTypeId")
                        .HasColumnType("int");

                    b.Property<bool>("Gated")
                        .HasColumnType("bit");

                    b.Property<int>("LastUpdatedBy")
                        .HasColumnType("int");

                    b.Property<DateTime>("LastUpdatedOn")
                        .HasColumnType("datetime2");

                    b.Property<string>("MainEntrance")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Maintenance")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("PostedBy")
                        .HasColumnType("int");

                    b.Property<DateTime>("PostedOn")
                        .HasColumnType("datetime2");

                    b.Property<int>("Price")
                        .HasColumnType("int");

                    b.Property<int>("PropertTypeId")
                        .HasColumnType("int");

                    b.Property<int?>("PropertyTypeId")
                        .HasColumnType("int");

                    b.Property<int>("ReadyMove")
                        .HasColumnType("int");

                    b.Property<int>("Security")
                        .HasColumnType("int");

                    b.Property<int>("SellRent")
                        .HasColumnType("int");

                    b.Property<int>("TotalFloors")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("CityId");

                    b.HasIndex("FurnishingTypeId");

                    b.HasIndex("PostedBy");

                    b.HasIndex("PropertyTypeId");

                    b.ToTable("Properties");
                });

            modelBuilder.Entity("MyWebApi.Models.PropertyType", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("LastUpdatedBy")
                        .HasColumnType("int");

                    b.Property<DateTime>("LastUpdatedOn")
                        .HasColumnType("datetime2");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("PropertyTypes");
                });

            modelBuilder.Entity("MyWebApi.Models.User", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("LastUpdatedBy")
                        .HasColumnType("int");

                    b.Property<DateTime>("LastUpdatedOn")
                        .HasColumnType("datetime2");

                    b.Property<byte[]>("Password")
                        .IsRequired()
                        .HasColumnType("varbinary(max)");

                    b.Property<byte[]>("PasswordKey")
                        .HasColumnType("varbinary(max)");

                    b.Property<string>("Username")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Users");
                });

            modelBuilder.Entity("MyWebApi.Models.Photo", b =>
                {
                    b.HasOne("MyWebApi.Models.Property", "Property")
                        .WithMany("Photo")
                        .HasForeignKey("PropertyId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Property");
                });

            modelBuilder.Entity("MyWebApi.Models.Property", b =>
                {
                    b.HasOne("MyWebApi.Models.City", "City")
                        .WithMany()
                        .HasForeignKey("CityId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("MyWebApi.Models.FurnishingType", "FurnishingType")
                        .WithMany()
                        .HasForeignKey("FurnishingTypeId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("MyWebApi.Models.User", "User")
                        .WithMany()
                        .HasForeignKey("PostedBy")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("MyWebApi.Models.PropertyType", "PropertyType")
                        .WithMany()
                        .HasForeignKey("PropertyTypeId");

                    b.Navigation("City");

                    b.Navigation("FurnishingType");

                    b.Navigation("PropertyType");

                    b.Navigation("User");
                });

            modelBuilder.Entity("MyWebApi.Models.Property", b =>
                {
                    b.Navigation("Photo");
                });
#pragma warning restore 612, 618
        }
    }
}