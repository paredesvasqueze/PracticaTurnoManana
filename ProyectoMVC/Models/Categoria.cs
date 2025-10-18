using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models
{
    public class Categoria
    {
        [Required(ErrorMessage = "Debe ingresar una categoría")]
        public int CategoriaId  { get; set; }

        [Required(ErrorMessage = "El nombre de categoría es obligatoria")]
        public string Nombre { get; set; }
    }
}
