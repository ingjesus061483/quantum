using System.Collections.Generic;
using Factory;
namespace Helper
{
    public abstract class Logica
    {

        public static decimal TotalPagar(List<FacturaDetalle> detalles)
        {
            decimal sum = 0;
            if (detalles != null)
            {             
                foreach (var item in detalles)
                {
                    sum = item.TotalConIva + sum;
                }
            }
            return sum;
        }
        public static int DevolverCantidad(List<FacturaDetalle> detalles,int id)
        {
            int cantidad = 1;
            if (detalles  != null)
            {                
                FacturaDetalle detalle = detalles.Find(x => x.Producto.Id == id);
                if (detalle != null)
                {
                    cantidad = detalle.Cantidad;
                }
            }
            return cantidad;
        }
        public static Producto BuscarProducto(List <Producto >productos ,int id)
        {
            Producto producto = productos.Find(x => x.Id == id);
            return producto;
        }
        public static void AñadirDetalles(List<FacturaDetalle> detalles, Producto producto, int cantidad, int id)
        {
            
            FacturaDetalle facturaDetalle = detalles.Find(x => x.Producto.Id == id);
            detalles.Remove(facturaDetalle);
            FacturaDetalle detalle = new FacturaDetalle
            {
                Cantidad = cantidad,
                Producto = producto,
                ValorUnitario = producto.ValorentaSinIVA,
                ValorUnitarioIva = producto.ValorVentaConIva
            };
            detalles.Add(detalle);            
        }
    }
}
