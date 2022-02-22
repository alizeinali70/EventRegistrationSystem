﻿// <auto-generated />
using System;
using EventRegistrationSystem.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace EventRegistrationSystem.Migrations
{
    [DbContext(typeof(CompanyContext))]
    [Migration("20220222070918_create_tbl")]
    partial class create_tbl
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.6")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("EventRegistrationSystemModels.Customers", b =>
                {
                    b.Property<double>("customer_id")
                        .HasColumnType("float");

                    b.Property<string>("customer_email")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("customer_name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<double>("customer_permission_id")
                        .HasColumnType("float");

                    b.Property<string>("customer_phone")
                        .HasColumnType("nvarchar(max)");

                    b.Property<double?>("perrmissionpermission_id")
                        .HasColumnType("float");

                    b.HasKey("customer_id");

                    b.HasIndex("perrmissionpermission_id");

                    b.ToTable("T_Customers");
                });

            modelBuilder.Entity("EventRegistrationSystemModels.Event_Registration", b =>
                {
                    b.Property<double>("booking_id")
                        .HasColumnType("float");

                    b.Property<int>("booking_seat_count")
                        .HasColumnType("int");

                    b.Property<double>("customer_id")
                        .HasColumnType("float");

                    b.Property<DateTime>("event_datetime")
                        .HasColumnType("datetime2");

                    b.Property<double>("event_id")
                        .HasColumnType("float");

                    b.HasKey("booking_id");

                    b.ToTable("T_Event_Registration");
                });

            modelBuilder.Entity("EventRegistrationSystemModels.Events", b =>
                {
                    b.Property<double>("event_id")
                        .HasColumnType("float");

                    b.Property<DateTime>("event_end_date")
                        .HasColumnType("datetime2");

                    b.Property<string>("event_name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("event_start_date")
                        .HasColumnType("datetime2");

                    b.Property<double>("event_type_code")
                        .HasColumnType("float");

                    b.Property<double?>("event_type_code1")
                        .HasColumnType("float");

                    b.HasKey("event_id");

                    b.HasIndex("event_type_code1");

                    b.ToTable("T_Events");
                });

            modelBuilder.Entity("EventRegistrationSystemModels.Permissions", b =>
                {
                    b.Property<double>("permission_id")
                        .HasColumnType("float");

                    b.Property<string>("permission_description")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("permission_id");

                    b.ToTable("T_Permissions");
                });

            modelBuilder.Entity("EventRegistrationSystemModels.Ref_Event_Type", b =>
                {
                    b.Property<double>("event_type_code")
                        .HasColumnType("float");

                    b.Property<string>("event_type_description")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("event_type_code");

                    b.ToTable("T_Ref_Event_Type");
                });

            modelBuilder.Entity("EventRegistrationSystemModels.Customers", b =>
                {
                    b.HasOne("EventRegistrationSystemModels.Permissions", "perrmission")
                        .WithMany()
                        .HasForeignKey("perrmissionpermission_id");

                    b.Navigation("perrmission");
                });

            modelBuilder.Entity("EventRegistrationSystemModels.Events", b =>
                {
                    b.HasOne("EventRegistrationSystemModels.Ref_Event_Type", "event_type")
                        .WithMany()
                        .HasForeignKey("event_type_code1");

                    b.Navigation("event_type");
                });
#pragma warning restore 612, 618
        }
    }
}
