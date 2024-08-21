using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace HotelReservationSystem.Migrations
{
    /// <inheritdoc />
    public partial class faciltyRoomRelation : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Rooms_Facilities_FacilitiesID",
                table: "Rooms");

            migrationBuilder.DropIndex(
                name: "IX_Rooms_FacilitiesID",
                table: "Rooms");

            migrationBuilder.DropColumn(
                name: "FacilitiesID",
                table: "Rooms");

            migrationBuilder.DropColumn(
                name: "AirConditioning",
                table: "Facilities");

            migrationBuilder.DropColumn(
                name: "TV",
                table: "Facilities");

            migrationBuilder.DropColumn(
                name: "WI_FI",
                table: "Facilities");

            migrationBuilder.AddColumn<string>(
                name: "Name",
                table: "Facilities",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.CreateTable(
                name: "RoomsFacilities",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RoomID = table.Column<int>(type: "int", nullable: false),
                    FacilityID = table.Column<int>(type: "int", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RoomsFacilities", x => x.ID);
                    table.ForeignKey(
                        name: "FK_RoomsFacilities_Facilities_FacilityID",
                        column: x => x.FacilityID,
                        principalTable: "Facilities",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_RoomsFacilities_Rooms_RoomID",
                        column: x => x.RoomID,
                        principalTable: "Rooms",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_RoomsFacilities_FacilityID",
                table: "RoomsFacilities",
                column: "FacilityID");

            migrationBuilder.CreateIndex(
                name: "IX_RoomsFacilities_RoomID",
                table: "RoomsFacilities",
                column: "RoomID");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "RoomsFacilities");

            migrationBuilder.DropColumn(
                name: "Name",
                table: "Facilities");

            migrationBuilder.AddColumn<int>(
                name: "FacilitiesID",
                table: "Rooms",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<bool>(
                name: "AirConditioning",
                table: "Facilities",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "TV",
                table: "Facilities",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "WI_FI",
                table: "Facilities",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.CreateIndex(
                name: "IX_Rooms_FacilitiesID",
                table: "Rooms",
                column: "FacilitiesID");

            migrationBuilder.AddForeignKey(
                name: "FK_Rooms_Facilities_FacilitiesID",
                table: "Rooms",
                column: "FacilitiesID",
                principalTable: "Facilities",
                principalColumn: "ID",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
