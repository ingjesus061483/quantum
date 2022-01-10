using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;
using System.Configuration;
namespace DataAccess
{
    public class Datos
    {
        DataRow row;
        DataTable table;
        SqlConnection conexion;
        SqlCommand comand;
        SqlDataAdapter adapter;
        DataSet bd;
        string NombreCadena = "PruebaQuantum"; //SqlDataReader read;
        string CadenaConexion { get { return ConfigurationManager.ConnectionStrings[NombreCadena].ConnectionString; } }
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

        SqlCommand InicializarComando(SqlConnection con, CommandType comandtype)
        {
            SqlCommand com;
            com = new SqlCommand
            {
                Connection = con,
                CommandType = comandtype
            };
            return com;
        }
        /// <summary>
        /// llena los ddatos en una dataset
        /// </summary>
        /// <param name="comando"></param>
        /// <returns></returns>
        DataSet llenardataset(SqlCommand comando)
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
                bd = llenardataset(comand);
                return bd.Tables[0];
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
        public void Insertardetalles(int idfactura , int idProducto , decimal cantidad, decimal valorUnitario, decimal valorunitarioIva)
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

        public DataRow InsertarClientes(string identificacion, string nombre, string apellido, string direccion, string telefono)
        {
            try
            {
                AbrirConexion();
                comand = InicializarComando(conexion, CommandType.StoredProcedure, "InsertarClientes");
                comand.Parameters.Add("identificacion", SqlDbType.VarChar).Value = identificacion;
                comand.Parameters.Add("nombre", SqlDbType.VarChar).Value = nombre;
                comand.Parameters.Add("apellido", SqlDbType.VarChar).Value = apellido;
                comand.Parameters.Add("direccion", SqlDbType.VarChar).Value = direccion;
                comand.Parameters.Add("telefono", SqlDbType.VarChar).Value = telefono;
                bd = llenardataset(comand);
                table = bd.Tables[0];
                return table.Rows[0];
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
                bd = llenardataset(comand);
                DataRow row = null;
                table = bd.Tables[0];
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
        public DataTable ListarProducto()
        {
            try
            {
                AbrirConexion();
                comand = InicializarComando(conexion, CommandType.StoredProcedure, "listarproducto");
                bd = llenardataset(comand);
                return bd.Tables[0];
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
   


    }
}
