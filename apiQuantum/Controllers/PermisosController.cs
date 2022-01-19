
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
    public class PermisosController : ApiController
    {
        Datoshelper datoshelper;
        public PermisosController(            )
        {
            datoshelper = new Datoshelper();
        }
        // GET api/<controller>
        public IEnumerable<Permiso> Get()
        {
            try
            {
                List<Permiso> permisos = datoshelper.GetPermisos();
                return permisos;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        // GET api/<controller>/5
        public string Get(int id)
        {
            return "value";
        }

        // POST api/<controller>
        public void Post([FromBody] Permiso permiso)
        {
            try
            {
                datoshelper.InsertarPermisos(permiso);
            }
            catch(Exception ex)            { 

                throw ex;
            }
        }

        // PUT api/<controller>/5
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<controller>/5
        public void Delete(int id)
        {
            try
            {
                datoshelper.EliminarPermisos(id);
            }
           catch (Exception ex)
            {
                throw ex;
            }            
        }
    }
}