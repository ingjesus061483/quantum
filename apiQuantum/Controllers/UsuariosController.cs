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
    public class UsuariosController : ApiController
    {
        Datoshelper datoshelper;
        public UsuariosController()
        {
             datoshelper = new Datoshelper();
        }
        // GET api/<controller>
        [HttpGet]
        public IEnumerable<Usuario> Get()
        {
            try
            {
                return datoshelper.GetUsuarios();
            }
            catch(Exception ex)
            {
                throw ex;
            }
        }

        // GET api/<controller>/5
        [HttpGet]
        public Usuario  Get(int id)
        {
            try
            {
                Usuario usuario = datoshelper.GetUsuarios().Find(x => x.Id  == id);
                return usuario;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        [HttpGet]
        public Usuario Get(string user ,string contraseña)
        {
            try
            {
                Usuario usuario = datoshelper.GetUsuarios().Find(x => x.NombreUsuario  == user && x.Contraseña==contraseña  );
                if (usuario == null)
                    throw new Exception("usuario o contraseña invalida");
                return usuario;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        // POST api/<controller>
        [HttpPost]
        public void Post([FromBody] Usuario usuario)
        {
            try
            {
                datoshelper.InsertarUsuarios(usuario);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        // PUT api/<controller>/5

        public void Put( [FromBody] Usuario  usuario )
        {
            try
            {
                datoshelper.EditarUsuarios(usuario);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        // DELETE api/<controller>/5
        public void Delete(int id)
        {
        }
    }
}