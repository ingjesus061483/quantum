using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Factory
{
   public  class Cliente
    {
      public int Id { get; set; }
      public string Identificacion { get; set; }
       public string Nombre { get; set; }
        public string nombreCompleto { get { return Nombre + " " + Apellido; } }
      public string Apellido { get; set; }
     public string Direccion { get; set; }
       public string Telefono { get; set; }
    }
}
