using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SportFieldBooking.Migrations
{
    /// <inheritdoc />
    public partial class Eventos : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Reservas_Campos_CampoIdCampo",
                table: "Reservas");

            migrationBuilder.DropForeignKey(
                name: "FK_Reservas_Clientes_ClienteIdCliente",
                table: "Reservas");

            migrationBuilder.DropIndex(
                name: "IX_Reservas_CampoIdCampo",
                table: "Reservas");

            migrationBuilder.DropIndex(
                name: "IX_Reservas_ClienteIdCliente",
                table: "Reservas");

            migrationBuilder.DropColumn(
                name: "CampoIdCampo",
                table: "Reservas");

            migrationBuilder.DropColumn(
                name: "ClienteIdCliente",
                table: "Reservas");

            migrationBuilder.CreateIndex(
                name: "IX_Reservas_IdCampo",
                table: "Reservas",
                column: "IdCampo");

            migrationBuilder.CreateIndex(
                name: "IX_Reservas_IdCliente",
                table: "Reservas",
                column: "IdCliente");

            migrationBuilder.AddForeignKey(
                name: "FK_Reservas_Campos_IdCampo",
                table: "Reservas",
                column: "IdCampo",
                principalTable: "Campos",
                principalColumn: "IdCampo",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Reservas_Clientes_IdCliente",
                table: "Reservas",
                column: "IdCliente",
                principalTable: "Clientes",
                principalColumn: "IdCliente",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Reservas_Campos_IdCampo",
                table: "Reservas");

            migrationBuilder.DropForeignKey(
                name: "FK_Reservas_Clientes_IdCliente",
                table: "Reservas");

            migrationBuilder.DropIndex(
                name: "IX_Reservas_IdCampo",
                table: "Reservas");

            migrationBuilder.DropIndex(
                name: "IX_Reservas_IdCliente",
                table: "Reservas");

            migrationBuilder.AddColumn<int>(
                name: "CampoIdCampo",
                table: "Reservas",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "ClienteIdCliente",
                table: "Reservas",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Reservas_CampoIdCampo",
                table: "Reservas",
                column: "CampoIdCampo");

            migrationBuilder.CreateIndex(
                name: "IX_Reservas_ClienteIdCliente",
                table: "Reservas",
                column: "ClienteIdCliente");

            migrationBuilder.AddForeignKey(
                name: "FK_Reservas_Campos_CampoIdCampo",
                table: "Reservas",
                column: "CampoIdCampo",
                principalTable: "Campos",
                principalColumn: "IdCampo",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Reservas_Clientes_ClienteIdCliente",
                table: "Reservas",
                column: "ClienteIdCliente",
                principalTable: "Clientes",
                principalColumn: "IdCliente",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
