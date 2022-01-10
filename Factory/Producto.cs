using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Factory
{
    public class Producto
    {
       public int Id { get; set; }
      public  string Nombre { get; set; }

        [Display(Name = "Valor venta con iva")]
        public decimal ValorVentaConIva { get; set; }

        [Display(Name = "Valor venta sin iva")]
        public decimal ValorentaSinIVA { get; set; }

        [Display(Name = "Unidades en stock")]
        public int CantidadUnidadesInventario { get; set; }

        [Display(Name = "Iva aplicado")]
        public decimal PorcentajeIVAAplicado { get; set; }
        
    }
}
