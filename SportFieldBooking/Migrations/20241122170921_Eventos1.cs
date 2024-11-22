using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SportFieldBooking.Migrations
{
    /// <inheritdoc />
    public partial class Eventos1 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Eventos_Campos_CampoIdCampo",
                table: "Eventos");

            migrationBuilder.DropIndex(
                name: "IX_Eventos_CampoIdCampo",
                table: "Eventos");

            migrationBuilder.DropColumn(
                name: "CampoIdCampo",
                table: "Eventos");

            migrationBuilder.CreateIndex(
                name: "IX_Eventos_IdCampo",
                table: "Eventos",
                column: "IdCampo");

            migrationBuilder.AddForeignKey(
                name: "FK_Eventos_Campos_IdCampo",
                table: "Eventos",
                column: "IdCampo",
                principalTable: "Campos",
                principalColumn: "IdCampo",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Eventos_Campos_IdCampo",
                table: "Eventos");

            migrationBuilder.DropIndex(
                name: "IX_Eventos_IdCampo",
                table: "Eventos");

            migrationBuilder.AddColumn<int>(
                name: "CampoIdCampo",
                table: "Eventos",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Eventos_CampoIdCampo",
                table: "Eventos",
                column: "CampoIdCampo");

            migrationBuilder.AddForeignKey(
                name: "FK_Eventos_Campos_CampoIdCampo",
                table: "Eventos",
                column: "CampoIdCampo",
                principalTable: "Campos",
                principalColumn: "IdCampo",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
