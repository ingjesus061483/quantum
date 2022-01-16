using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Factory
{
    public class TipoIdentificacion
    {
        public int Id { get; set; }

        [Display(Name = "Tipo Identificacion")]
        public string Nombre { get; set; }
    }
}
