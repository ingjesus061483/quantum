using Factory;
using Helper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace apiQuantum.Controllers
{
    public class ModulosController : ApiController
    {
        Datoshelper datoshelper;
        // GET api/<controller>
       public ModulosController()
        {
            datoshelper = new Datoshelper();
        }
        public IEnumerable<Modulo> Get()
        {
            try
            {
                List<Modulo> modulos = datoshelper.GetModulos();
                return modulos;
            }
            catch(Exception ex)
            {
                throw ex;
            }
        }

        // GET api/<controller>/5
        public Modulo Get(int id)
        {
            try
            {

                List<Modulo> modulos = datoshelper.GetModulos();
                Modulo modulo = modulos.Find(x => x.Id == id);
                return modulo;
            }
            catch(Exception ex)
            {
                throw ex; 
            }
        }

        // POST api/<controller>
        public void Post([FromBody] string value)
        {
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