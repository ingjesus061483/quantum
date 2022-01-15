using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
namespace Factory
{
    public class FacturaEncabezado
    {
        public int Id { get; set; }
        public Usuario Cliente { get; set; }
        
        [Display(Name = "Fecha de venta")]
        public DateTime FechaVenta { get; set; }

        [Display(Name = "Fecha de envio")]
        public DateTime FechaEnvio { get; set; }

        public List<FacturaDetalle> Detalles { get; set; }
        public decimal TotalPagar
        {
            get
            {
                decimal suma = 0;
                if (Detalles!=null)
                {
                    foreach(var item in Detalles)
                    {
                        suma+= item.Total;
                    }
                }
                return suma;
            }
        }
    }
}
