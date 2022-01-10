using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Factory
{
    public class FacturaEncabezado
    {
        public int Id { get; set; }
        public Cliente Cliente { get; set; }
        
        [Display(Name = "Fecha de venta")]
        public DateTime FechaVenta { get; set; }

        [Display(Name = "Fecha de envio")]
        public DateTime FechaEnvio { get; set; }

        public List<FacturaDetalle> Detalles { get; set; }
    }
}
