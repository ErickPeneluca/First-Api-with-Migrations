using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Usuario.Migrations
{
    public partial class AtualizacaoUsuario : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_Users",
                table: "Users");

            migrationBuilder.RenameTable(
                name: "Users",
                newName: "tb_users");

            migrationBuilder.RenameColumn(
                name: "Nome",
                table: "tb_users",
                newName: "nome");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "tb_users",
                newName: "id");

            migrationBuilder.RenameColumn(
                name: "DataNascimento",
                table: "tb_users",
                newName: "data_nascimento");

            migrationBuilder.AddPrimaryKey(
                name: "PK_tb_users",
                table: "tb_users",
                column: "id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_tb_users",
                table: "tb_users");

            migrationBuilder.RenameTable(
                name: "tb_users",
                newName: "Users");

            migrationBuilder.RenameColumn(
                name: "nome",
                table: "Users",
                newName: "Nome");

            migrationBuilder.RenameColumn(
                name: "id",
                table: "Users",
                newName: "Id");

            migrationBuilder.RenameColumn(
                name: "data_nascimento",
                table: "Users",
                newName: "DataNascimento");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Users",
                table: "Users",
                column: "Id");
        }
    }
}
