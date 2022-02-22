﻿using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace EventRegistrationSystem.Migrations
{
    public partial class create_tbl : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "T_Event_Registration",
                columns: table => new
                {
                    booking_id = table.Column<double>(type: "float", nullable: false),
                    customer_id = table.Column<double>(type: "float", nullable: false),
                    event_id = table.Column<double>(type: "float", nullable: false),
                    event_datetime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    booking_seat_count = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_T_Event_Registration", x => x.booking_id);
                });

            migrationBuilder.CreateTable(
                name: "T_Permissions",
                columns: table => new
                {
                    permission_id = table.Column<double>(type: "float", nullable: false),
                    permission_description = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_T_Permissions", x => x.permission_id);
                });

            migrationBuilder.CreateTable(
                name: "T_Ref_Event_Type",
                columns: table => new
                {
                    event_type_code = table.Column<double>(type: "float", nullable: false),
                    event_type_description = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_T_Ref_Event_Type", x => x.event_type_code);
                });

            migrationBuilder.CreateTable(
                name: "T_Customers",
                columns: table => new
                {
                    customer_id = table.Column<double>(type: "float", nullable: false),
                    customer_permission_id = table.Column<double>(type: "float", nullable: false),
                    perrmissionpermission_id = table.Column<double>(type: "float", nullable: true),
                    customer_name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    customer_phone = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    customer_email = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_T_Customers", x => x.customer_id);
                    table.ForeignKey(
                        name: "FK_T_Customers_T_Permissions_perrmissionpermission_id",
                        column: x => x.perrmissionpermission_id,
                        principalTable: "T_Permissions",
                        principalColumn: "permission_id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "T_Events",
                columns: table => new
                {
                    event_id = table.Column<double>(type: "float", nullable: false),
                    event_type_code = table.Column<double>(type: "float", nullable: false),
                    event_type_code1 = table.Column<double>(type: "float", nullable: true),
                    event_name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    event_start_date = table.Column<DateTime>(type: "datetime2", nullable: false),
                    event_end_date = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_T_Events", x => x.event_id);
                    table.ForeignKey(
                        name: "FK_T_Events_T_Ref_Event_Type_event_type_code1",
                        column: x => x.event_type_code1,
                        principalTable: "T_Ref_Event_Type",
                        principalColumn: "event_type_code",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_T_Customers_perrmissionpermission_id",
                table: "T_Customers",
                column: "perrmissionpermission_id");

            migrationBuilder.CreateIndex(
                name: "IX_T_Events_event_type_code1",
                table: "T_Events",
                column: "event_type_code1");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "T_Customers");

            migrationBuilder.DropTable(
                name: "T_Event_Registration");

            migrationBuilder.DropTable(
                name: "T_Events");

            migrationBuilder.DropTable(
                name: "T_Permissions");

            migrationBuilder.DropTable(
                name: "T_Ref_Event_Type");
        }
    }
}
