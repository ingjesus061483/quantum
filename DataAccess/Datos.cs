using System;
using System.Data.SqlClient;
using System.Data;
using System.Configuration;
namespace DataAccess
{
    public class Datos
    { 
        DataTable table; SqlConnection conexion; SqlCommand comand; SqlDataAdapter adapter; DataSet bd;
        string NombreCadena = "PruebaQuantum"; 
        string CadenaConexion { 
            get 
            { 
                return ConfigurationManager.ConnectionStrings[NombreCadena].ConnectionString; 
            }
        }
        public Datos()
        {
            conexion = new SqlConnection { ConnectionString = CadenaConexion };
        }
        /// <summary>
        /// Abre una conexion
        /// </summary>
        void AbrirConexion()
        {
            try
            {
                if (conexion.State == ConnectionState.Closed)
                    conexion.Open();

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        /// <summary>
        /// Cierra una conexion
        /// </summary>
        void CerrarConexion()
        {
            try
            {
                if (conexion.State == ConnectionState.Open)
                    conexion.Close();
            }

            catch (Exception ex)
            {
                throw ex;
            }
        }
        
        /// <summary>
        ///Inicia una consulta a la base de datos 
        /// </summary>
        /// <param name="con"></param>
        /// <param name="comandtype"></param>
        /// <param name="query"></param>
        /// <returns></returns>
        SqlCommand InicializarComando(SqlConnection con, CommandType comandtype, string query)
        {
            SqlCommand com;
            com = new SqlCommand
            {
                Connection = con,
                CommandType = comandtype,
                CommandText = query
            };
            return com;
        }

    
        /// <summary>
        /// llena los ddatos en una dataset
        /// </summary>
        /// <param name="comando"></param>
        /// <returns></returns>
        DataSet LlenarDataset(SqlCommand comando)
        {
            try
            {
                DataSet bdatos = new DataSet();
                adapter = new SqlDataAdapter
                {
                    SelectCommand = comando
                };
                adapter.Fill(bdatos);
                return bdatos;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public DataTable SeleccionTabla(string tabla)
        {
            try
            {
                AbrirConexion();
                comand = InicializarComando(conexion, CommandType.Text, "select id,nombre from " + tabla);
                bd = LlenarDataset(comand);
               table = bd.Tables[0];
                bd = null;
                return table;
            }
            catch(Exception ex)
            {
                throw ex;
            }
            finally
            {
                CerrarConexion();
            }
        }
        public int InsertarEncabezado(int idCliente ,DateTime  fechaVenta ,DateTime  fechaEnvio )
        {
            try
            {
                AbrirConexion();
                comand = InicializarComando(conexion, CommandType.StoredProcedure, "InsertarEncabezado");
                comand.Parameters.Add("idCliente", SqlDbType.Int).Value = idCliente;
                comand.Parameters.Add("fechaVenta", SqlDbType.DateTime).Value = fechaVenta;
                comand.Parameters.Add("fechaEnvio", SqlDbType.DateTime).Value = fechaEnvio;                
                int id = 0;
                int.TryParse(comand.ExecuteScalar().ToString(), out id);

                return id;
            }
            catch(Exception ex)
            {
                throw ex;
            }
            finally
            {
                CerrarConexion();
            }
        }
        public void InsertarDetalles(int idfactura , int idProducto , decimal cantidad, decimal valorUnitario, decimal valorunitarioIva)
        {
            try
            {
                AbrirConexion();
                comand = InicializarComando(conexion, CommandType.StoredProcedure, "Insertardetalles");
                comand.Parameters.Add("idfactura", SqlDbType.Int).Value = idfactura;
                comand.Parameters.Add("idProducto", SqlDbType.Int).Value = idProducto;
                comand.Parameters.Add("cantidad", SqlDbType.Decimal).Value = cantidad;
                comand.Parameters.Add("valorUnitario", SqlDbType.Decimal).Value = valorUnitario;
                comand.Parameters.Add("valorunitarioIva", SqlDbType.Decimal).Value = valorunitarioIva;
                comand.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                CerrarConexion();
            }
        }

        public void InsertarUsuario(int idtipoidentificacion, string identificacion, string nombre, string apellido, string direccion,
            string telefono,string email ,string nombreUsuario,string contraseña,int idperfil )
        {
            try
            {
                AbrirConexion();
                comand = InicializarComando(conexion, CommandType.StoredProcedure, "InsertarUsuarios");
                comand.Parameters.Add("idtipoidentificacion", SqlDbType.Int).Value = idtipoidentificacion;
                comand.Parameters.Add("identificacion", SqlDbType.VarChar).Value = identificacion;
                comand.Parameters.Add("nombre", SqlDbType.VarChar).Value = nombre;
                comand.Parameters.Add("apellido", SqlDbType.VarChar).Value = apellido;
                comand.Parameters.Add("direccion", SqlDbType.VarChar).Value = direccion;
                comand.Parameters.Add("telefono", SqlDbType.VarChar).Value = telefono;
                comand.Parameters.Add("email", SqlDbType.VarChar).Value = email;
                comand.Parameters.Add("nombreUsuario", SqlDbType.VarChar).Value = nombreUsuario;
                comand.Parameters.Add("contraseña", SqlDbType.VarChar).Value = contraseña;
                comand.Parameters.Add("idperfil", SqlDbType.Int).Value = idperfil;
                comand.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                CerrarConexion();
            }
        }
        public DataRow BuscarClientes(string identificacion)
        {
            try
            {
                AbrirConexion();
                comand = InicializarComando(conexion, CommandType.StoredProcedure, "BuscarClientes");
                comand.Parameters.Add("identificacion", SqlDbType.VarChar).Value = identificacion;
                bd = LlenarDataset(comand);
                DataRow row = null;
                table = bd.Tables[0];
                bd = null;
                if(table .Rows .Count >0)
                {
                    row = table.Rows[0];
                }
                return row;
            }
            catch(Exception ex)
            { 
                throw ex; 
            
            }
            finally
            {
                CerrarConexion();
            }

        }
        public DataTable ListarUsuarios()
        {
            try
            {
                AbrirConexion();
                comand = InicializarComando(conexion, CommandType.StoredProcedure, "ListarUsuarios");
                bd = LlenarDataset(comand);
               
                table = bd.Tables[0];
                bd = null;
                return table;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                CerrarConexion();
            }
        }
        public DataTable ListarProducto()
        {
            try
            {
                AbrirConexion();
                comand = InicializarComando(conexion, CommandType.StoredProcedure, "listarproducto");
                bd = LlenarDataset(comand);
                table= bd.Tables[0];
                bd = null;
                return table;
            }
            catch(Exception ex)
            {
                throw ex;
            }
            finally
            {
                CerrarConexion();
            }
        }
        public DataTable Listarmodulos()
        {
            try
            {
                AbrirConexion();
                comand = InicializarComando(conexion, CommandType.StoredProcedure, "Listarmodulos");
                bd = LlenarDataset(comand);
                table = bd.Tables[0];
                bd = null;
                return table;

            }
            catch(Exception ex)
            {
                throw ex;
            }
            finally
            {
                CerrarConexion();
            }
        }
        public DataTable ListarPermisos()
        {
            try
            {
                AbrirConexion();
                comand = InicializarComando(conexion, CommandType.StoredProcedure, "ListarPermisos");
                bd = LlenarDataset(comand);
                table = bd.Tables[0];
                bd = null;
                return table;
            }
            catch(Exception ex)
            {
                throw ex;
            }
            finally
            {
                CerrarConexion();
            }
        }
        public DataTable ListarPerfiles()
        {
            try
            {
                AbrirConexion();
                comand = InicializarComando(conexion, CommandType.StoredProcedure, "listarPerfiles");
                bd = LlenarDataset(comand);
                table = bd.Tables[0];
                bd = null;
                return table;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                CerrarConexion();
            }
        }
        public void EditarUsuarios(int id, int idtipoidentificacion, string identificacion, string nombre, string apellido, string direccion,
            string telefono, string email, string nombreUsuario, string contraseña, int idperfil)
        {
            try
            {
                AbrirConexion();
                comand = InicializarComando(conexion, CommandType.StoredProcedure, "EditarUsuarios");
                comand.Parameters.Add("id", SqlDbType.Int).Value = id;
                comand.Parameters.Add("idtipoidentificacion", SqlDbType.Int).Value = idtipoidentificacion;
                comand.Parameters.Add("identificacion", SqlDbType.VarChar).Value = identificacion;
                comand.Parameters.Add("nombre", SqlDbType.VarChar).Value = nombre;
                comand.Parameters.Add("apellido", SqlDbType.VarChar).Value = apellido;
                comand.Parameters.Add("direccion", SqlDbType.VarChar).Value = direccion;
                comand.Parameters.Add("telefono", SqlDbType.VarChar).Value = telefono;
                comand.Parameters.Add("email", SqlDbType.VarChar).Value = email;
               // comand.Parameters.Add("nombreUsuario", SqlDbType.VarChar).Value = nombreUsuario;
                comand.Parameters.Add("contraseña", SqlDbType.VarChar).Value = contraseña;
                comand.Parameters.Add("idperfil", SqlDbType.Int).Value = idperfil;
                comand.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                CerrarConexion();
            }            
        }
        public DataRow BuscarModulo(int id)
        { 
            try
            {
                AbrirConexion();
                comand = InicializarComando(conexion, CommandType.StoredProcedure, "Buscarmodulo");
                comand.Parameters.Add("id", SqlDbType.Int).Value = id;
                bd = LlenarDataset(comand);
                DataRow row = null;
                table = bd.Tables[0];
                bd = null;
                if (table.Rows.Count > 0)
                {
                    row = table.Rows[0];
                }
                return row;

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public DataRow BuscarPerfil(int id)
        {
            try
            {
                AbrirConexion();
                comand = InicializarComando(conexion, CommandType.StoredProcedure, "Buscarperfil");
                comand.Parameters.Add("id", SqlDbType.Int).Value = id;
                bd = LlenarDataset(comand);
                DataRow row = null;                
                table = bd.Tables[0];
                bd = null;
                if (table.Rows.Count > 0)
                {
                    row = table.Rows[0];
                }
                return row;              
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public void InsertarProducto( string  Nombre,decimal ValorVentaConIva       , int CantidadUnidadesInventario , decimal PorcentajeIVAAplicado)
        {
            try
            {
                AbrirConexion();
                comand = InicializarComando(conexion, CommandType.StoredProcedure, "InsertarProducto");
                comand.Parameters.Add("Nombre", SqlDbType.VarChar).Value = Nombre;
                comand.Parameters.Add("ValorVentaConIva", SqlDbType.Decimal).Value = ValorVentaConIva;
                comand.Parameters.Add("CantidadUnidadesInventario", SqlDbType.Int).Value = CantidadUnidadesInventario;
                comand.Parameters.Add("PorcentajeIVAAplicado", SqlDbType.Decimal).Value = PorcentajeIVAAplicado;
                comand.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                CerrarConexion();
            }
        }
   


    }
}
