using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Factory
{
    public class Permiso
    {
        public int Id { get; set; }
        public Perfil Perfil { get; set; }
        public Modulo Modulo { get; set; }
        public string ValorPermiso { get; set; }
    }
}
