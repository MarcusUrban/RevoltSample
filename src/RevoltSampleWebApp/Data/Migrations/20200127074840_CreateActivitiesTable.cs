using Microsoft.EntityFrameworkCore.Migrations;

namespace RevoltSampleWebApp.Data.Migrations
{
    public partial class CreateActivitiesTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "ID1",
                table: "AspNetUsers",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ID2",
                table: "AspNetUsers",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "Activities",
                columns: table => new
                {
                    ActivityId = table.Column<string>(nullable: false),
                    Timestamp = table.Column<int>(nullable: false),
                    ApplicationUserID = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Activities", x => x.ActivityId);
                    table.ForeignKey(
                        name: "FK_Activities_AspNetUsers_ApplicationUserID",
                        column: x => x.ApplicationUserID,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Activities_ApplicationUserID",
                table: "Activities",
                column: "ApplicationUserID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Activities");

            migrationBuilder.DropColumn(
                name: "ID1",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "ID2",
                table: "AspNetUsers");
        }
    }
}
