using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Resorter.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class FilledCarDataProperties : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "Chassis_Abs",
                table: "Cars",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<int>(
                name: "Chassis_Drive",
                table: "Cars",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<bool>(
                name: "Chassis_Ebd",
                table: "Cars",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "Chassis_Esp",
                table: "Cars",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<int>(
                name: "Chassis_Transmission",
                table: "Cars",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "Engine_Fuel",
                table: "Cars",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<decimal>(
                name: "Engine_FuelConsumptionKm",
                table: "Cars",
                type: "decimal(18,2)",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<int>(
                name: "Engine_Horsepower",
                table: "Cars",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<decimal>(
                name: "Engine_TankCapacity",
                table: "Cars",
                type: "decimal(18,2)",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<string>(
                name: "Engine_Type",
                table: "Cars",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<decimal>(
                name: "Insurance_DepositAmount",
                table: "Cars",
                type: "decimal(18,2)",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<decimal>(
                name: "Insurance_FranchiseAmount",
                table: "Cars",
                type: "decimal(18,2)",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<bool>(
                name: "Insurance_IsDeposit",
                table: "Cars",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "Insurance_IsFranchise",
                table: "Cars",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<string>(
                name: "Specifications_AirConditioning",
                table: "Cars",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<int>(
                name: "Specifications_AirbagsAmount",
                table: "Cars",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<bool>(
                name: "Specifications_CruiseControl",
                table: "Cars",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<int>(
                name: "Specifications_DoorsAmount",
                table: "Cars",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "Specifications_Interior",
                table: "Cars",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<bool>(
                name: "Specifications_ParkingAssist",
                table: "Cars",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "Specifications_PoweredWindows",
                table: "Cars",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "Specifications_RearViewCamera",
                table: "Cars",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<int>(
                name: "Specifications_RequiredLicense",
                table: "Cars",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "Specifications_RoofType",
                table: "Cars",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<int>(
                name: "Specifications_SeatsAmount",
                table: "Cars",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "Specifications_SideWheel",
                table: "Cars",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Chassis_Abs",
                table: "Cars");

            migrationBuilder.DropColumn(
                name: "Chassis_Drive",
                table: "Cars");

            migrationBuilder.DropColumn(
                name: "Chassis_Ebd",
                table: "Cars");

            migrationBuilder.DropColumn(
                name: "Chassis_Esp",
                table: "Cars");

            migrationBuilder.DropColumn(
                name: "Chassis_Transmission",
                table: "Cars");

            migrationBuilder.DropColumn(
                name: "Engine_Fuel",
                table: "Cars");

            migrationBuilder.DropColumn(
                name: "Engine_FuelConsumptionKm",
                table: "Cars");

            migrationBuilder.DropColumn(
                name: "Engine_Horsepower",
                table: "Cars");

            migrationBuilder.DropColumn(
                name: "Engine_TankCapacity",
                table: "Cars");

            migrationBuilder.DropColumn(
                name: "Engine_Type",
                table: "Cars");

            migrationBuilder.DropColumn(
                name: "Insurance_DepositAmount",
                table: "Cars");

            migrationBuilder.DropColumn(
                name: "Insurance_FranchiseAmount",
                table: "Cars");

            migrationBuilder.DropColumn(
                name: "Insurance_IsDeposit",
                table: "Cars");

            migrationBuilder.DropColumn(
                name: "Insurance_IsFranchise",
                table: "Cars");

            migrationBuilder.DropColumn(
                name: "Specifications_AirConditioning",
                table: "Cars");

            migrationBuilder.DropColumn(
                name: "Specifications_AirbagsAmount",
                table: "Cars");

            migrationBuilder.DropColumn(
                name: "Specifications_CruiseControl",
                table: "Cars");

            migrationBuilder.DropColumn(
                name: "Specifications_DoorsAmount",
                table: "Cars");

            migrationBuilder.DropColumn(
                name: "Specifications_Interior",
                table: "Cars");

            migrationBuilder.DropColumn(
                name: "Specifications_ParkingAssist",
                table: "Cars");

            migrationBuilder.DropColumn(
                name: "Specifications_PoweredWindows",
                table: "Cars");

            migrationBuilder.DropColumn(
                name: "Specifications_RearViewCamera",
                table: "Cars");

            migrationBuilder.DropColumn(
                name: "Specifications_RequiredLicense",
                table: "Cars");

            migrationBuilder.DropColumn(
                name: "Specifications_RoofType",
                table: "Cars");

            migrationBuilder.DropColumn(
                name: "Specifications_SeatsAmount",
                table: "Cars");

            migrationBuilder.DropColumn(
                name: "Specifications_SideWheel",
                table: "Cars");
        }
    }
}
