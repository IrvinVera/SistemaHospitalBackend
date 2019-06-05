using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace BackendSistemaHospital.Migrations
{
    public partial class CreacionBD : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Medicamento",
                columns: table => new
                {
                    IdMedicamento = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Cantidad = table.Column<int>(nullable: false),
                    Compuesto = table.Column<string>(nullable: false),
                    Nombre = table.Column<string>(nullable: false),
                    Presentacion = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Medicamento", x => x.IdMedicamento);
                });

            migrationBuilder.CreateTable(
                name: "Persona",
                columns: table => new
                {
                    IdPersona = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Nombre = table.Column<string>(nullable: false),
                    Apellidos = table.Column<string>(nullable: false),
                    Correo = table.Column<string>(nullable: false),
                    Telefono = table.Column<string>(nullable: false),
                    Genero = table.Column<string>(nullable: false),
                    Rol = table.Column<string>(nullable: false),
                    FechaNacimiento = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Persona", x => x.IdPersona);
                });

            migrationBuilder.CreateTable(
                name: "Receta",
                columns: table => new
                {
                    IdReceta = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Observaciones = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Receta", x => x.IdReceta);
                });

            migrationBuilder.CreateTable(
                name: "Consultorio",
                columns: table => new
                {
                    IdConsultorio = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    NumeroConsultorio = table.Column<string>(nullable: false),
                    Estado = table.Column<string>(nullable: false),
                    PersonaForeignKey = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Consultorio", x => x.IdConsultorio);
                    table.ForeignKey(
                        name: "FK_Consultorio_Persona_PersonaForeignKey",
                        column: x => x.PersonaForeignKey,
                        principalTable: "Persona",
                        principalColumn: "IdPersona",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Cuenta",
                columns: table => new
                {
                    IdCuenta = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    NombreUsuario = table.Column<string>(nullable: false),
                    Contrasena = table.Column<string>(nullable: false),
                    PersonaForeignKey = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Cuenta", x => x.IdCuenta);
                    table.ForeignKey(
                        name: "FK_Cuenta_Persona_PersonaForeignKey",
                        column: x => x.PersonaForeignKey,
                        principalTable: "Persona",
                        principalColumn: "IdPersona",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "SignoVital",
                columns: table => new
                {
                    IdSignoVital = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Estatura = table.Column<double>(nullable: false),
                    Peso = table.Column<double>(nullable: false),
                    Fecha = table.Column<DateTime>(nullable: false),
                    Presion = table.Column<double>(nullable: false),
                    Temperatura = table.Column<double>(nullable: false),
                    PersonaIdPersona = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SignoVital", x => x.IdSignoVital);
                    table.ForeignKey(
                        name: "FK_SignoVital_Persona_PersonaIdPersona",
                        column: x => x.PersonaIdPersona,
                        principalTable: "Persona",
                        principalColumn: "IdPersona",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Tratamiento",
                columns: table => new
                {
                    IdTratamiento = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Cantidad = table.Column<int>(nullable: false),
                    Frecuencia = table.Column<string>(nullable: false),
                    Tiempo = table.Column<string>(nullable: false),
                    RecetaIdReceta = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tratamiento", x => x.IdTratamiento);
                    table.ForeignKey(
                        name: "FK_Tratamiento_Receta_RecetaIdReceta",
                        column: x => x.RecetaIdReceta,
                        principalTable: "Receta",
                        principalColumn: "IdReceta",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Consulta",
                columns: table => new
                {
                    IdConsulta = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    HoraInicio = table.Column<DateTime>(nullable: false),
                    HoraFin = table.Column<DateTime>(nullable: false),
                    PersonaIdPersona = table.Column<int>(nullable: true),
                    ConsultorioIdConsultorio = table.Column<int>(nullable: true),
                    RecetaForeignKey = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Consulta", x => x.IdConsulta);
                    table.ForeignKey(
                        name: "FK_Consulta_Consultorio_ConsultorioIdConsultorio",
                        column: x => x.ConsultorioIdConsultorio,
                        principalTable: "Consultorio",
                        principalColumn: "IdConsultorio",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Consulta_Persona_PersonaIdPersona",
                        column: x => x.PersonaIdPersona,
                        principalTable: "Persona",
                        principalColumn: "IdPersona",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Consulta_Receta_RecetaForeignKey",
                        column: x => x.RecetaForeignKey,
                        principalTable: "Receta",
                        principalColumn: "IdReceta",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "MedicamentoTratamiento",
                columns: table => new
                {
                    MedicamentoId = table.Column<int>(nullable: false),
                    TratamientoId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MedicamentoTratamiento", x => new { x.MedicamentoId, x.TratamientoId });
                    table.ForeignKey(
                        name: "FK_MedicamentoTratamiento_Medicamento_MedicamentoId",
                        column: x => x.MedicamentoId,
                        principalTable: "Medicamento",
                        principalColumn: "IdMedicamento",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_MedicamentoTratamiento_Tratamiento_TratamientoId",
                        column: x => x.TratamientoId,
                        principalTable: "Tratamiento",
                        principalColumn: "IdTratamiento",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Consulta_ConsultorioIdConsultorio",
                table: "Consulta",
                column: "ConsultorioIdConsultorio");

            migrationBuilder.CreateIndex(
                name: "IX_Consulta_PersonaIdPersona",
                table: "Consulta",
                column: "PersonaIdPersona");

            migrationBuilder.CreateIndex(
                name: "IX_Consulta_RecetaForeignKey",
                table: "Consulta",
                column: "RecetaForeignKey",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Consultorio_PersonaForeignKey",
                table: "Consultorio",
                column: "PersonaForeignKey",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Cuenta_PersonaForeignKey",
                table: "Cuenta",
                column: "PersonaForeignKey",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_MedicamentoTratamiento_TratamientoId",
                table: "MedicamentoTratamiento",
                column: "TratamientoId");

            migrationBuilder.CreateIndex(
                name: "IX_SignoVital_PersonaIdPersona",
                table: "SignoVital",
                column: "PersonaIdPersona");

            migrationBuilder.CreateIndex(
                name: "IX_Tratamiento_RecetaIdReceta",
                table: "Tratamiento",
                column: "RecetaIdReceta");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Consulta");

            migrationBuilder.DropTable(
                name: "Cuenta");

            migrationBuilder.DropTable(
                name: "MedicamentoTratamiento");

            migrationBuilder.DropTable(
                name: "SignoVital");

            migrationBuilder.DropTable(
                name: "Consultorio");

            migrationBuilder.DropTable(
                name: "Medicamento");

            migrationBuilder.DropTable(
                name: "Tratamiento");

            migrationBuilder.DropTable(
                name: "Persona");

            migrationBuilder.DropTable(
                name: "Receta");
        }
    }
}
