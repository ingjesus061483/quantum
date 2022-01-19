using System;
using System.Collections.Generic;
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
        public void InsertarFactura(FacturaEncabezado factura)
        {
            try
            {
                int id = datos.InsertarEncabezado(factura.Cliente.Id, factura.FechaVenta, factura.FechaEnvio);
                foreach (var item in factura.Detalles)
                {
                    datos.InsertarDetalles(id, item.Producto.Id, item.Cantidad, item.ValorUnitario, item.ValorUnitarioIva);

                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public void EliminarPermisos(int id)
        {
            try
            {
                datos.EliminarPermisos(id);
            }
            catch(Exception ex)
            {
                throw ex;
            }
        }
        Modulo BuscarModulo(int id)
        {
            try
            {
                DataRow row = datos.BuscarModulo(id);
                Modulo modulo = null;
                modulo = new Modulo();
                if (row != null)
                {

                    modulo = new Modulo
                    {
                        Id = (int)row["id"],
                        Nombre = row["nombre"].ToString(),
                        Descripcion = row["descripcion"].ToString(),
                     //   Permisos = GetPermisos().FindAll(x => x.Modulo .Id==(int)row ["id"])

                    };
                }
                return modulo;
            }
            catch(Exception ex)
            { 
                throw ex; 
            }

        }
        public List<Permiso> GetPermisos()
        {
            try
            {
                List<Perfil> perfiles = GetPerfiles();
                List<Modulo> modulos = GetModulos();                 
                List<Permiso>permisos= GetPermisos(perfiles, modulos);
                return permisos;
            }
            catch(Exception ex)
            {
                throw ex;
            }
        }
        public List<Permiso >GetPermisos(List<Perfil>perfiles,List <Modulo>modulos)
        {
            try
            {
                List<Permiso> permisos = new List<Permiso>();
                table = datos.ListarPermisos();
                foreach(DataRow row in table .Rows )
                {
                    Permiso permiso = new Permiso
                    {
                        Id = (int)row["id"],
                        Perfil = perfiles .Find (x=>x.Id ==(int)row["idperfil"]),
                        Modulo = modulos.Find (x=>x.Id==(int)row["idmodulo"]),
                        ValorPermiso = row["ValorPermiso"].ToString()
                    };
                    permisos.Add(permiso);
                }
                return permisos;
            }
            catch (Exception ex)
            {
                throw ex;

            }

        }
        Perfil BuscarPerfil(int id)
        {
            try
            {
                DataRow row = datos.BuscarPerfil(id);
                Perfil perfil =null;
                if (row != null)
                {
                    perfil = new Perfil
                    {
                        Id = (int)row["id"],
                        Nombre = row["nombre"].ToString(),
                        Descripcion = row["descripcion"].ToString()
                    };
                }
                return perfil;
            }
            catch(Exception ex)
            {
                throw ex;
            }

        }


        public List<Perfil >GetPerfiles(List <Permiso>permisos)
        {
            try
            {
                List<Perfil> perfiles = new List<Perfil>();
               
                table = datos.ListarPerfiles();
                foreach (DataRow row in table.Rows)
                {
                    Perfil perfil = new Perfil
                    {
                        Id = (int)row["id"],
                        Nombre = row["nombre"].ToString(),
                        Descripcion = row["descripcion"].ToString(),
                        Permisos = permisos .FindAll(x => x.Perfil.Id == (int)row["id"])

                    };
                    perfiles.Add(perfil);
                }
                return perfiles;
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }
        public List<Perfil> GetPerfiles()
        {
            try
            {
                List<Perfil> perfiles = new List<Perfil>();
                 
                table = datos.ListarPerfiles();
                foreach (DataRow row in table.Rows)
                {
                    Perfil perfil = new Perfil
                    {
                        Id = (int)row["id"],
                        Nombre = row["nombre"].ToString(),
                        Descripcion = row["descripcion"].ToString(),             

                    };
                    perfiles.Add(perfil);
                }
                return perfiles;
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }

        public List<Modulo> GetModulos()
        {
            try
            {
                List<Modulo> modulos = new List<Modulo>();
                table = datos.Listarmodulos();
                foreach(DataRow row in table .Rows)
                {
                    Modulo modulo = new Modulo
                    {
                        Id = (int)row["id"],
                        Nombre = row["nombre"].ToString(),
                        Descripcion = row["descripcion"].ToString()                        
                        
                    };
                    modulos.Add(modulo);
                }
                return modulos;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public List<Modulo> GetModulos(List<Permiso >permisos)
        {
            try
            {
                List<Modulo> modulos = new List<Modulo>();
                table = datos.Listarmodulos();
                foreach (DataRow row in table.Rows)
                {
                    Modulo modulo = new Modulo
                    {
                        Id = (int)row["id"],
                        Nombre = row["nombre"].ToString(),
                        Descripcion = row["descripcion"].ToString(),
                        Permisos = permisos .FindAll(x => x.Modulo.Id == (int)row["id"])

                    };
                    modulos.Add(modulo);
                }
                return modulos;
            }
            catch (Exception ex)
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
                foreach (DataRow row in table.Rows)
                {
                    Producto producto = new Producto
                    {
                        Id = (int)row["id"],
                        Nombre = row["nombre"].ToString(),
                        CantidadUnidadesInventario = (int)row["CantidadUnidadesInventario"],
                        ValorVentaConIva = (decimal)row["ValorVentaConIva"],
                        PorcentajeIVAAplicado = (decimal)row["PorcentajeIVAAplicado"]
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
        public void InsertarProducto(string Nombre, decimal ValorVentaConIva, int CantidadUnidadesInventario, decimal PorcentajeIVAAplicado)
        {
            try
            {
                datos.InsertarProducto(Nombre, ValorVentaConIva, CantidadUnidadesInventario, PorcentajeIVAAplicado);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public void EditarUsuarios(Usuario usuario)
        {
            try
            {
                datos.EditarUsuarios(usuario.Id , usuario.TipoIdentificacion.Id, usuario.Identificacion, usuario.Nombre,
                    usuario.Apellido, usuario.Direccion, usuario.Telefono, usuario.Email, usuario.NombreUsuario,
                    usuario.Contraseña, usuario.Perfil.Id);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public void InsertarPermisos(Permiso permiso)
        {
            try
            {
                datos.InsertarPermisos(permiso.Perfil.Id, permiso.Modulo.Id, permiso.ValorPermiso);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public void  InsertarUsuarios(Usuario usuario)
        {
            try
            {
                datos.InsertarUsuario(usuario.TipoIdentificacion.Id,usuario.Identificacion,usuario.Nombre,
                    usuario.Apellido,usuario.Direccion,usuario.Telefono,usuario.Email,usuario.NombreUsuario,
                    usuario.Contraseña,usuario.Perfil.Id);
               
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public List <TipoIdentificacion > GetTiposIdentificacion()
        {
            try
            {
                List<TipoIdentificacion> tiposIdentificacion = new List<TipoIdentificacion>();
                table = datos.SeleccionTabla("TipoIdentificacion");
                foreach (DataRow row in table.Rows)
                {
                    TipoIdentificacion tipoIdentificacion = new TipoIdentificacion
                    {
                        Id = (int)row["id"],
                        Nombre = row["nombre"].ToString()
                    };
                    tiposIdentificacion.Add(tipoIdentificacion);
                }
                return tiposIdentificacion;
            }
            catch  (Exception ex)
            {
                throw ex;
            }
        }
        public List <Usuario>GetUsuarios()
        {
            try
            {
                List<Usuario> usuarios = new List<Usuario>();
              
                List<Perfil> perfiles = GetPerfiles();
                List<Modulo> modulos = GetModulos();
                List<Permiso> permisos = GetPermisos(perfiles,modulos );
                table = datos.ListarUsuarios();
                foreach (DataRow row in table.Rows )
                {
                    Usuario usuario = new Usuario
                    {
                        Id = (int)row["id"],
                        TipoIdentificacion = GetTiposIdentificacion().Find(x => x.Id == (int)row["idtipoidentificacion"]),
                        Identificacion = row["identificacion"].ToString(),
                        Nombre = row["nombre"].ToString(),
                        Apellido = row["apellido"].ToString(),
                        Direccion = row["direccion"].ToString(),
                        Telefono = row["telefono"].ToString(),
                        Email = row["email"].ToString(),
                        NombreUsuario = row["nombreusuario"].ToString(),
                        Contraseña = row["contraseña"].ToString(),
                        Perfil = GetPerfiles(permisos ).Find(x => x.Id == (int)row["idperfil"])

                    };
                    usuarios.Add(usuario);
                }
                return usuarios;
            }
            catch(Exception ex)
            {
                throw ex;
            }
        }

        public Usuario BuscarClientes(string identificacion)
        {
            try
            {
                DataRow row = datos.BuscarClientes(identificacion);
                Usuario cliente = null;
                if(row!=null)
                {
                    cliente = new Usuario
                    {
                        Id = (int)row["id"],                        
                        Identificacion = row["identificacion"].ToString(),
                        Nombre = row["nombre"].ToString(),
                        Apellido = row["apellido"].ToString(),
                        Direccion = row["direccion"].ToString(),
                        Telefono = row["telefono"].ToString(),

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
