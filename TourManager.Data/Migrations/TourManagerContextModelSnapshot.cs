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

                    b.Property<string>("City")
                        .HasColumnType("TEXT");

                    b.Property<int?>("ContactId")
                        .HasColumnType("INTEGER");

                    b.Property<string>("Country")
                        .HasColumnType("TEXT");

                    b.Property<string>("ExtranInfo")
                        .HasColumnType("TEXT");

                    b.Property<string>("HouseNameOrNumber")
                        .HasColumnType("TEXT");

                    b.Property<DateTime>("Inserted")
                        .HasColumnType("TEXT");

                    b.Property<DateTime>("LastUpdate")
                        .HasColumnType("TEXT");

                    b.Property<string>("PostalZip")
                        .HasColumnType("TEXT");

                    b.Property<string>("Street")
                        .HasColumnType("TEXT");

                    b.Property<int?>("VenuesId")
                        .HasColumnType("INTEGER");

                    b.HasKey("Id");

                    b.HasIndex("ContactId");

                    b.HasIndex("VenuesId");

                    b.ToTable("Address");
                });

            modelBuilder.Entity("TourManager.Data.Core.Domain.Bands", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<int?>("AddressId")
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

                    b.Property<int?>("ToursId")
                        .HasColumnType("INTEGER");

                    b.HasKey("Id");

                    b.HasIndex("AddressId");

                    b.HasIndex("ManagerId");

                    b.HasIndex("ToursId");

                    b.ToTable("Bands");
                });

            modelBuilder.Entity("TourManager.Data.Core.Domain.Contact", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<int?>("BandsId")
                        .HasColumnType("INTEGER");

                    b.Property<string>("FirstName")
                        .HasColumnType("TEXT");

                    b.Property<DateTime>("Inserted")
                        .HasColumnType("TEXT");

                    b.Property<string>("LastName")
                        .HasColumnType("TEXT");

                    b.Property<DateTime>("LastUpdate")
                        .HasColumnType("TEXT");

                    b.Property<int?>("VenuesId")
                        .HasColumnType("INTEGER");

                    b.HasKey("Id");

                    b.HasIndex("BandsId");

                    b.HasIndex("VenuesId");

                    b.ToTable("Contacts");
                });

            modelBuilder.Entity("TourManager.Data.Core.Domain.Emails", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<int?>("BandsId")
                        .HasColumnType("INTEGER");

                    b.Property<int?>("ContactId")
                        .HasColumnType("INTEGER");

                    b.Property<string>("EmailAddress")
                        .HasColumnType("TEXT");

                    b.Property<DateTime>("Inserted")
                        .HasColumnType("TEXT");

                    b.Property<DateTime>("LastUpdate")
                        .HasColumnType("TEXT");

                    b.Property<int?>("VenuesId")
                        .HasColumnType("INTEGER");

                    b.HasKey("Id");

                    b.HasIndex("BandsId");

                    b.HasIndex("ContactId");

                    b.HasIndex("VenuesId");

                    b.ToTable("Emails");
                });

            modelBuilder.Entity("TourManager.Data.Core.Domain.TelefonNumbers", b =>
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

                    b.Property<string>("Number")
                        .HasColumnType("TEXT");

                    b.Property<int?>("VenuesId")
                        .HasColumnType("INTEGER");

                    b.HasKey("Id");

                    b.HasIndex("ContactId");

                    b.HasIndex("VenuesId");

                    b.ToTable("TelefonNumbers");
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

                    b.HasKey("Id");

                    b.HasIndex("ToursId");

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

                    b.Property<DateTime>("Inserted")
                        .HasColumnType("TEXT");

                    b.Property<DateTime>("LastUpdate")
                        .HasColumnType("TEXT");

                    b.Property<string>("Name")
                        .HasColumnType("TEXT");

                    b.Property<int?>("TouringDatesId")
                        .HasColumnType("INTEGER");

                    b.Property<DateTime>("curfView")
                        .HasColumnType("TEXT");

                    b.Property<DateTime>("loadIn")
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.HasIndex("TouringDatesId");

                    b.ToTable("Venues");
                });

            modelBuilder.Entity("TourManager.Data.Core.Domain.Address", b =>
                {
                    b.HasOne("TourManager.Data.Core.Domain.Contact", null)
                        .WithMany("Addresses")
                        .HasForeignKey("ContactId");

                    b.HasOne("TourManager.Data.Core.Domain.Venues", null)
                        .WithMany("Addresses")
                        .HasForeignKey("VenuesId");
                });

            modelBuilder.Entity("TourManager.Data.Core.Domain.Bands", b =>
                {
                    b.HasOne("TourManager.Data.Core.Domain.Address", "Address")
                        .WithMany()
                        .HasForeignKey("AddressId");

                    b.HasOne("TourManager.Data.Core.Domain.Contact", "Manager")
                        .WithMany()
                        .HasForeignKey("ManagerId");

                    b.HasOne("TourManager.Data.Core.Domain.Tours", null)
                        .WithMany("Bands")
                        .HasForeignKey("ToursId");
                });

            modelBuilder.Entity("TourManager.Data.Core.Domain.Contact", b =>
                {
                    b.HasOne("TourManager.Data.Core.Domain.Bands", null)
                        .WithMany("Members")
                        .HasForeignKey("BandsId");

                    b.HasOne("TourManager.Data.Core.Domain.Venues", null)
                        .WithMany("Contact")
                        .HasForeignKey("VenuesId");
                });

            modelBuilder.Entity("TourManager.Data.Core.Domain.Emails", b =>
                {
                    b.HasOne("TourManager.Data.Core.Domain.Bands", null)
                        .WithMany("Emails")
                        .HasForeignKey("BandsId");

                    b.HasOne("TourManager.Data.Core.Domain.Contact", null)
                        .WithMany("Emails")
                        .HasForeignKey("ContactId");

                    b.HasOne("TourManager.Data.Core.Domain.Venues", null)
                        .WithMany("Emails")
                        .HasForeignKey("VenuesId");
                });

            modelBuilder.Entity("TourManager.Data.Core.Domain.TelefonNumbers", b =>
                {
                    b.HasOne("TourManager.Data.Core.Domain.Contact", null)
                        .WithMany("TelefonNumbers")
                        .HasForeignKey("ContactId");

                    b.HasOne("TourManager.Data.Core.Domain.Venues", null)
                        .WithMany("TelefonNumbers")
                        .HasForeignKey("VenuesId");
                });

            modelBuilder.Entity("TourManager.Data.Core.Domain.TouringDates", b =>
                {
                    b.HasOne("TourManager.Data.Core.Domain.Tours", null)
                        .WithMany("TouringDates")
                        .HasForeignKey("ToursId");
                });

            modelBuilder.Entity("TourManager.Data.Core.Domain.Venues", b =>
                {
                    b.HasOne("TourManager.Data.Core.Domain.TouringDates", null)
                        .WithMany("Venues")
                        .HasForeignKey("TouringDatesId");
                });
#pragma warning restore 612, 618
        }
    }
}
