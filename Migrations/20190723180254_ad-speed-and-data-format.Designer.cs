﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Raspertise.Data;

namespace Raspertise.Migrations
{
    [DbContext(typeof(RaspertiseContext))]
    [Migration("20190723180254_ad-speed-and-data-format")]
    partial class adspeedanddataformat
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.2.6-servicing-10079");

            modelBuilder.Entity("Raspertise.Models.Advertisement", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Color");

                    b.Property<DateTime>("DateStart");

                    b.Property<DateTime>("DateStop");

                    b.Property<int>("LocationId");

                    b.Property<string>("Message");

                    b.Property<string>("Speed");

                    b.Property<int>("SponsorId");

                    b.Property<decimal>("TotalCost");

                    b.HasKey("Id");

                    b.HasIndex("LocationId");

                    b.HasIndex("SponsorId");

                    b.ToTable("Advertisement");
                });

            modelBuilder.Entity("Raspertise.Models.Advertiser", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<decimal>("AmountEarned");

                    b.Property<string>("Email");

                    b.Property<string>("FirstName");

                    b.Property<string>("LastName");

                    b.Property<string>("Phone");

                    b.HasKey("Id");

                    b.ToTable("Advertiser");
                });

            modelBuilder.Entity("Raspertise.Models.Location", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("AdvertiserId");

                    b.Property<string>("Description");

                    b.Property<decimal>("PricePerDay");

                    b.HasKey("Id");

                    b.HasIndex("AdvertiserId");

                    b.ToTable("Location");
                });

            modelBuilder.Entity("Raspertise.Models.Sponsor", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Email");

                    b.Property<string>("FirstName")
                        .HasMaxLength(50);

                    b.Property<string>("LastName")
                        .HasMaxLength(50);

                    b.Property<int?>("PaymentMethod");

                    b.Property<string>("Phone");

                    b.HasKey("Id");

                    b.ToTable("Sponsor");
                });

            modelBuilder.Entity("Raspertise.Models.Advertisement", b =>
                {
                    b.HasOne("Raspertise.Models.Location", "Location")
                        .WithMany()
                        .HasForeignKey("LocationId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("Raspertise.Models.Sponsor", "Sponsor")
                        .WithMany("Advertisments")
                        .HasForeignKey("SponsorId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Raspertise.Models.Location", b =>
                {
                    b.HasOne("Raspertise.Models.Advertiser")
                        .WithMany("Locations")
                        .HasForeignKey("AdvertiserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });
#pragma warning restore 612, 618
        }
    }
}
