using System.ComponentModel.DataAnnotations;
namespace Factory
{
    public class Producto
    {
        decimal _PorcentajeIVAAplicado;
        public int Id { get; set; }
        public  string Nombre { get; set; }

        [Display(Name = "Valor venta con iva")]
        public decimal ValorVentaConIva { get; set; }              

        [Display(Name = "Unidades en stock")]
        public int CantidadUnidadesInventario { get; set; }

        [Display(Name = "Valor venta sin iva")]
        public decimal ValorentaSinIVA 
        { 
            get 
            { 
                return ValorVentaConIva / (1 + PorcentajeIVAAplicado); 
            } 
        }

        [Display(Name = "Iva aplicado")]        
        public decimal PorcentajeIVAAplicado 
        {             
            get 
            {
                return _PorcentajeIVAAplicado / 100; 
            }
            set
            { 
                _PorcentajeIVAAplicado = value;
            } 
        }
        
    }
}
