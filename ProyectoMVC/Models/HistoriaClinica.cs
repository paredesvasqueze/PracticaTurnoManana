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
        // El Id se maneja automáticamente por la base de datos, no se incluye en el insert
        [Required(ErrorMessage = "El Id del paciente es obligatorio")]
        public int nIdHistoria { get; set; }  // Id del paciente

        [Required(ErrorMessage = "La fecha de registro es obligatoria")]
        public DateTime dFechaRegistro { get; set; }  // Fecha de registro

        [Required(ErrorMessage = "La fecha es obligatoria")]
        public DateTime Fecha { get; set; }

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

