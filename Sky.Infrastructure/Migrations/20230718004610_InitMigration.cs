using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Sky.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class InitMigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterDatabase()
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Addresses",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Street = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Line2 = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    City = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    State = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    PostalCode = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    IsActive = table.Column<bool>(type: "tinyint(1)", nullable: true),
                    CountryId = table.Column<long>(type: "bigint", nullable: true),
                    ClientId = table.Column<long>(type: "bigint", nullable: true),
                    IsRemoved = table.Column<bool>(type: "tinyint(1)", nullable: false),
                    CreateBy = table.Column<long>(type: "bigint", nullable: true),
                    UpdatedBy = table.Column<long>(type: "bigint", nullable: true),
                    CreateDate = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    UpdateDate = table.Column<DateTime>(type: "datetime(6)", nullable: true),
                    Note = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Addresses", x => x.Id);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Branches",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Code = table.Column<string>(type: "varchar(10)", maxLength: 10, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Name = table.Column<string>(type: "varchar(150)", maxLength: 150, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    LogoURL = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    ShowLogo = table.Column<bool>(type: "tinyint(1)", nullable: true),
                    AddressId = table.Column<long>(type: "bigint", nullable: true),
                    ContactId = table.Column<long>(type: "bigint", nullable: true),
                    CommercialNo = table.Column<string>(type: "varchar(50)", maxLength: 50, nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    SiteURL = table.Column<string>(type: "varchar(250)", maxLength: 250, nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    DefaultCurrencyId = table.Column<long>(type: "bigint", nullable: true),
                    DefaultInventoryId = table.Column<long>(type: "bigint", nullable: true),
                    DefaultCostCenterId = table.Column<long>(type: "bigint", nullable: true),
                    AccPurchasesId = table.Column<long>(type: "bigint", nullable: true),
                    AccSuppliersId = table.Column<long>(type: "bigint", nullable: true),
                    AccCashId = table.Column<long>(type: "bigint", nullable: true),
                    AccPurchasesReturnsId = table.Column<long>(type: "bigint", nullable: true),
                    AccSalesTaxonPurchasesId = table.Column<long>(type: "bigint", nullable: true),
                    AccDiscountAcquiredId = table.Column<long>(type: "bigint", nullable: true),
                    AccSalesId = table.Column<long>(type: "bigint", nullable: true),
                    AccInventoryId = table.Column<long>(type: "bigint", nullable: true),
                    AccSalesCostId = table.Column<long>(type: "bigint", nullable: true),
                    InventoryAccountingTypes = table.Column<int>(type: "int", nullable: true),
                    SystemType = table.Column<int>(type: "int", nullable: true),
                    ClientId = table.Column<long>(type: "bigint", nullable: true),
                    IsRemoved = table.Column<bool>(type: "tinyint(1)", nullable: false),
                    CreateBy = table.Column<long>(type: "bigint", nullable: true),
                    UpdatedBy = table.Column<long>(type: "bigint", nullable: true),
                    CreateDate = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    UpdateDate = table.Column<DateTime>(type: "datetime(6)", nullable: true),
                    Note = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Branches", x => x.Id);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Countries",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    CountryName = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    ClientId = table.Column<long>(type: "bigint", nullable: true),
                    IsRemoved = table.Column<bool>(type: "tinyint(1)", nullable: false),
                    CreateBy = table.Column<long>(type: "bigint", nullable: true),
                    UpdatedBy = table.Column<long>(type: "bigint", nullable: true),
                    CreateDate = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    UpdateDate = table.Column<DateTime>(type: "datetime(6)", nullable: true),
                    Note = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Countries", x => x.Id);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Currencies",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Code = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Name = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Rate = table.Column<float>(type: "float", nullable: true),
                    Symbol = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    ClientId = table.Column<long>(type: "bigint", nullable: true),
                    IsRemoved = table.Column<bool>(type: "tinyint(1)", nullable: false),
                    CreateBy = table.Column<long>(type: "bigint", nullable: true),
                    UpdatedBy = table.Column<long>(type: "bigint", nullable: true),
                    CreateDate = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    UpdateDate = table.Column<DateTime>(type: "datetime(6)", nullable: true),
                    Note = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Currencies", x => x.Id);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Customers",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Code = table.Column<string>(type: "varchar(10)", maxLength: 10, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Name = table.Column<string>(type: "varchar(150)", maxLength: 150, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    IsActive = table.Column<bool>(type: "tinyint(10)", maxLength: 10, nullable: true),
                    AddressId = table.Column<long>(type: "bigint", nullable: true),
                    ContactId = table.Column<long>(type: "bigint", nullable: true),
                    ClientId = table.Column<long>(type: "bigint", nullable: true),
                    IsRemoved = table.Column<bool>(type: "tinyint(1)", nullable: false),
                    CreateBy = table.Column<long>(type: "bigint", nullable: true),
                    UpdatedBy = table.Column<long>(type: "bigint", nullable: true),
                    CreateDate = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    UpdateDate = table.Column<DateTime>(type: "datetime(6)", nullable: true),
                    Note = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Customers", x => x.Id);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Inventories",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    BranchId = table.Column<long>(type: "bigint", nullable: true),
                    InventoryCode = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    InventoryName = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    AddressId = table.Column<long>(type: "bigint", nullable: true),
                    PostalCode = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Storekeeper = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    ClientId = table.Column<long>(type: "bigint", nullable: true),
                    IsRemoved = table.Column<bool>(type: "tinyint(1)", nullable: false),
                    CreateBy = table.Column<long>(type: "bigint", nullable: true),
                    UpdatedBy = table.Column<long>(type: "bigint", nullable: true),
                    CreateDate = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    UpdateDate = table.Column<DateTime>(type: "datetime(6)", nullable: true),
                    Note = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Inventories", x => x.Id);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Roles",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Code = table.Column<string>(type: "varchar(10)", maxLength: 10, nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Name = table.Column<string>(type: "varchar(150)", maxLength: 150, nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    ClientId = table.Column<long>(type: "bigint", nullable: true),
                    IsRemoved = table.Column<bool>(type: "tinyint(1)", nullable: false),
                    CreateBy = table.Column<long>(type: "bigint", nullable: true),
                    UpdatedBy = table.Column<long>(type: "bigint", nullable: true),
                    CreateDate = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    UpdateDate = table.Column<DateTime>(type: "datetime(6)", nullable: true),
                    Note = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Roles", x => x.Id);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Units",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Code = table.Column<string>(type: "varchar(10)", maxLength: 10, nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Name = table.Column<string>(type: "varchar(150)", maxLength: 150, nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    ClientId = table.Column<long>(type: "bigint", nullable: true),
                    IsRemoved = table.Column<bool>(type: "tinyint(1)", nullable: false),
                    CreateBy = table.Column<long>(type: "bigint", nullable: true),
                    UpdatedBy = table.Column<long>(type: "bigint", nullable: true),
                    CreateDate = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    UpdateDate = table.Column<DateTime>(type: "datetime(6)", nullable: true),
                    Note = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Units", x => x.Id);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Code = table.Column<string>(type: "varchar(10)", maxLength: 10, nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    FirstName = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    LastName = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    UserName = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Password = table.Column<string>(type: "varchar(100)", maxLength: 100, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Email = table.Column<string>(type: "varchar(100)", maxLength: 100, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    RoleId = table.Column<long>(type: "bigint", nullable: true),
                    ClientId = table.Column<long>(type: "bigint", nullable: true),
                    IsRemoved = table.Column<bool>(type: "tinyint(1)", nullable: false),
                    CreateBy = table.Column<long>(type: "bigint", nullable: true),
                    UpdatedBy = table.Column<long>(type: "bigint", nullable: true),
                    CreateDate = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    UpdateDate = table.Column<DateTime>(type: "datetime(6)", nullable: true),
                    Note = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.Id);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.InsertData(
                table: "Branches",
                columns: new[] { "Id", "AccCashId", "AccDiscountAcquiredId", "AccInventoryId", "AccPurchasesId", "AccPurchasesReturnsId", "AccSalesCostId", "AccSalesId", "AccSalesTaxonPurchasesId", "AccSuppliersId", "AddressId", "ClientId", "Code", "CommercialNo", "ContactId", "CreateBy", "CreateDate", "DefaultCostCenterId", "DefaultCurrencyId", "DefaultInventoryId", "InventoryAccountingTypes", "IsRemoved", "LogoURL", "Name", "Note", "ShowLogo", "SiteURL", "SystemType", "UpdateDate", "UpdatedBy" },
                values: new object[] { 1L, null, null, null, null, null, null, null, null, null, null, 1L, "001", null, null, null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, null, null, false, null, "Main Branch", null, null, null, null, null, null });

            migrationBuilder.InsertData(
                table: "Countries",
                columns: new[] { "Id", "ClientId", "CountryName", "CreateBy", "CreateDate", "IsRemoved", "Note", "UpdateDate", "UpdatedBy" },
                values: new object[,]
                {
                    { 1L, null, "Afghanistan", null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), false, null, null, null },
                    { 2L, null, "Albania", null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), false, null, null, null },
                    { 3L, null, "Algeria", null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), false, null, null, null },
                    { 4L, null, "American Samoa", null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), false, null, null, null },
                    { 5L, null, "Andorra", null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), false, null, null, null },
                    { 6L, null, "Angola", null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), false, null, null, null },
                    { 7L, null, "Anguilla", null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), false, null, null, null },
                    { 8L, null, "Antarctica", null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), false, null, null, null },
                    { 9L, null, "Antigua and Barbuda", null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), false, null, null, null },
                    { 10L, null, "Argentina", null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), false, null, null, null },
                    { 11L, null, "Armenia", null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), false, null, null, null },
                    { 12L, null, "Aruba", null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), false, null, null, null },
                    { 13L, null, "Australia", null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), false, null, null, null },
                    { 14L, null, "Austria", null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), false, null, null, null },
                    { 15L, null, "Azerbaijan", null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), false, null, null, null },
                    { 16L, null, "Bahamas", null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), false, null, null, null },
                    { 17L, null, "Bahrain", null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), false, null, null, null },
                    { 18L, null, "Bangladesh", null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), false, null, null, null },
                    { 19L, null, "Barbados", null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), false, null, null, null },
                    { 20L, null, "Belarus", null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), false, null, null, null },
                    { 21L, null, "Belgium", null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), false, null, null, null },
                    { 22L, null, "Belize", null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), false, null, null, null },
                    { 23L, null, "Benin", null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), false, null, null, null },
                    { 24L, null, "Bermuda", null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), false, null, null, null },
                    { 25L, null, "Bhutan", null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), false, null, null, null },
                    { 26L, null, "Bolivia", null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), false, null, null, null },
                    { 27L, null, "Bosnia and Herzegovina", null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), false, null, null, null },
                    { 28L, null, "Botswana", null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), false, null, null, null },
                    { 29L, null, "Bouvet Island", null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), false, null, null, null },
                    { 30L, null, "Brazil", null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), false, null, null, null },
                    { 31L, null, "British Indian Ocean Territories", null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), false, null, null, null },
                    { 32L, null, "Brunei Darussalam", null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), false, null, null, null },
                    { 33L, null, "Bulgaria", null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), false, null, null, null },
                    { 34L, null, "Burkina Faso", null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), false, null, null, null },
                    { 35L, null, "Burundi", null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), false, null, null, null },
                    { 36L, null, "Cambodia", null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), false, null, null, null },
                    { 37L, null, "Cameroon", null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), false, null, null, null },
                    { 38L, null, "Canada", null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), false, null, null, null },
                    { 39L, null, "Cape Verde", null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), false, null, null, null },
                    { 40L, null, "Cayman Islands", null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), false, null, null, null },
                    { 41L, null, "Central African Republic", null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), false, null, null, null },
                    { 42L, null, "Chad", null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), false, null, null, null },
                    { 43L, null, "Chile", null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), false, null, null, null },
                    { 44L, null, "China", null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), false, null, null, null },
                    { 45L, null, "Christmas Island", null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), false, null, null, null },
                    { 46L, null, "Cocos Islands", null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), false, null, null, null },
                    { 47L, null, "Columbia", null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), false, null, null, null },
                    { 48L, null, "Comoros", null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), false, null, null, null },
                    { 49L, null, "Congo", null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), false, null, null, null },
                    { 50L, null, "Cook Islands", null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), false, null, null, null },
                    { 51L, null, "Costa Rica", null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), false, null, null, null },
                    { 52L, null, "Cote D'ivoire", null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), false, null, null, null },
                    { 53L, null, "Croatia", null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), false, null, null, null },
                    { 54L, null, "Cuba", null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), false, null, null, null },
                    { 55L, null, "Cyprus", null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), false, null, null, null },
                    { 56L, null, "Czech Republic", null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), false, null, null, null },
                    { 57L, null, "Djibouti", null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), false, null, null, null },
                    { 58L, null, "Dominica", null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), false, null, null, null },
                    { 59L, null, "Dominican Republic", null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), false, null, null, null },
                    { 60L, null, "East Timor", null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), false, null, null, null },
                    { 61L, null, "Ecuador", null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), false, null, null, null },
                    { 62L, null, "Egypt", null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), false, null, null, null },
                    { 63L, null, "El Salvador", null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), false, null, null, null },
                    { 64L, null, "Equatorial Guinea", null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), false, null, null, null },
                    { 65L, null, "Eritrea", null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), false, null, null, null },
                    { 66L, null, "Estonia", null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), false, null, null, null },
                    { 67L, null, "Ethiopia", null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), false, null, null, null },
                    { 68L, null, "Falkland Islands", null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), false, null, null, null },
                    { 69L, null, "Faroe Islands", null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), false, null, null, null },
                    { 70L, null, "Finland", null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), false, null, null, null },
                    { 71L, null, "France", null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), false, null, null, null },
                    { 72L, null, "France, Metropolitan", null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), false, null, null, null },
                    { 73L, null, "French Guiana", null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), false, null, null, null },
                    { 74L, null, "French Polynesia", null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), false, null, null, null },
                    { 75L, null, "Fiji", null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), false, null, null, null },
                    { 76L, null, "French Southern Territories", null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), false, null, null, null },
                    { 77L, null, "FYROM", null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), false, null, null, null },
                    { 78L, null, "Gabon", null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), false, null, null, null },
                    { 79L, null, "Gambia", null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), false, null, null, null },
                    { 80L, null, "Georgia", null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), false, null, null, null },
                    { 81L, null, "Germany", null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), false, null, null, null },
                    { 82L, null, "Ghana", null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), false, null, null, null },
                    { 83L, null, "Greece", null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), false, null, null, null },
                    { 84L, null, "Greenland", null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), false, null, null, null },
                    { 85L, null, "Grenada", null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), false, null, null, null },
                    { 86L, null, "Guadeloupe", null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), false, null, null, null },
                    { 87L, null, "Guam", null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), false, null, null, null },
                    { 88L, null, "Gibraltar", null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), false, null, null, null },
                    { 89L, null, "Guatemala", null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), false, null, null, null },
                    { 90L, null, "Guinea", null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), false, null, null, null },
                    { 91L, null, "Guinea-Bissau", null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), false, null, null, null },
                    { 92L, null, "Guyana", null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), false, null, null, null },
                    { 93L, null, "Haiti", null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), false, null, null, null },
                    { 94L, null, "Heard Island And Mcdonald Islands", null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), false, null, null, null },
                    { 95L, null, "Honduras", null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), false, null, null, null },
                    { 96L, null, "Hong Kong", null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), false, null, null, null },
                    { 97L, null, "Hungary", null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), false, null, null, null },
                    { 98L, null, "Iceland", null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), false, null, null, null },
                    { 99L, null, "India", null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), false, null, null, null },
                    { 101L, null, "Indonesia", null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), false, null, null, null },
                    { 102L, null, "Iran", null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), false, null, null, null },
                    { 103L, null, "Iraq", null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), false, null, null, null },
                    { 104L, null, "Ireland", null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), false, null, null, null },
                    { 105L, null, "Italy", null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), false, null, null, null },
                    { 106L, null, "Jamaica", null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), false, null, null, null },
                    { 107L, null, "Japan", null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), false, null, null, null },
                    { 108L, null, "Jordan", null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), false, null, null, null },
                    { 109L, null, "Kazakhstan", null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), false, null, null, null },
                    { 110L, null, "Kenya", null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), false, null, null, null },
                    { 111L, null, "Kiribati", null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), false, null, null, null },
                    { 112L, null, "Korea, Democratic Peoples Republic of", null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), false, null, null, null },
                    { 113L, null, "Korea, Republic of", null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), false, null, null, null },
                    { 114L, null, "Kuwait", null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), false, null, null, null },
                    { 115L, null, "Kyrgyzstan", null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), false, null, null, null },
                    { 116L, null, "Lao Peoples Democratic Republic", null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), false, null, null, null },
                    { 117L, null, "Latvia", null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), false, null, null, null },
                    { 118L, null, "Lebanon", null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), false, null, null, null },
                    { 119L, null, "Lesotho", null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), false, null, null, null },
                    { 120L, null, "Liberia", null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), false, null, null, null },
                    { 121L, null, "Libyan Arab Jamahiriya", null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), false, null, null, null },
                    { 122L, null, "Liechtenstein", null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), false, null, null, null },
                    { 123L, null, "Lithuania", null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), false, null, null, null },
                    { 124L, null, "Luxembourg", null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), false, null, null, null },
                    { 125L, null, "Macau", null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), false, null, null, null },
                    { 126L, null, "Madagascar", null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), false, null, null, null },
                    { 127L, null, "Malawi", null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), false, null, null, null },
                    { 128L, null, "Malaysia", null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), false, null, null, null },
                    { 129L, null, "Maldives", null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), false, null, null, null },
                    { 130L, null, "Mali", null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), false, null, null, null },
                    { 131L, null, "Malta", null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), false, null, null, null },
                    { 132L, null, "Marshall Islands", null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), false, null, null, null },
                    { 133L, null, "Martinique", null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), false, null, null, null },
                    { 134L, null, "Mauritania", null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), false, null, null, null },
                    { 135L, null, "Mauritius", null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), false, null, null, null },
                    { 136L, null, "Mayotte", null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), false, null, null, null },
                    { 137L, null, "Mexico", null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), false, null, null, null },
                    { 138L, null, "Micronesia", null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), false, null, null, null },
                    { 139L, null, "Moldova", null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), false, null, null, null },
                    { 140L, null, "Mongolia", null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), false, null, null, null },
                    { 141L, null, "Montserrat", null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), false, null, null, null },
                    { 142L, null, "Morocco", null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), false, null, null, null },
                    { 143L, null, "Monaco", null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), false, null, null, null },
                    { 144L, null, "Myanmar", null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), false, null, null, null },
                    { 145L, null, "Mozambique", null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), false, null, null, null },
                    { 146L, null, "Namibia", null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), false, null, null, null },
                    { 147L, null, "Nauru", null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), false, null, null, null },
                    { 148L, null, "Nepal", null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), false, null, null, null },
                    { 149L, null, "Netherlands", null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), false, null, null, null },
                    { 150L, null, "Netherlands Antilles", null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), false, null, null, null },
                    { 151L, null, "New Caledonia", null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), false, null, null, null },
                    { 152L, null, "New Zealand", null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), false, null, null, null },
                    { 153L, null, "Nicaragua", null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), false, null, null, null },
                    { 154L, null, "Niger", null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), false, null, null, null },
                    { 155L, null, "Nigeria", null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), false, null, null, null },
                    { 156L, null, "Niue", null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), false, null, null, null },
                    { 157L, null, "Norfolk Island", null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), false, null, null, null },
                    { 158L, null, "Northern Mariana Islands", null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), false, null, null, null },
                    { 159L, null, "Norway", null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), false, null, null, null },
                    { 160L, null, "Oman", null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), false, null, null, null },
                    { 161L, null, "Pakistan", null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), false, null, null, null },
                    { 162L, null, "palestine", null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), false, null, null, null },
                    { 163L, null, "Palau", null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), false, null, null, null },
                    { 164L, null, "Panama", null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), false, null, null, null },
                    { 165L, null, "Papua New Guinea", null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), false, null, null, null },
                    { 166L, null, "Paraguay", null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), false, null, null, null },
                    { 167L, null, "Peru", null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), false, null, null, null },
                    { 168L, null, "Philippines", null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), false, null, null, null },
                    { 169L, null, "Pitcairn", null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), false, null, null, null },
                    { 170L, null, "Poland", null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), false, null, null, null },
                    { 171L, null, "Portugal", null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), false, null, null, null },
                    { 172L, null, "Puerto Rico", null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), false, null, null, null },
                    { 173L, null, "Qatar", null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), false, null, null, null },
                    { 174L, null, "Reunion", null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), false, null, null, null },
                    { 175L, null, "Romania", null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), false, null, null, null },
                    { 176L, null, "Russian Federation", null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), false, null, null, null },
                    { 177L, null, "Rwanda", null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), false, null, null, null },
                    { 178L, null, "Saint Helena", null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), false, null, null, null },
                    { 179L, null, "Saint Kitts and Nevis", null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), false, null, null, null },
                    { 180L, null, "Saint Lucia", null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), false, null, null, null },
                    { 181L, null, "Saint Pierre and Miquelon", null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), false, null, null, null },
                    { 182L, null, "Saint Vincent and The Grenadines", null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), false, null, null, null },
                    { 183L, null, "Samoa", null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), false, null, null, null },
                    { 184L, null, "San Marino", null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), false, null, null, null },
                    { 185L, null, "Sao Tome and Principe", null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), false, null, null, null },
                    { 186L, null, "Saudi Arabia", null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), false, null, null, null },
                    { 187L, null, "Senegal", null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), false, null, null, null },
                    { 188L, null, "Seychelles", null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), false, null, null, null },
                    { 189L, null, "Sierra Leone", null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), false, null, null, null },
                    { 191L, null, "Singapore", null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), false, null, null, null },
                    { 192L, null, "Slovakia", null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), false, null, null, null },
                    { 193L, null, "Slovenia", null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), false, null, null, null },
                    { 194L, null, "Solomon Islands", null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), false, null, null, null },
                    { 195L, null, "Somalia", null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), false, null, null, null },
                    { 196L, null, "South Africa", null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), false, null, null, null },
                    { 197L, null, "South Georgia and Sandwich Islands", null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), false, null, null, null },
                    { 198L, null, "Spain", null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), false, null, null, null },
                    { 199L, null, "Sri Lanka", null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), false, null, null, null },
                    { 200L, null, "Sudan", null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), false, null, null, null },
                    { 201L, null, "Suriname", null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), false, null, null, null },
                    { 202L, null, "Svalbard and JanMayen", null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), false, null, null, null },
                    { 203L, null, "Swaziland", null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), false, null, null, null },
                    { 204L, null, "Sweden", null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), false, null, null, null },
                    { 205L, null, "Switzerland", null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), false, null, null, null },
                    { 206L, null, "Syrian Arab Republic", null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), false, null, null, null },
                    { 207L, null, "Taiwan", null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), false, null, null, null },
                    { 208L, null, "Tajikistan", null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), false, null, null, null },
                    { 209L, null, "Tanzania", null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), false, null, null, null },
                    { 210L, null, "Thailand", null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), false, null, null, null },
                    { 211L, null, "Tokelau", null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), false, null, null, null },
                    { 212L, null, "Tonga", null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), false, null, null, null },
                    { 213L, null, "Trinidad and Tobago", null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), false, null, null, null },
                    { 214L, null, "Tunisia", null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), false, null, null, null },
                    { 215L, null, "Togo", null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), false, null, null, null },
                    { 216L, null, "Turkey", null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), false, null, null, null },
                    { 217L, null, "Turkmenistan", null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), false, null, null, null },
                    { 218L, null, "Turks and Caicos Islands", null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), false, null, null, null },
                    { 219L, null, "Tuvalu", null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), false, null, null, null },
                    { 220L, null, "Uganda", null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), false, null, null, null },
                    { 221L, null, "Ukraine", null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), false, null, null, null },
                    { 222L, null, "United Arab Emirates", null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), false, null, null, null },
                    { 223L, null, "United Kingdom", null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), false, null, null, null },
                    { 224L, null, "United States", null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), false, null, null, null },
                    { 225L, null, "Uruguay", null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), false, null, null, null },
                    { 226L, null, "Uzbekistan", null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), false, null, null, null },
                    { 227L, null, "Vanuatu", null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), false, null, null, null },
                    { 228L, null, "Vatican City State", null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), false, null, null, null },
                    { 229L, null, "Venezuela", null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), false, null, null, null },
                    { 230L, null, "Vietnam", null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), false, null, null, null },
                    { 231L, null, "Virgin Islands (British)", null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), false, null, null, null },
                    { 232L, null, "Virgin Islands (U.S.)", null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), false, null, null, null },
                    { 233L, null, "Wallis And Futuna Islands", null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), false, null, null, null },
                    { 234L, null, "Western Sahara", null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), false, null, null, null },
                    { 235L, null, "Yemen", null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), false, null, null, null },
                    { 236L, null, "Yugoslavia", null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), false, null, null, null },
                    { 237L, null, "Zaire", null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), false, null, null, null },
                    { 238L, null, "Zambia", null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), false, null, null, null },
                    { 239L, null, "Zimbabwe", null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), false, null, null, null },
                    { 240L, null, "Guernsey", null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), false, null, null, null },
                    { 241L, null, "Malaga", null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), false, null, null, null },
                    { 242L, null, "Denmark", null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), false, null, null, null },
                    { 243L, null, "Jersey", null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), false, null, null, null }
                });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "ClientId", "Code", "CreateBy", "CreateDate", "Email", "FirstName", "IsRemoved", "LastName", "Note", "Password", "RoleId", "UpdateDate", "UpdatedBy", "UserName" },
                values: new object[] { 1L, 1L, "001", null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "admin@admin.com", "admin", false, "admin", null, "qKkxoCVZkDE+Mr9Yobrs5RGQBfngHc0SnKXDOn0m1LmarY/c", null, null, null, "admin" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Addresses");

            migrationBuilder.DropTable(
                name: "Branches");

            migrationBuilder.DropTable(
                name: "Countries");

            migrationBuilder.DropTable(
                name: "Currencies");

            migrationBuilder.DropTable(
                name: "Customers");

            migrationBuilder.DropTable(
                name: "Inventories");

            migrationBuilder.DropTable(
                name: "Roles");

            migrationBuilder.DropTable(
                name: "Units");

            migrationBuilder.DropTable(
                name: "Users");
        }
    }
}
