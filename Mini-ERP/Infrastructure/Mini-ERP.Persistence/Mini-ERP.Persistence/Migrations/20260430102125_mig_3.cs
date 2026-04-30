using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Mini_ERP.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class mig_3 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_MilkCollections_Employees_CollectorEmployeeId",
                table: "MilkCollections");

            migrationBuilder.DropForeignKey(
                name: "FK_MilkCollections_Employees_QualityEmployeeId",
                table: "MilkCollections");

            migrationBuilder.AlterColumn<decimal>(
                name: "Quantity",
                table: "MilkCollections",
                type: "DECIMAL(18, 2)",
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "DECIMAL(18,2)");

            migrationBuilder.AlterColumn<decimal>(
                name: "ProteinRate",
                table: "MilkCollections",
                type: "DECIMAL(18, 2)",
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "DECIMAL(18,2)");

            migrationBuilder.AlterColumn<decimal>(
                name: "FatRate",
                table: "MilkCollections",
                type: "DECIMAL(18, 2)",
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "DECIMAL(18,2)");

            migrationBuilder.CreateTable(
                name: "Stocks",
                columns: table => new
                {
                    Id = table.Column<int>(type: "NUMBER(10)", nullable: false)
                        .Annotation("Oracle:Identity", "START WITH 1 INCREMENT BY 1"),
                    ProductName = table.Column<string>(type: "NVARCHAR2(2000)", nullable: false),
                    Quantity = table.Column<decimal>(type: "DECIMAL(18, 2)", nullable: false),
                    Unit = table.Column<string>(type: "NVARCHAR2(2000)", nullable: false),
                    ReferenceId = table.Column<int>(type: "NUMBER(10)", nullable: true),
                    ReferenceType = table.Column<int>(type: "NUMBER(10)", nullable: false),
                    LastUpdated = table.Column<DateTime>(type: "TIMESTAMP(7)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Stocks", x => x.Id);
                });

            migrationBuilder.AddForeignKey(
                name: "FK_MilkCollections_Employees_CollectorEmployeeId",
                table: "MilkCollections",
                column: "CollectorEmployeeId",
                principalTable: "Employees",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_MilkCollections_Employees_QualityEmployeeId",
                table: "MilkCollections",
                column: "QualityEmployeeId",
                principalTable: "Employees",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_MilkCollections_Employees_CollectorEmployeeId",
                table: "MilkCollections");

            migrationBuilder.DropForeignKey(
                name: "FK_MilkCollections_Employees_QualityEmployeeId",
                table: "MilkCollections");

            migrationBuilder.DropTable(
                name: "Stocks");

            migrationBuilder.AlterColumn<decimal>(
                name: "Quantity",
                table: "MilkCollections",
                type: "DECIMAL(18,2)",
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "DECIMAL(18, 2)");

            migrationBuilder.AlterColumn<decimal>(
                name: "ProteinRate",
                table: "MilkCollections",
                type: "DECIMAL(18,2)",
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "DECIMAL(18, 2)");

            migrationBuilder.AlterColumn<decimal>(
                name: "FatRate",
                table: "MilkCollections",
                type: "DECIMAL(18,2)",
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "DECIMAL(18, 2)");

            migrationBuilder.AddForeignKey(
                name: "FK_MilkCollections_Employees_CollectorEmployeeId",
                table: "MilkCollections",
                column: "CollectorEmployeeId",
                principalTable: "Employees",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_MilkCollections_Employees_QualityEmployeeId",
                table: "MilkCollections",
                column: "QualityEmployeeId",
                principalTable: "Employees",
                principalColumn: "Id");
        }
    }
}
