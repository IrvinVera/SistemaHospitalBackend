using BackendSistemaHospital.Abstractas;
using BackendSistemaHospital.InterfacesPersistencia;
using BackendSistemaHospital.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BackendSistemaHospital.ConcretasPersistencia
{
    public class SignoVitalPersistencia : ISignoVitalPersistencia
    {
        public List<ASignoVital> ConsultarPorIdBD(int idPersona)
        {

           
            List<SignoVital> signosVitales;
            List<ASignoVital> signosVitalesEncontrados = new List<ASignoVital>();

            var optionsBuilder = new DbContextOptionsBuilder<ApplicationContext>();
            optionsBuilder.UseSqlServer(Startup.urlConexion);
            using (var context = new ApplicationContext(optionsBuilder.Options))
            {
                try
                {

                    signosVitales = context.SignoVital.Where(x => x.PersonaidPersona.Equals(idPersona)).ToList();

                    foreach (SignoVital signoVital in signosVitales)
                    {
                        ASignoVital signoVitalEncontrado = new ASignoVital();

                        signoVitalEncontrado.Estatura = signoVital.Estatura;
                        signoVitalEncontrado.Fecha = signoVital.Fecha;
                        signoVitalEncontrado.IdSignoVital = signoVital.IdSignoVital;
                        signoVitalEncontrado.Peso = signoVital.Peso;
                        signoVitalEncontrado.Presion = signoVital.Presion;
                        signoVitalEncontrado.Temperatura = signoVital.Temperatura;
  
                        signosVitalesEncontrados.Add(signoVitalEncontrado);

                    }


                }
                catch (DbUpdateException)
                {

                }
            }

            return signosVitalesEncontrados;






        }

        public bool RegistrarBD(ASignoVital SignoVital)
        {

            bool seRegistro = true;
            var optionsBuilder = new DbContextOptionsBuilder<ApplicationContext>();
            optionsBuilder.UseSqlServer(Startup.urlConexion);
            using (var context = new ApplicationContext(optionsBuilder.Options))
            {
                try
                {
                    SignoVital SignoVitalBD = new SignoVital(SignoVital);
                    context.Add(SignoVitalBD);
                    context.SaveChanges();
                }
                catch (DbUpdateException)
                {
                    seRegistro = false;
                }

            }
            return seRegistro;




        }



    }
}
