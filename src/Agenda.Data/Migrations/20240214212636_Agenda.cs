using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Agenda.Data.Migrations
{
    /// <inheritdoc />
    public partial class Agenda : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "tb_clients",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "varchar(100)", nullable: false),
                    Email = table.Column<string>(type: "varchar(100)", nullable: false),
                    PhoneNumber = table.Column<string>(type: "varchar(50)", nullable: false),
                    CreateDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdateDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    CreateUserId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    UpdateUserId = table.Column<Guid>(type: "uniqueidentifier", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tb_clients", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "tb_companies",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "varchar(200)", nullable: false),
                    Description = table.Column<string>(type: "varchar(1000)", nullable: false),
                    CreateDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdateDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    CreateUserId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    UpdateUserId = table.Column<Guid>(type: "uniqueidentifier", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tb_companies", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "tb_verificationcodes",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CreateDate = table.Column<DateTime>(type: "datetime", nullable: false),
                    TypeCheck = table.Column<int>(type: "int", nullable: false),
                    PhoneNumber = table.Column<string>(type: "varchar(50)", nullable: true),
                    Email = table.Column<string>(type: "varchar(100)", nullable: true),
                    Code = table.Column<string>(type: "varchar(8)", nullable: false),
                    DateCheck = table.Column<DateTime>(type: "datetime", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tb_verificationcodes", x => x.Id);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "tb_clients");

            migrationBuilder.DropTable(
                name: "tb_companies");

            migrationBuilder.DropTable(
                name: "tb_verificationcodes");
        }
    }
}
