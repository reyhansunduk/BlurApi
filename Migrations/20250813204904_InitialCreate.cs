using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BlurApi.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "TaxAddress",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "uniqueidentifier", nullable: false, defaultValueSql: "NEWID()"),
                    province = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    district = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    inserted_by = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    inserted_date = table.Column<DateTime>(type: "datetime2", nullable: false),
                    changed_date = table.Column<DateTime>(type: "datetime2", nullable: false),
                    changed_by = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TaxAddress", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "Enterprices",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "uniqueidentifier", nullable: false, defaultValueSql: "NEWID()"),
                    title = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    phone = table.Column<string>(type: "nvarchar(12)", maxLength: 12, nullable: false),
                    email = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    balance = table.Column<float>(type: "real", nullable: false),
                    verified = table.Column<bool>(type: "bit", nullable: false, defaultValue: true),
                    address = table.Column<string>(type: "nvarchar(1000)", maxLength: 1000, nullable: false),
                    tax_number = table.Column<long>(type: "bigint", nullable: false),
                    tax_address_id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    created_at = table.Column<DateTime>(type: "datetime2", nullable: false),
                    disabled = table.Column<bool>(type: "bit", nullable: false, defaultValue: false),
                    inserted_by = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    inserted_date = table.Column<DateTime>(type: "datetime2", nullable: false),
                    changed_date = table.Column<DateTime>(type: "datetime2", nullable: false),
                    changed_by = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Enterprices", x => x.id);
                    table.ForeignKey(
                        name: "FK_Enterprices_TaxAddress_tax_address_id",
                        column: x => x.tax_address_id,
                        principalTable: "TaxAddress",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Enterprices_tax_address_id",
                table: "Enterprices",
                column: "tax_address_id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Enterprices");

            migrationBuilder.DropTable(
                name: "TaxAddress");
        }
    }
}
