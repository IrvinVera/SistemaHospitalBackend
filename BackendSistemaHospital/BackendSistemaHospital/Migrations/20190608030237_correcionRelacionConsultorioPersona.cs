using Microsoft.EntityFrameworkCore.Migrations;

namespace BackendSistemaHospital.Migrations
{
    public partial class correcionRelacionConsultorioPersona : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Consultorio_Persona_PersonaForeignKey",
                table: "Consultorio");

            migrationBuilder.DropForeignKey(
                name: "FK_SignoVital_Persona_PersonaIdPersona",
                table: "SignoVital");

            migrationBuilder.DropIndex(
                name: "IX_Consultorio_PersonaForeignKey",
                table: "Consultorio");

            migrationBuilder.RenameColumn(
                name: "PersonaIdPersona",
                table: "SignoVital",
                newName: "PersonaidPersona");

            migrationBuilder.RenameIndex(
                name: "IX_SignoVital_PersonaIdPersona",
                table: "SignoVital",
                newName: "IX_SignoVital_PersonaidPersona");

            migrationBuilder.RenameColumn(
                name: "PersonaForeignKey",
                table: "Consultorio",
                newName: "PersonaidPersona");

            migrationBuilder.AlterColumn<int>(
                name: "PersonaidPersona",
                table: "SignoVital",
                nullable: false,
                oldClrType: typeof(int),
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_SignoVital_Persona_PersonaidPersona",
                table: "SignoVital",
                column: "PersonaidPersona",
                principalTable: "Persona",
                principalColumn: "IdPersona",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_SignoVital_Persona_PersonaidPersona",
                table: "SignoVital");

            migrationBuilder.RenameColumn(
                name: "PersonaidPersona",
                table: "SignoVital",
                newName: "PersonaIdPersona");

            migrationBuilder.RenameIndex(
                name: "IX_SignoVital_PersonaidPersona",
                table: "SignoVital",
                newName: "IX_SignoVital_PersonaIdPersona");

            migrationBuilder.RenameColumn(
                name: "PersonaidPersona",
                table: "Consultorio",
                newName: "PersonaForeignKey");

            migrationBuilder.AlterColumn<int>(
                name: "PersonaIdPersona",
                table: "SignoVital",
                nullable: true,
                oldClrType: typeof(int));

            migrationBuilder.CreateIndex(
                name: "IX_Consultorio_PersonaForeignKey",
                table: "Consultorio",
                column: "PersonaForeignKey",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Consultorio_Persona_PersonaForeignKey",
                table: "Consultorio",
                column: "PersonaForeignKey",
                principalTable: "Persona",
                principalColumn: "IdPersona",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_SignoVital_Persona_PersonaIdPersona",
                table: "SignoVital",
                column: "PersonaIdPersona",
                principalTable: "Persona",
                principalColumn: "IdPersona",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
