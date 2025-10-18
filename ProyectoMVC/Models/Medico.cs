using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models
{
    public class Medico
    {
        [Required(ErrorMessage = "El Id es obligatorio")]
        public int nIdMedico { get; set; }

        [Required(ErrorMessage = "El CMP es obligatorio")]
        [StringLength(15, ErrorMessage = "El Código de colegiatura no puede tener más de 15 caracteres")]
        public string cCMP { get; set; }

        [Required(ErrorMessage = "El nombre es obligatorio")]
        [StringLength(100, ErrorMessage = "El nombre no puede tener más de 100 caracteres")]
        public string cNombre { get; set; }

        [Required(ErrorMessage = "El apellido es obligatorio")]
        [StringLength(100, ErrorMessage = "El apellido no puede tener más de 100 caracteres")]
        public string cApellido { get; set; }

        [Required(ErrorMessage = "La especialidad es obligatoria")]
        [StringLength(100)]
        public string cEspecialidad { get; set; }

        [Required(ErrorMessage = "El teléfono es obligatorio")]
        [StringLength(20, ErrorMessage = "El teléfono no debe tener más de 20 dígitos")]
        public string cTelefono { get; set; }

        [Required(ErrorMessage = "El correo es obligatorio")]
        [StringLength(100, ErrorMessage = "El correo no puede tener más de 100 caracteres")]
        [EmailAddress(ErrorMessage = "El formato del correo no es válido")]
        public string cCorreo { get; set; }
    }
}
