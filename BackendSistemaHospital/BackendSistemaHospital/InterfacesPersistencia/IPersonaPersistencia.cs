using BackendSistemaHospital.Abstractas;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BackendSistemaHospital.InterfacesPersistencia
{
    public interface IPersonaPersistencia
    {

        APersona RegistrarBD(APersona persona);

        bool EditarBD(APersona persona);

        bool EliminarBD(int idPersona);

        List<APersona> ObtenerPersonasBD();

        APersona BuscarPersonaIdBD(int IdPersona);

        APersona BuscarPersonaNombreBD(string NombrePersona);

        List<APersona> ObtenerMedicosBD();

        APersona BuscarPersonaNombreUsuarioBD(string NombreUsuarioPersona);

        bool validarNombreUsuarioRepetidoBD(String nombreUsuario);

    }
}
