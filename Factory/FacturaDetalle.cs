using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Factory
{
    public class FacturaDetalle
    {
       public int Id { get; set; }
       public FacturaEncabezado factura { get; set; }
      public Producto producto { get; set; }
     public int cantidad { get; set; }

        [Display(Name = "Valor unitario")]
        public decimal ValorUnitario { get; set; }

        [Display(Name = "Valor unitario con iva")]
        public decimal ValorUnitarioIva { get; set; }
        
        [Display(Name = "Total con iva")]
        public decimal totalIva { get { return ValorUnitarioIva * cantidad; } }

        [Display(Name = "Total sin iva")]
        public decimal total { get { return ValorUnitario * cantidad; } }
    }
}
