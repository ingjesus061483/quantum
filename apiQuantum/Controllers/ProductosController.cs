using Factory;
using System;
using System.Collections.Generic;
using System.Web.Http;
using Helper;
namespace apiQuantum
{
   
    public class ProductosController : ApiController
    {
        Datoshelper datoshelper;
        public ProductosController()
        {
            datoshelper = new Datoshelper();
        }

        // GET api/<controller>
        [HttpGet]
        public IEnumerable<Producto> Get()
        {
            try
            {
                return datoshelper.ListarProducto();
            }
            catch(Exception ex)
            {
                throw ex;
            }
        }

        // POST api/<controller>
        [HttpPost]
        public void Post([FromBody] Producto producto)
        {
            try
            {
                datoshelper.InsertarProducto(producto.Nombre, producto.ValorVentaConIva, producto.CantidadUnidadesInventario, producto.PorcentajeIVAAplicado);

            }
            catch(Exception ex)
            {
                throw ex;
            }
        }

        // PUT api/<controller>/5
        [HttpPut]
        public void Put()
        {

        }
    }
}