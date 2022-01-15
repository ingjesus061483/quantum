using System.ComponentModel.DataAnnotations;
namespace Factory
{
    public class FacturaDetalle
    {
        public int Id { get; set; }
        public FacturaEncabezado Factura { get; set; }
        public Producto Producto { get; set; }
        public int Cantidad { get; set; }

        [Display(Name = "Valor unitario")]
        public decimal ValorUnitario { get; set; }

        [Display(Name = "Valor unitario con iva")]
        public decimal ValorUnitarioIva { get; set; }
        
        [Display(Name = "Total con iva")]
        public decimal TotalConIva
        { 
            get 
            { 
                return ValorUnitarioIva * Cantidad;
            } 
        }

        [Display(Name = "Total sin iva")]
        public decimal Total { 
            get 
            { 
                return ValorUnitario * Cantidad; 
            } 
        }
    }
}
