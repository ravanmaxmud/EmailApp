using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EmailApp.Migrations
{
    /// <inheritdoc />
    public partial class Natification : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
    name: "natifications",
    columns: table => new
    {
        Id = table.Column<int>(type: "int", nullable: false)
            .Annotation("SqlServer:Identity", "1, 1"),
        Title = table.Column<string>(type: "nvarchar(max)", nullable: false),
        Content = table.Column<string>(type: "nvarchar(max)", nullable: false),
        FromEmail = table.Column<string>(type: "nvarchar(max)", nullable: false),
        TargetEmailId = table.Column<int>(type: "int", nullable: false)
    },
    constraints: table =>
    {
        table.PrimaryKey("PK_natifications", x => x.Id);
        table.ForeignKey(
            name: "FK_natifications_targetEmails_TargetEmailId",
            column: x => x.TargetEmailId,
            principalTable: "targetEmails",
            principalColumn: "Id",
            onDelete: ReferentialAction.Cascade);
    });

            migrationBuilder.CreateIndex(
                name: "IX_natifications_TargetEmailId",
                table: "natifications",
                column: "TargetEmailId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
    name: "natifications");
        }
    }
}
