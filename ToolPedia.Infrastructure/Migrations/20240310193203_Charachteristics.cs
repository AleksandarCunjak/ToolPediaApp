using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ToolPedia.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class Charachteristics : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "tool",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "uuid", nullable: false, defaultValueSql: "gen_random_uuid()"),
                    name = table.Column<string>(type: "text", nullable: false),
                    description = table.Column<string>(type: "text", nullable: true),
                    power_supply = table.Column<int>(type: "integer", nullable: false),
                    tool_type = table.Column<int>(type: "integer", nullable: false),
                    characteristics = table.Column<string>(type: "text", nullable: false),
                    images = table.Column<string>(type: "text", nullable: false),
                    brand = table.Column<string>(type: "text", nullable: false),
                    price = table.Column<double>(type: "double precision", nullable: false),
                    visits = table.Column<int>(type: "integer", nullable: false),
                    date_created = table.Column<DateTime>(type: "timestamp with time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_tool", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "users",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "uuid", nullable: false),
                    user_name = table.Column<string>(type: "text", nullable: false),
                    password_hash = table.Column<string>(type: "text", nullable: false),
                    password_salt = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_users", x => x.id);
                });

            migrationBuilder.CreateIndex(
                name: "ix_tool_brand",
                table: "tool",
                column: "brand");

            migrationBuilder.CreateIndex(
                name: "ix_tool_name",
                table: "tool",
                column: "name");

            migrationBuilder.CreateIndex(
                name: "ix_tool_power_supply",
                table: "tool",
                column: "power_supply");

            migrationBuilder.CreateIndex(
                name: "ix_tool_price",
                table: "tool",
                column: "price");

            migrationBuilder.CreateIndex(
                name: "ix_tool_tool_type",
                table: "tool",
                column: "tool_type");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "tool");

            migrationBuilder.DropTable(
                name: "users");
        }
    }
}
