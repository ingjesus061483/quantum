using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Factory
{
    public class Perfil
    {
        public int Id { get; set; }

        [Display(Name = "Perfil")]
        public string Nombre { get; set; }
        public string Descripcion { get; set; }
        public List<Permiso> Permisos { get; set; }
    }
}
