using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models
{
    public class Medicamento
    {
        [Key]
        [Required(ErrorMessage = "El identificador es obligatorio")]
        public int nIdMedicamento { get; set; }

        [Required(ErrorMessage = "El nombre del medicamento es obligatorio")]
        [StringLength(100, ErrorMessage = "El nombre no puede tener más de 100 caracteres")]
        public string cNombre { get; set; }

        [Required(ErrorMessage = "La descripción es obligatoria")]
        [StringLength(200, ErrorMessage = "La descripción no puede tener más de 200 caracteres")]
        public string cDescripcion { get; set; }

        [Required(ErrorMessage = "La presentación es obligatoria")]
        [StringLength(50, ErrorMessage = "La presentación no puede tener más de 50 caracteres")]
        public string cPresentacion { get; set; }

        [Range(0, int.MaxValue, ErrorMessage = "El stock no puede ser negativo")]
        public int nStock { get; set; }

        [Range(0.01, 999999.99, ErrorMessage = "El precio debe ser mayor a 0")]
        public decimal nPrecioUnitario { get; set; }
    }
}
