using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models
{
    public class HistoriaClinica
    {
        [Required(ErrorMessage = "El Id del paciente es obligatorio")]
        public int nIdHistoria { get; set; }  // Id de la Historia Clinica

        [Required(ErrorMessage = "El Id del paciente es obligatorio")]
        public int nIdPaciente { get; set; }  // Id del pacientee

        [Required(ErrorMessage = "La fecha de registro es obligatoria")]
        public DateTime dFechaRegistro { get; set; }  // Fecha de registro


        [Required(ErrorMessage = "El diagnóstico es obligatorio")]
        [StringLength(500, ErrorMessage = "El diagnóstico no puede tener más de 500 caracteres")]
        public string cDiagnostico { get; set; }  // Diagnóstico

        [Required(ErrorMessage = "El tratamiento es obligatorio")]
        [StringLength(500, ErrorMessage = "El tratamiento no puede tener más de 500 caracteres")]
        public string cTratamiento { get; set; }  // Tratamiento

        [StringLength(500, ErrorMessage = "Las observaciones no pueden tener más de 500 caracteres")]
        public string cObservaciones { get; set; }  // Observaciones (opcional)
    }
}

