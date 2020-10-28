﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using TourManager.Data.Core.Configuration;

namespace TourManager.Data.Migrations
{
    [DbContext(typeof(TourManagerContext))]
    partial class TourManagerContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.1.9");

            modelBuilder.Entity("TourManager.Data.Core.Domain.Address", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<int?>("ContactId")
                        .HasColumnType("INTEGER");

                    b.Property<DateTime>("Inserted")
                        .HasColumnType("TEXT");

                    b.Property<DateTime>("LastUpdate")
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.HasIndex("ContactId");

                    b.ToTable("Address");
                });

            modelBuilder.Entity("TourManager.Data.Core.Domain.Bands", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<DateTime>("Inserted")
                        .HasColumnType("TEXT");

                    b.Property<DateTime>("LastUpdate")
                        .HasColumnType("TEXT");

                    b.Property<int?>("ManagerId")
                        .HasColumnType("INTEGER");

                    b.Property<string>("Name")
                        .HasColumnType("TEXT");

                    b.Property<string>("Style")
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.HasIndex("ManagerId");

                    b.ToTable("Bands");
                });

            modelBuilder.Entity("TourManager.Data.Core.Domain.Contact", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("Email")
                        .HasColumnType("TEXT");

                    b.Property<string>("FirstName")
                        .HasColumnType("TEXT");

                    b.Property<DateTime>("Inserted")
                        .HasColumnType("TEXT");

                    b.Property<string>("LastName")
                        .HasColumnType("TEXT");

                    b.Property<DateTime>("LastUpdate")
                        .HasColumnType("TEXT");

                    b.Property<string>("TelefonNumber")
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.ToTable("Contacts");
                });

            modelBuilder.Entity("TourManager.Data.Core.Domain.TouringDates", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<DateTime>("DateOfTour")
                        .HasColumnType("TEXT");

                    b.Property<DateTime>("Inserted")
                        .HasColumnType("TEXT");

                    b.Property<DateTime>("LastUpdate")
                        .HasColumnType("TEXT");

                    b.Property<int?>("ToursId")
                        .HasColumnType("INTEGER");

                    b.Property<int?>("venueId")
                        .HasColumnType("INTEGER");

                    b.HasKey("Id");

                    b.HasIndex("ToursId");

                    b.HasIndex("venueId");

                    b.ToTable("TouringDates");
                });

            modelBuilder.Entity("TourManager.Data.Core.Domain.Tours", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<DateTime>("Inserted")
                        .HasColumnType("TEXT");

                    b.Property<DateTime>("LastUpdate")
                        .HasColumnType("TEXT");

                    b.Property<string>("NameOfTour")
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.ToTable("Tours");
                });

            modelBuilder.Entity("TourManager.Data.Core.Domain.Venues", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("Address")
                        .HasColumnType("TEXT");

                    b.Property<DateTime>("Inserted")
                        .HasColumnType("TEXT");

                    b.Property<DateTime>("LastUpdate")
                        .HasColumnType("TEXT");

                    b.Property<string>("Name")
                        .HasColumnType("TEXT");

                    b.Property<string>("TelefonNumber")
                        .HasColumnType("TEXT");

                    b.Property<string>("contactPersons")
                        .HasColumnType("TEXT");

                    b.Property<DateTime>("curfView")
                        .HasColumnType("TEXT");

                    b.Property<DateTime>("loadIn")
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.ToTable("Venues");
                });

            modelBuilder.Entity("TourManager.Data.Core.Domain.Address", b =>
                {
                    b.HasOne("TourManager.Data.Core.Domain.Contact", null)
                        .WithMany("Address")
                        .HasForeignKey("ContactId");
                });

            modelBuilder.Entity("TourManager.Data.Core.Domain.Bands", b =>
                {
                    b.HasOne("TourManager.Data.Core.Domain.Contact", "Manager")
                        .WithMany()
                        .HasForeignKey("ManagerId");
                });

            modelBuilder.Entity("TourManager.Data.Core.Domain.TouringDates", b =>
                {
                    b.HasOne("TourManager.Data.Core.Domain.Tours", null)
                        .WithMany("TouringDates")
                        .HasForeignKey("ToursId");

                    b.HasOne("TourManager.Data.Core.Domain.Venues", "venue")
                        .WithMany()
                        .HasForeignKey("venueId");
                });
#pragma warning restore 612, 618
        }
    }
}
