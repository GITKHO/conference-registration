﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using conference_registration.data;

namespace conference_registration.data.Migrations
{
    [DbContext(typeof(ConferenceContext))]
    partial class ConferenceContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.2.4-servicing-10062")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("conference_registration.core.Entities.ConferenceAggregate.Conference", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Description");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(400);

                    b.HasKey("Id");

                    b.ToTable("Conferences");
                });

            modelBuilder.Entity("conference_registration.core.Entities.ConferenceAggregate.Session", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int?>("ConferenceId");

                    b.Property<DateTime>("EndTime");

                    b.Property<DateTime>("StartTime");

                    b.Property<string>("Topic");

                    b.HasKey("Id");

                    b.HasIndex("ConferenceId");

                    b.ToTable("Sessions");
                });

            modelBuilder.Entity("conference_registration.core.Entities.RegistrationAggregate.Attendee", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("AddressLine1");

                    b.Property<string>("AddressLine2");

                    b.Property<string>("City");

                    b.Property<string>("Company");

                    b.Property<string>("Country");

                    b.Property<string>("Department");

                    b.Property<string>("Email");

                    b.Property<string>("Fax");

                    b.Property<string>("FirstName");

                    b.Property<bool>("IndividualBooking");

                    b.Property<string>("LastName");

                    b.Property<string>("MobilePhone");

                    b.Property<string>("Position");

                    b.Property<string>("PostalCode");

                    b.Property<bool>("TermsAndConditions");

                    b.Property<string>("Title");

                    b.Property<string>("Workphone");

                    b.HasKey("Id");

                    b.ToTable("Attendees");
                });

            modelBuilder.Entity("conference_registration.core.Entities.RegistrationAggregate.AttendeeSessionRegistration", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int?>("RegistrationId");

                    b.Property<int>("SessionId");

                    b.HasKey("Id");

                    b.HasIndex("RegistrationId");

                    b.HasIndex("SessionId");

                    b.ToTable("AttendeeSessionRegistrations");
                });

            modelBuilder.Entity("conference_registration.core.Entities.RegistrationAggregate.Registration", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("AttendeeId");

                    b.Property<int>("ConferenceId");

                    b.HasKey("Id");

                    b.HasIndex("AttendeeId");

                    b.ToTable("Registrations");
                });

            modelBuilder.Entity("conference_registration.core.Entities.ConferenceAggregate.Session", b =>
                {
                    b.HasOne("conference_registration.core.Entities.ConferenceAggregate.Conference")
                        .WithMany("Sessions")
                        .HasForeignKey("ConferenceId");
                });

            modelBuilder.Entity("conference_registration.core.Entities.RegistrationAggregate.AttendeeSessionRegistration", b =>
                {
                    b.HasOne("conference_registration.core.Entities.RegistrationAggregate.Registration")
                        .WithMany("AttendingSessions")
                        .HasForeignKey("RegistrationId");

                    b.HasOne("conference_registration.core.Entities.ConferenceAggregate.Session", "Session")
                        .WithMany()
                        .HasForeignKey("SessionId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("conference_registration.core.Entities.RegistrationAggregate.Registration", b =>
                {
                    b.HasOne("conference_registration.core.Entities.RegistrationAggregate.Attendee", "Attendee")
                        .WithMany()
                        .HasForeignKey("AttendeeId")
                        .OnDelete(DeleteBehavior.Cascade);
                });
#pragma warning restore 612, 618
        }
    }
}
