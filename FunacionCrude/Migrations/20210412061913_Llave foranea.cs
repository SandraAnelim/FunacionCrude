using Microsoft.EntityFrameworkCore.Migrations;

namespace FunacionCrude.Migrations
{
    public partial class Llaveforanea : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "Descripcion",
                table: "Padrinos",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(250)",
                oldNullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Padrinos_UsuarioId",
                table: "Padrinos",
                column: "UsuarioId");

            migrationBuilder.AddForeignKey(
                name: "FK_Padrinos_Usuarios_UsuarioId",
                table: "Padrinos",
                column: "UsuarioId",
                principalTable: "Usuarios",
                principalColumn: "UsuarioId",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Padrinos_Usuarios_UsuarioId",
                table: "Padrinos");

            migrationBuilder.DropIndex(
                name: "IX_Padrinos_UsuarioId",
                table: "Padrinos");

            migrationBuilder.AlterColumn<string>(
                name: "Descripcion",
                table: "Padrinos",
                type: "nvarchar(250)",
                nullable: true,
                oldClrType: typeof(string),
                oldNullable: true);
        }
    }
}
