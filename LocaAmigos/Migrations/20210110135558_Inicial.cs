using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

namespace LocaAmigos.Migrations
{
    public partial class Inicial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "jogos",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    nome = table.Column<string>(type: "text", nullable: true),
                    tipojogo = table.Column<string>(type: "text", nullable: true),
                    ativo = table.Column<bool>(type: "boolean", nullable: false),
                    created = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    update = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    remove = table.Column<DateTime>(type: "timestamp without time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_jogos", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "pessoa",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    nome = table.Column<string>(type: "text", nullable: true),
                    nomecompleto = table.Column<string>(type: "text", nullable: true),
                    datanascimento = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    created = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    update = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    remove = table.Column<DateTime>(type: "timestamp without time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_pessoa", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "usuario",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    email = table.Column<string>(type: "text", nullable: true),
                    senha = table.Column<string>(type: "text", nullable: true),
                    ativo = table.Column<bool>(type: "boolean", nullable: false),
                    Pessoaid = table.Column<int>(type: "integer", nullable: true),
                    created = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    update = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    remove = table.Column<DateTime>(type: "timestamp without time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_usuario", x => x.id);
                    table.ForeignKey(
                        name: "FK_usuario_pessoa_Pessoaid",
                        column: x => x.Pessoaid,
                        principalTable: "pessoa",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "movimentacoes",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    inicio = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    fim = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    ativo = table.Column<bool>(type: "boolean", nullable: false),
                    Jogosid = table.Column<int>(type: "integer", nullable: true),
                    Pessoaid = table.Column<int>(type: "integer", nullable: true),
                    Usuarioid = table.Column<int>(type: "integer", nullable: true),
                    created = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    update = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    remove = table.Column<DateTime>(type: "timestamp without time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_movimentacoes", x => x.id);
                    table.ForeignKey(
                        name: "FK_movimentacoes_jogos_Jogosid",
                        column: x => x.Jogosid,
                        principalTable: "jogos",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_movimentacoes_pessoa_Pessoaid",
                        column: x => x.Pessoaid,
                        principalTable: "pessoa",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_movimentacoes_usuario_Usuarioid",
                        column: x => x.Usuarioid,
                        principalTable: "usuario",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_movimentacoes_Jogosid",
                table: "movimentacoes",
                column: "Jogosid");

            migrationBuilder.CreateIndex(
                name: "IX_movimentacoes_Pessoaid",
                table: "movimentacoes",
                column: "Pessoaid");

            migrationBuilder.CreateIndex(
                name: "IX_movimentacoes_Usuarioid",
                table: "movimentacoes",
                column: "Usuarioid");

            migrationBuilder.CreateIndex(
                name: "IX_usuario_Pessoaid",
                table: "usuario",
                column: "Pessoaid");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "movimentacoes");

            migrationBuilder.DropTable(
                name: "jogos");

            migrationBuilder.DropTable(
                name: "usuario");

            migrationBuilder.DropTable(
                name: "pessoa");
        }
    }
}
