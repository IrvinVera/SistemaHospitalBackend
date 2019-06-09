using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace BackendSistemaHospital.Models
{
    [Table("MedicamentoTratamiento")]
    public class MedicamentoTratamiento
    {
        public int MedicamentoId { get; set; }
        public int TratamientoId { get; set; }

        public Medicamento Medicamento { get; set; }
        public Tratamiento Tratamiento { get; set; }

        public MedicamentoTratamiento() { }

        public MedicamentoTratamiento(int MedicamentoId, int TratamientoId)
        {
            this.MedicamentoId = MedicamentoId;
            this.TratamientoId = TratamientoId;
        }

    }

}
