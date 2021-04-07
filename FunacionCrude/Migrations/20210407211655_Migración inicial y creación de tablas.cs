using Microsoft.EntityFrameworkCore.Migrations;

namespace FunacionCrude.Migrations
{
    public partial class Migracióninicialycreacióndetablas : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Padrinos",
                columns: table => new
                {
                    PadrinoId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nombre = table.Column<string>(nullable: true),
                    Correo = table.Column<string>(nullable: false),
                    Contraseña = table.Column<string>(nullable: false),
                    Edad = table.Column<int>(nullable: false),
                    Profesion = table.Column<string>(nullable: true),
                    UsuarioId = table.Column<int>(nullable: false),
                    Descripcion = table.Column<string>(type: "nvarchar(250)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Padrinos", x => x.PadrinoId);
                });

            migrationBuilder.CreateTable(
                name: "Usuarios",
                columns: table => new
                {
                    UsuarioId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Correo = table.Column<string>(nullable: true),
                    RolId = table.Column<int>(nullable: false),
                    Estado = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Usuarios", x => x.UsuarioId);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Padrinos");

            migrationBuilder.DropTable(
                name: "Usuarios");
        }
    }
}
