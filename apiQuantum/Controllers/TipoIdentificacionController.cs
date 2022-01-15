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
    public class TipoIdentificacionController : ApiController
    {
        Datoshelper datoshelper;
        public TipoIdentificacionController()
        {
            datoshelper = new Datoshelper();
        }
        // GET api/<controller>
        public IEnumerable<TipoIdentificacion> Get()
        {
            try
            {
                return datoshelper.GetTiposIdentificacion();
            }
            catch(Exception ex)
            {
                throw ex;
            }
        }

        // GET api/<controller>/5
        public TipoIdentificacion   Get(int id)
        {
            try
            {
                List<TipoIdentificacion > tiposIdentificacion = datoshelper.GetTiposIdentificacion();
                TipoIdentificacion tipoIdentificacion = tiposIdentificacion .Find(x => x.Id == id);
                if (tipoIdentificacion == null)
                {
                    throw new Exception("Escoja un tipo de identificacion valido");
                }

                return tipoIdentificacion ;
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