﻿using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace TaskManager.Infra.Data.Migrations
{
    /// <inheritdoc />
    public partial class CriacaoInicialDoBancoDeDados : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Projetos",
                columns: table => new
                {
                    ProjetoId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Nome = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Projetos", x => x.ProjetoId);
                });

            migrationBuilder.CreateTable(
                name: "Usuarios",
                columns: table => new
                {
                    UsuarioId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Nome = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Usuarios", x => x.UsuarioId);
                });

            migrationBuilder.CreateTable(
                name: "Tarefas",
                columns: table => new
                {
                    TarefaId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Titulo = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Descricao = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DataVencimento = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Status = table.Column<int>(type: "int", nullable: false),
                    Prioridade = table.Column<int>(type: "int", nullable: true),
                    Comentario = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ProjetoId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    UsuarioId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tarefas", x => x.TarefaId);
                    table.ForeignKey(
                        name: "FK_Tarefas_Projetos_ProjetoId",
                        column: x => x.ProjetoId,
                        principalTable: "Projetos",
                        principalColumn: "ProjetoId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Tarefas_Usuarios_UsuarioId",
                        column: x => x.UsuarioId,
                        principalTable: "Usuarios",
                        principalColumn: "UsuarioId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "HistoricoAlteracoes",
                columns: table => new
                {
                    HistoricoAlteracaoId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CampoAlterado = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Antes = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Depois = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DataAlteracao = table.Column<DateTime>(type: "datetime2", nullable: false),
                    TarefaId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_HistoricoAlteracoes", x => x.HistoricoAlteracaoId);
                    table.ForeignKey(
                        name: "FK_HistoricoAlteracoes_Tarefas_TarefaId",
                        column: x => x.TarefaId,
                        principalTable: "Tarefas",
                        principalColumn: "TarefaId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Projetos",
                columns: new[] { "ProjetoId", "Nome" },
                values: new object[,]
                {
                    { new Guid("3d490a70-94ce-4d15-9494-5248280c2ce3"), "Projeto X" },
                    { new Guid("c9d4c053-49b6-410c-bc78-2d54a9991870"), "Projeto Z" }
                });

            migrationBuilder.InsertData(
                table: "Usuarios",
                columns: new[] { "UsuarioId", "Nome" },
                values: new object[,]
                {
                    { new Guid("0f58ef89-c87e-4c09-a9ad-4cbc2f764aec"), "Jimmy Page" },
                    { new Guid("a69c1158-3c7e-4441-a3da-d060c2b5604c"), "Jimmy Hendrix" }
                });

            migrationBuilder.InsertData(
                table: "Tarefas",
                columns: new[] { "TarefaId", "Comentario", "DataVencimento", "Descricao", "Prioridade", "ProjetoId", "Status", "Titulo", "UsuarioId" },
                values: new object[,]
                {
                    { new Guid("80abbca8-664d-4b20-b5de-024705497d4a"), null, new DateTime(2024, 11, 16, 13, 4, 54, 753, DateTimeKind.Local).AddTicks(3568), "Essa é uma tarefa para realizar o cadastro de usuários no sistema", 2, new Guid("c9d4c053-49b6-410c-bc78-2d54a9991870"), 1, "Cadastrar Usuários no Sistema", new Guid("a69c1158-3c7e-4441-a3da-d060c2b5604c") },
                    { new Guid("86dba8c0-d178-41e7-938c-ed49778fb52a"), null, new DateTime(2024, 11, 21, 13, 4, 54, 753, DateTimeKind.Local).AddTicks(3586), "Essa é uma tarefa para criar uma nova sprint para o projeto", 1, new Guid("c9d4c053-49b6-410c-bc78-2d54a9991870"), 3, "Criar uma nova Sprint para o Projeto", new Guid("a69c1158-3c7e-4441-a3da-d060c2b5604c") },
                    { new Guid("88696b49-5c8c-4927-a0a5-cc756e0df8b9"), null, new DateTime(2024, 11, 21, 13, 4, 54, 753, DateTimeKind.Local).AddTicks(3591), "Essa é uma tarefa para versionar o código do projeto no GIT", 1, new Guid("c9d4c053-49b6-410c-bc78-2d54a9991870"), 3, "Versionar o código do projeto no GIT", new Guid("a69c1158-3c7e-4441-a3da-d060c2b5604c") },
                    { new Guid("88f32217-dfdf-4929-bf2d-0714d3178afa"), null, new DateTime(2024, 11, 21, 13, 4, 54, 753, DateTimeKind.Local).AddTicks(3594), "Essa é uma tarefa para cadastrar usuários no banco de dados", 1, new Guid("c9d4c053-49b6-410c-bc78-2d54a9991870"), 3, "Cadastrar Usuários no banco de dados", new Guid("a69c1158-3c7e-4441-a3da-d060c2b5604c") },
                    { new Guid("a39740f1-2ad5-4a15-95b1-52bcb0530728"), null, new DateTime(2024, 11, 26, 13, 4, 54, 753, DateTimeKind.Local).AddTicks(3597), "Essa é uma tarefa para migrar o banco de dados", 3, new Guid("3d490a70-94ce-4d15-9494-5248280c2ce3"), 2, "Migar o banco de dados SQL Server para o DynamoDB", new Guid("0f58ef89-c87e-4c09-a9ad-4cbc2f764aec") },
                    { new Guid("c75e6e5b-d81c-4cbd-b197-650abccc352b"), null, new DateTime(2024, 11, 26, 13, 4, 54, 753, DateTimeKind.Local).AddTicks(3600), "Essa é uma tarefa para subir a imagem do Docker para um serviço ECR", 3, new Guid("3d490a70-94ce-4d15-9494-5248280c2ce3"), 2, "Subir a imagem do Docker para um serviço ECR da AWS", new Guid("0f58ef89-c87e-4c09-a9ad-4cbc2f764aec") }
                });

            migrationBuilder.CreateIndex(
                name: "IX_HistoricoAlteracoes_TarefaId",
                table: "HistoricoAlteracoes",
                column: "TarefaId");

            migrationBuilder.CreateIndex(
                name: "IX_Tarefas_ProjetoId",
                table: "Tarefas",
                column: "ProjetoId");

            migrationBuilder.CreateIndex(
                name: "IX_Tarefas_UsuarioId",
                table: "Tarefas",
                column: "UsuarioId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "HistoricoAlteracoes");

            migrationBuilder.DropTable(
                name: "Tarefas");

            migrationBuilder.DropTable(
                name: "Projetos");

            migrationBuilder.DropTable(
                name: "Usuarios");
        }
    }
}
