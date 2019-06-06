using BackendHospital.Abstracta;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BackendHospital.InterfacesPersistencia
{
    interface IPersonaPersistencia
    {

        bool registrarBD(APersona persona);

    }
}
