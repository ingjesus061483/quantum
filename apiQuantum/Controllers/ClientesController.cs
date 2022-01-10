using Factory;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Helper;
namespace apiQuantum
{
    public class ClientesController : ApiController
    {
        Datoshelper datoshelper;
        public ClientesController()
        {
            datoshelper = new Datoshelper();
        }
        // GET api/<controller>
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET api/<controller>/5
        public Cliente Get(string identificacion)
        {
            try
            {
                return datoshelper .BuscarClientes(identificacion );
            }
            catch
            {
                throw;
            }
        }

        // POST api/<controller    identificacion: identificacion, nombre: nombre, apellido: apellido, direccion: direccion, telefono: telefono>
        public Cliente Post([FromBody] Cliente cliente )
        {
            try
            {
                return datoshelper.InsertarClientes(cliente.Identificacion,cliente.Nombre ,cliente .Apellido,cliente .Direccion ,cliente.Telefono );
            }
            catch
            {
                throw;
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