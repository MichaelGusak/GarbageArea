using Microsoft.EntityFrameworkCore.Migrations;

namespace GarbageArea.WebService.Migrations
{
    public partial class Initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "TransportOrganizations",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Name = table.Column<string>(nullable: true),
                    WebSite = table.Column<string>(nullable: true),
                    TimeZone = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TransportOrganizations", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Routes",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Number = table.Column<string>(nullable: true),
                    Name = table.Column<string>(nullable: true),
                    OrganizationId = table.Column<long>(nullable: true),
                    Type = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Routes", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Routes_TransportOrganizations_OrganizationId",
                        column: x => x.OrganizationId,
                        principalTable: "TransportOrganizations",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.InsertData(
                table: "TransportOrganizations",
                columns: new[] { "Id", "Name", "TimeZone", "WebSite" },
                values: new object[] { 1L, "ООО \"Трансавтолиз\"", "Europe/Moscow", "http://avtoline.ru" });

            migrationBuilder.InsertData(
                table: "TransportOrganizations",
                columns: new[] { "Id", "Name", "TimeZone", "WebSite" },
                values: new object[] { 2L, "ГУП \"Мосгортранс\"", "Europe/Moscow", "http://mosgortrans.ru" });

            migrationBuilder.InsertData(
                table: "Routes",
                columns: new[] { "Id", "Name", "Number", "OrganizationId", "Type" },
                values: new object[] { 1L, "Метро \"Войковская\" - Станция Ховрино", "591", 1L, 0 });

            migrationBuilder.InsertData(
                table: "Routes",
                columns: new[] { "Id", "Name", "Number", "OrganizationId", "Type" },
                values: new object[] { 2L, "Метро \"Селигерская\" - Станция Ховрино", "191", 1L, 0 });

            migrationBuilder.InsertData(
                table: "Routes",
                columns: new[] { "Id", "Name", "Number", "OrganizationId", "Type" },
                values: new object[] { 3L, "Метро \"Селигерская\" - Станция Ховрино", "215к", 2L, 0 });

            migrationBuilder.InsertData(
                table: "Routes",
                columns: new[] { "Id", "Name", "Number", "OrganizationId", "Type" },
                values: new object[] { 4L, "Метро \"Сокол\" - Улица Генерала Глаголева", "59", 2L, 1 });

            migrationBuilder.CreateIndex(
                name: "IX_Routes_OrganizationId",
                table: "Routes",
                column: "OrganizationId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Routes");

            migrationBuilder.DropTable(
                name: "TransportOrganizations");
        }
    }
}
