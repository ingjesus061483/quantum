using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using DataAccess;
using Factory;
namespace Helper
{
    public class Datoshelper
    {
        Datos datos;
        DataTable table;    
        public Datoshelper()
        {
            datos = new Datos();
        }
       public void insertarFactura(FacturaEncabezado factura)
        {
            try
            {
                 int id =datos.InsertarEncabezado(factura.Cliente.Id, factura.FechaVenta, factura.FechaEnvio);
                foreach (var item in factura.Detalles)
                {
                    datos.Insertardetalles(id, item.producto.Id, item.cantidad, item.ValorUnitario, item.ValorUnitarioIva);

                }
            }
            catch (Exception ex           )
            {
                throw ex;
            }
        }
        public List<Producto> ListarProducto()
        {
            try
            {
                List<Producto> productos = new List<Producto>();
                table = datos.ListarProducto();
                foreach (DataRow row in table .Rows )
                {
                    Producto producto = new Producto
                    {
                        Id = (int)row ["id"],
                        Nombre=row["nombre"].ToString (),
                        CantidadUnidadesInventario =(int)row["CantidadUnidadesInventario"],
                        ValorentaSinIVA=(decimal )row["ValorentaSinIVA"],
                        ValorVentaConIva=(decimal )row ["ValorVentaConIva"],
                        PorcentajeIVAAplicado =(decimal )row["PorcentajeIVAAplicado"]
                    };
                    productos.Add(producto);
                }
                return productos;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public Cliente InsertarClientes(string identificacion, string nombre, string apellido, string direccion, string telefono)
        {
            try
            {
                DataRow row = datos.InsertarClientes(identificacion, nombre, apellido, direccion, telefono);
                Cliente cliente = null;
                if (row != null)
                {
                    cliente = new Cliente
                    {
                        Id = (int)row["id"],
                        Identificacion = row["identificacion"].ToString(),
                        Nombre = row["nombre"].ToString(),
                        Apellido = row["apellido"].ToString(),
                        Direccion = row["direccion"].ToString(),
                        Telefono = row["telefono"].ToString()

                    };
                }
                return cliente;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public Cliente BuscarClientes(string identificacion)
        {
            try
            {
                DataRow row = datos.BuscarClientes(identificacion);
                Cliente cliente = null;
                if(row!=null)
                {
                    cliente = new Cliente
                    {
                        Id = (int)row["id"],
                        Identificacion = row["identificacion"].ToString(),
                        Nombre = row["nombre"].ToString(),
                        Apellido = row["apellido"].ToString(),
                        Direccion = row["direccion"].ToString(),
                        Telefono = row["telefono"].ToString()

                    };                   
                }
                return cliente;
            }
            catch(Exception ex)
            {
                throw ex;
            }
        }
    }
}
