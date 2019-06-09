using BackendSistemaHospital.Abstractas;
using BackendSistemaHospital.Interfaces;
using BackendSistemaHospital.InterfacesPersistencia;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BackendSistemaHospital.Concretas
{
    public class RecetaImp : IReceta
    {

        private IRecetaPersistencia recetaPersistencia;

        public RecetaImp(IRecetaPersistencia recetaPersistencia)
        {
            this.recetaPersistencia = recetaPersistencia;
        }
        public bool Registrar(AReceta receta)
        {
            return this.recetaPersistencia.RegistrarBD(receta);

        }
            

        
    }
}
