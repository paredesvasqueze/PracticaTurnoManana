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
        [Required(ErrorMessage = "El Id es obligatorio")]
        public int Id { get; set; }

        [Required(ErrorMessage = "El ID del paciente es obligatorio")]
        [Range(1, int.MaxValue, ErrorMessage = "El ID del paciente debe ser mayor que cero")]
        public int PacienteId { get; set; }

        [Required(ErrorMessage = "La fecha es obligatoria")]
        public DateTime Fecha { get; set; }

        [Required(ErrorMessage = "El diagnóstico es obligatorio")]
        [StringLength(500, ErrorMessage = "El diagnóstico no puede tener más de 500 caracteres")]
        public string Diagnostico { get; set; }

        [Required(ErrorMessage = "El tratamiento es obligatorio")]
        [StringLength(500, ErrorMessage = "El tratamiento no puede tener más de 500 caracteres")]
        public string Tratamiento { get; set; }
    }
}
