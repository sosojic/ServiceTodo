using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ApiTodo.Migrations
{
    /// <inheritdoc />
    public partial class InitialeCreate2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "AgendaId",
                table: "Todo",
                type: "INTEGER",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "Agenda",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Nom = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Agenda", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Todo_AgendaId",
                table: "Todo",
                column: "AgendaId");

            migrationBuilder.AddForeignKey(
                name: "FK_Todo_Agenda_AgendaId",
                table: "Todo",
                column: "AgendaId",
                principalTable: "Agenda",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Todo_Agenda_AgendaId",
                table: "Todo");

            migrationBuilder.DropTable(
                name: "Agenda");

            migrationBuilder.DropIndex(
                name: "IX_Todo_AgendaId",
                table: "Todo");

            migrationBuilder.DropColumn(
                name: "AgendaId",
                table: "Todo");
        }
    }
}
