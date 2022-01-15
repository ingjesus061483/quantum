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
    public class PerfilesController : ApiController
    {
        Datoshelper datoshelper;
        public PerfilesController()
        {
            datoshelper = new Datoshelper();
        }
        // GET api/<controller>
        public IEnumerable<Perfil> Get()
        {
            try
            {
                return datoshelper.GetPerfiles();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        // GET api/<controller>/5
        public Perfil  Get(int id)
        {
            try
            {
                List<Perfil> perfiles = datoshelper.GetPerfiles();
                Perfil perfil = perfiles.Find(x => x.Id == id);
                if(perfil ==null)
                    throw new Exception("Escoja un perfil valido");

                return perfil;
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