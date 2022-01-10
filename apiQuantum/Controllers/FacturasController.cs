using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Factory;
using Helper;
namespace apiQuantum.Controllers
{
    public class FacturasController : ApiController
    {
        Datoshelper datoshelper;
        public FacturasController()
        {
            datoshelper = new Datoshelper();
        }
        // GET api/<controller>
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET api/<controller>/5
        public string Get(int id)
        {
            return "value";
        }

        // POST api/<controller>
        public void Post([FromBody] FacturaEncabezado encabezado)
        {
            try
            {
                datoshelper.insertarFactura(encabezado);
            }
            catch
            {

            }
        }

        // PUT api/<controller>/5
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<controller>/5
        public void Delete(int id)
        {
        }
    }
}