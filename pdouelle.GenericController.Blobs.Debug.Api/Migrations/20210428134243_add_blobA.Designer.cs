﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using pdouelle.GenericController.Blobs.Debug.Api.Data;

namespace pdouelle.GenericController.Blobs.Debug.Api.Migrations
{
    [DbContext(typeof(DatabaseService))]
    [Migration("20210428134243_add_blobA")]
    partial class add_blobA
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.5")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("pdouelle.GenericController.Blobs.Debug.Api.Models.Blobs.Entities.BlobA", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("ContainerName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<Guid?>("OfferId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("Id");

                    b.HasIndex("OfferId");

                    b.ToTable("Blobs");
                });

            modelBuilder.Entity("pdouelle.GenericController.Blobs.Debug.Api.Models.Offers.Entities.Offer", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Offers");
                });

            modelBuilder.Entity("pdouelle.GenericController.Blobs.Debug.Api.Models.Blobs.Entities.BlobA", b =>
                {
                    b.HasOne("pdouelle.GenericController.Blobs.Debug.Api.Models.Offers.Entities.Offer", "Offer")
                        .WithMany("Blobs")
                        .HasForeignKey("OfferId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.Navigation("Offer");
                });

            modelBuilder.Entity("pdouelle.GenericController.Blobs.Debug.Api.Models.Offers.Entities.Offer", b =>
                {
                    b.Navigation("Blobs");
                });
#pragma warning restore 612, 618
        }
    }
}
