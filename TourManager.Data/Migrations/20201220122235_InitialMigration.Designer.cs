﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using TourManager.Data.Core.Configuration;

namespace TourManager.Data.Migrations
{
    [DbContext(typeof(TourManagerContext))]
    [Migration("20201220122235_InitialMigration")]
    partial class InitialMigration
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
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

                    b.Property<int?>("VenueId")
                        .HasColumnType("INTEGER");

                    b.HasKey("Id");

                    b.HasIndex("ContactId");

                    b.HasIndex("VenueId");

                    b.ToTable("Address");
                });

            modelBuilder.Entity("TourManager.Data.Core.Domain.Band", b =>
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

                    b.HasKey("Id");

                    b.HasIndex("AddressId");

                    b.HasIndex("ManagerId");

                    b.ToTable("Bands");
                });

            modelBuilder.Entity("TourManager.Data.Core.Domain.Contact", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<int?>("BandId")
                        .HasColumnType("INTEGER");

                    b.Property<string>("FirstName")
                        .HasColumnType("TEXT");

                    b.Property<DateTime>("Inserted")
                        .HasColumnType("TEXT");

                    b.Property<string>("LastName")
                        .HasColumnType("TEXT");

                    b.Property<DateTime>("LastUpdate")
                        .HasColumnType("TEXT");

                    b.Property<int?>("VenueId")
                        .HasColumnType("INTEGER");

                    b.HasKey("Id");

                    b.HasIndex("BandId");

                    b.ToTable("Contacts");
                });

            modelBuilder.Entity("TourManager.Data.Core.Domain.Email", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<int?>("BandId")
                        .HasColumnType("INTEGER");

                    b.Property<int?>("ContactId")
                        .HasColumnType("INTEGER");

                    b.Property<string>("EmailAddress")
                        .HasColumnType("TEXT");

                    b.Property<DateTime>("Inserted")
                        .HasColumnType("TEXT");

                    b.Property<DateTime>("LastUpdate")
                        .HasColumnType("TEXT");

                    b.Property<int?>("VenueId")
                        .HasColumnType("INTEGER");

                    b.HasKey("Id");

                    b.HasIndex("BandId");

                    b.HasIndex("ContactId");

                    b.HasIndex("VenueId");

                    b.ToTable("Emails");
                });

            modelBuilder.Entity("TourManager.Data.Core.Domain.TelephoneNumber", b =>
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

                    b.Property<int?>("VenueId")
                        .HasColumnType("INTEGER");

                    b.HasKey("Id");

                    b.HasIndex("ContactId");

                    b.HasIndex("VenueId");

                    b.ToTable("TelephoneNumbers");
                });

            modelBuilder.Entity("TourManager.Data.Core.Domain.Tour", b =>
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

            modelBuilder.Entity("TourManager.Data.Core.Domain.TouringDate", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<int?>("BandId")
                        .HasColumnType("INTEGER");

                    b.Property<DateTime>("DateOfTour")
                        .HasColumnType("TEXT");

                    b.Property<DateTime>("Inserted")
                        .HasColumnType("TEXT");

                    b.Property<DateTime>("LastUpdate")
                        .HasColumnType("TEXT");

                    b.Property<int?>("TourId")
                        .HasColumnType("INTEGER");

                    b.Property<int?>("VenueId")
                        .HasColumnType("INTEGER");

                    b.HasKey("Id");

                    b.HasIndex("BandId");

                    b.HasIndex("TourId");

                    b.HasIndex("VenueId");

                    b.ToTable("TouringDates");
                });

            modelBuilder.Entity("TourManager.Data.Core.Domain.Venue", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<TimeSpan>("CurfView")
                        .HasColumnType("TEXT");

                    b.Property<DateTime>("Inserted")
                        .HasColumnType("TEXT");

                    b.Property<DateTime>("LastUpdate")
                        .HasColumnType("TEXT");

                    b.Property<TimeSpan>("LoadIn")
                        .HasColumnType("TEXT");

                    b.Property<int>("MaxCapacity")
                        .HasColumnType("INTEGER");

                    b.Property<string>("Name")
                        .HasColumnType("TEXT");

                    b.Property<string>("Notes")
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.ToTable("Venues");
                });

            modelBuilder.Entity("TourManager.Data.Core.Domain.VenuesToContacts", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<int>("ContactId")
                        .HasColumnType("INTEGER");

                    b.Property<DateTime>("Inserted")
                        .HasColumnType("TEXT");

                    b.Property<DateTime>("LastUpdate")
                        .HasColumnType("TEXT");

                    b.Property<int>("VenueId")
                        .HasColumnType("INTEGER");

                    b.HasKey("Id");

                    b.HasIndex("ContactId");

                    b.HasIndex("VenueId");

                    b.ToTable("VenuesToContacts");
                });

            modelBuilder.Entity("TourManager.Data.Core.Domain.Address", b =>
                {
                    b.HasOne("TourManager.Data.Core.Domain.Contact", null)
                        .WithMany("Addresses")
                        .HasForeignKey("ContactId");

                    b.HasOne("TourManager.Data.Core.Domain.Venue", null)
                        .WithMany("Addresses")
                        .HasForeignKey("VenueId");
                });

            modelBuilder.Entity("TourManager.Data.Core.Domain.Band", b =>
                {
                    b.HasOne("TourManager.Data.Core.Domain.Address", "Address")
                        .WithMany()
                        .HasForeignKey("AddressId");

                    b.HasOne("TourManager.Data.Core.Domain.Contact", "Manager")
                        .WithMany()
                        .HasForeignKey("ManagerId");
                });

            modelBuilder.Entity("TourManager.Data.Core.Domain.Contact", b =>
                {
                    b.HasOne("TourManager.Data.Core.Domain.Band", null)
                        .WithMany("Members")
                        .HasForeignKey("BandId");
                });

            modelBuilder.Entity("TourManager.Data.Core.Domain.Email", b =>
                {
                    b.HasOne("TourManager.Data.Core.Domain.Band", null)
                        .WithMany("Emails")
                        .HasForeignKey("BandId");

                    b.HasOne("TourManager.Data.Core.Domain.Contact", null)
                        .WithMany("Emails")
                        .HasForeignKey("ContactId");

                    b.HasOne("TourManager.Data.Core.Domain.Venue", null)
                        .WithMany("Emails")
                        .HasForeignKey("VenueId");
                });

            modelBuilder.Entity("TourManager.Data.Core.Domain.TelephoneNumber", b =>
                {
                    b.HasOne("TourManager.Data.Core.Domain.Contact", null)
                        .WithMany("TelephoneNumbers")
                        .HasForeignKey("ContactId");

                    b.HasOne("TourManager.Data.Core.Domain.Venue", null)
                        .WithMany("TelephoneNumbers")
                        .HasForeignKey("VenueId");
                });

            modelBuilder.Entity("TourManager.Data.Core.Domain.TouringDate", b =>
                {
                    b.HasOne("TourManager.Data.Core.Domain.Band", "Band")
                        .WithMany()
                        .HasForeignKey("BandId");

                    b.HasOne("TourManager.Data.Core.Domain.Tour", null)
                        .WithMany("TouringDates")
                        .HasForeignKey("TourId");

                    b.HasOne("TourManager.Data.Core.Domain.Venue", "Venue")
                        .WithMany()
                        .HasForeignKey("VenueId");
                });

            modelBuilder.Entity("TourManager.Data.Core.Domain.VenuesToContacts", b =>
                {
                    b.HasOne("TourManager.Data.Core.Domain.Contact", "Contact")
                        .WithMany("VenuesToContacts")
                        .HasForeignKey("ContactId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("TourManager.Data.Core.Domain.Venue", "Venue")
                        .WithMany("VenuesToContacts")
                        .HasForeignKey("VenueId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });
#pragma warning restore 612, 618
        }
    }
}
