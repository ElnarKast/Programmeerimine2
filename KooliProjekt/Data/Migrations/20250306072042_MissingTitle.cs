using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace KooliProjekt.Data.Migrations
{
    /// <inheritdoc />
    public partial class MissingTitle : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Building_AspNetUsers_UserId",
                table: "Building");

            migrationBuilder.DropForeignKey(
                name: "FK_BuildingPanels_Building_BuildingId",
                table: "BuildingPanels");

            migrationBuilder.DropForeignKey(
                name: "FK_BuildingPanels_Panel_PanelId",
                table: "BuildingPanels");

            migrationBuilder.AddColumn<string>(
                name: "Title",
                table: "Service",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Title",
                table: "PanelMaterial",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Title",
                table: "Panel",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "Material",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AddColumn<string>(
                name: "Title",
                table: "Material",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "PanelId",
                table: "BuildingPanels",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<int>(
                name: "BuildingId",
                table: "BuildingPanels",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddColumn<string>(
                name: "Title",
                table: "BuildingPanels",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "UserId",
                table: "Building",
                type: "nvarchar(450)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)");

            migrationBuilder.AlterColumn<string>(
                name: "Location",
                table: "Building",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AddColumn<string>(
                name: "Title",
                table: "Building",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Building_AspNetUsers_UserId",
                table: "Building",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_BuildingPanels_Building_BuildingId",
                table: "BuildingPanels",
                column: "BuildingId",
                principalTable: "Building",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_BuildingPanels_Panel_PanelId",
                table: "BuildingPanels",
                column: "PanelId",
                principalTable: "Panel",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Building_AspNetUsers_UserId",
                table: "Building");

            migrationBuilder.DropForeignKey(
                name: "FK_BuildingPanels_Building_BuildingId",
                table: "BuildingPanels");

            migrationBuilder.DropForeignKey(
                name: "FK_BuildingPanels_Panel_PanelId",
                table: "BuildingPanels");

            migrationBuilder.DropColumn(
                name: "Title",
                table: "Service");

            migrationBuilder.DropColumn(
                name: "Title",
                table: "PanelMaterial");

            migrationBuilder.DropColumn(
                name: "Title",
                table: "Panel");

            migrationBuilder.DropColumn(
                name: "Title",
                table: "Material");

            migrationBuilder.DropColumn(
                name: "Title",
                table: "BuildingPanels");

            migrationBuilder.DropColumn(
                name: "Title",
                table: "Building");

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "Material",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "PanelId",
                table: "BuildingPanels",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "BuildingId",
                table: "BuildingPanels",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "UserId",
                table: "Building",
                type: "nvarchar(450)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(450)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Location",
                table: "Building",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Building_AspNetUsers_UserId",
                table: "Building",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_BuildingPanels_Building_BuildingId",
                table: "BuildingPanels",
                column: "BuildingId",
                principalTable: "Building",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_BuildingPanels_Panel_PanelId",
                table: "BuildingPanels",
                column: "PanelId",
                principalTable: "Panel",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
