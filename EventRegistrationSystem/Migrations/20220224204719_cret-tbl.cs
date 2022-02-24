using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace EventRegistrationSystem.Migrations
{
    public partial class crettbl : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "T_Permissions",
                columns: table => new
                {
                    permission_id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
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
                    event_type_code = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    event_type_description = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_T_Ref_Event_Type", x => x.event_type_code);
                });

            migrationBuilder.CreateTable(
                name: "T_Events",
                columns: table => new
                {
                    event_id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Ref_Event_Type = table.Column<int>(type: "int", nullable: true),
                    event_name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    event_start_date = table.Column<DateTime>(type: "datetime2", nullable: false),
                    event_end_date = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_T_Events", x => x.event_id);
                    table.ForeignKey(
                        name: "FK_T_Events_T_Ref_Event_Type_Ref_Event_Type",
                        column: x => x.Ref_Event_Type,
                        principalTable: "T_Ref_Event_Type",
                        principalColumn: "event_type_code",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "T_Event_Registration",
                columns: table => new
                {
                    booking_id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    event_id = table.Column<int>(type: "int", nullable: false),
                    event_datetime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    booking_seat_count = table.Column<int>(type: "int", nullable: false),
                    customer_email_phonenumber = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    identificationd_id = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    permission_id = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_T_Event_Registration", x => x.booking_id);
                    table.ForeignKey(
                        name: "FK_T_Event_Registration_T_Events_event_id",
                        column: x => x.event_id,
                        principalTable: "T_Events",
                        principalColumn: "event_id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_T_Event_Registration_T_Permissions_permission_id",
                        column: x => x.permission_id,
                        principalTable: "T_Permissions",
                        principalColumn: "permission_id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_T_Event_Registration_event_id",
                table: "T_Event_Registration",
                column: "event_id");

            migrationBuilder.CreateIndex(
                name: "IX_T_Event_Registration_permission_id",
                table: "T_Event_Registration",
                column: "permission_id");

            migrationBuilder.CreateIndex(
                name: "IX_T_Events_Ref_Event_Type",
                table: "T_Events",
                column: "Ref_Event_Type");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
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
