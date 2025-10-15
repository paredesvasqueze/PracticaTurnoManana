using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models
{
    public class Paciente
    {
        [Key]
        [Required(ErrorMessage = "El Id del paciente es obligatorio")]
        public int nIdPaciente { get; set; }

        [Required(ErrorMessage = "El DNI es obligatorio")]
        [StringLength(15, ErrorMessage = "El DNI no puede tener más de 15 caracteres")]
        public string cDNI { get; set; }

        [Required(ErrorMessage = "El nombre es obligatorio")]
        [StringLength(100, ErrorMessage = "El nombre no puede tener más de 100 caracteres")]
        public string cNombre { get; set; }

        [Required(ErrorMessage = "El apellido es obligatorio")]
        [StringLength(100, ErrorMessage = "El apellido no puede tener más de 100 caracteres")]
        public string cApellido { get; set; }

        [Required(ErrorMessage = "La fecha de nacimiento es obligatoria")]
        [DataType(DataType.Date)]
        public DateTime dFechaNacimiento { get; set; }

        [Required(ErrorMessage = "El sexo es obligatorio")]
        [RegularExpression("^[MF]$", ErrorMessage = "El sexo debe ser 'M' o 'F'")]
        public string cSexo { get; set; }

        [StringLength(200, ErrorMessage = "La dirección no puede tener más de 200 caracteres")]
        public string cDireccion { get; set; }

        [StringLength(20, ErrorMessage = "El teléfono no puede tener más de 20 caracteres")]
        public string cTelefono { get; set; }

        [EmailAddress(ErrorMessage = "El correo electrónico no es válido")]
        [StringLength(100, ErrorMessage = "El correo no puede tener más de 100 caracteres")]
        public string cCorreo { get; set; }

        [StringLength(5, ErrorMessage = "El tipo de sangre no puede tener más de 5 caracteres")]
        public string cTipoSangre { get; set; }

        [StringLength(200, ErrorMessage = "Las alergias no pueden tener más de 200 caracteres")]
        public string cAlergias { get; set; }
    }
}
