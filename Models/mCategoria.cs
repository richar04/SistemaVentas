using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Data;
using System.Data.SqlClient;

namespace Models
{
    public class mCategoria
    {
        private int _IdCategoria;
        private string _Nombre;
        private string _Descripcion;

        private string _TextoBuscar;


        //encapsulamiento
        public int IdCategoria { get => _IdCategoria; set => _IdCategoria = value; }
        public string Nombre { get => _Nombre; set => _Nombre = value; }
        public string Descripcion { get => _Descripcion; set => _Descripcion = value; }
        public string TextoBuscar { get => _TextoBuscar; set => _TextoBuscar = value; }


        //constructor vacio
        public mCategoria()
        {

        }


        //constructor(param)
        public mCategoria(int idCategoria, string nombre, string descripcion, string textoBuscar)
        {
            this.IdCategoria = idCategoria;
            this.Nombre = nombre;
            this.Descripcion = descripcion;

            this.TextoBuscar = textoBuscar;
        }


        //methods-insert
        public string Insertar(mCategoria Categoria)
        {
            string respuesta = "";
            SqlConnection SqlCon = new SqlConnection();
            try
            {
                //codigo para insertar
                SqlCon.ConnectionString = Conexion.Cn;
                SqlCon.Open();

                SqlCommand SqlCmd = new SqlCommand();
                SqlCmd.Connection = SqlCon;
                SqlCmd.CommandText = "spinsertar_categoria";
                SqlCmd.CommandType = CommandType.StoredProcedure;

                SqlParameter ParamIdCategoria = new SqlParameter();
                ParamIdCategoria.ParameterName = "@idcategoria";
                ParamIdCategoria.SqlDbType = SqlDbType.Int;
                ParamIdCategoria.Direction = ParameterDirection.Output;
                SqlCmd.Parameters.Add(ParamIdCategoria);

                SqlParameter ParamNombre = new SqlParameter();
                ParamNombre.ParameterName = "@nombre";
                ParamNombre.SqlDbType = SqlDbType.VarChar;
                ParamNombre.Size = 50;
                ParamNombre.Value = Categoria.Nombre;
                SqlCmd.Parameters.Add(ParamNombre);

                SqlParameter ParamDescripcion = new SqlParameter();
                ParamDescripcion.ParameterName = "@descripcion";
                ParamDescripcion.SqlDbType = SqlDbType.VarChar;
                ParamDescripcion.Size = 256;
                ParamDescripcion.Value = Categoria.Descripcion;
                SqlCmd.Parameters.Add(ParamDescripcion);

                respuesta = SqlCmd.ExecuteNonQuery() == 1 ? "OK" : "No se ingreso el registro";
            }
            catch (Exception ex)
            {
                respuesta = ex.Message;
            }
            finally
            {
                if (SqlCon.State == ConnectionState.Open)
                {
                    SqlCon.Close();
                }
            }
            return respuesta;
        }


        //methods-edit
        public string Editar(mCategoria Categoria)
        {
            string respuesta = "";
            SqlConnection SqlCon = new SqlConnection();
            try
            {
                //codigo para editar
                SqlCon.ConnectionString = Conexion.Cn;
                SqlCon.Open();

                SqlCommand SqlCmd = new SqlCommand();
                SqlCmd.Connection = SqlCon;
                SqlCmd.CommandText = "speditar_categoria";
                SqlCmd.CommandType = CommandType.StoredProcedure;

                SqlParameter ParamIdCategoria = new SqlParameter();
                ParamIdCategoria.ParameterName = "@idcategoria";
                ParamIdCategoria.SqlDbType = SqlDbType.Int;
                ParamIdCategoria.Value = Categoria.IdCategoria;
                SqlCmd.Parameters.Add(ParamIdCategoria);

                SqlParameter ParamNombre = new SqlParameter();
                ParamNombre.ParameterName = "@nombre";
                ParamNombre.SqlDbType = SqlDbType.VarChar;
                ParamNombre.Size = 50;
                ParamNombre.Value = Categoria.Nombre;
                SqlCmd.Parameters.Add(ParamNombre);

                SqlParameter ParamDescripcion = new SqlParameter();
                ParamDescripcion.ParameterName = "@descripcion";
                ParamDescripcion.SqlDbType = SqlDbType.VarChar;
                ParamDescripcion.Size = 256;
                ParamDescripcion.Value = Categoria.Descripcion;
                SqlCmd.Parameters.Add(ParamDescripcion);

                respuesta = SqlCmd.ExecuteNonQuery() == 1 ? "OK" : "No se edito el registro";
            }
            catch (Exception ex)
            {
                respuesta = ex.Message;
            }
            finally
            {
                if (SqlCon.State == ConnectionState.Open)
                {
                    SqlCon.Close();
                }
            }
            return respuesta;
        }

        //methods-delete
        public string Eliminar(mCategoria Categoria)
        {
            string respuesta = "";
            SqlConnection SqlCon = new SqlConnection();
            try
            {
                //codigo para eliminar
                SqlCon.ConnectionString = Conexion.Cn;
                SqlCon.Open();

                SqlCommand SqlCmd = new SqlCommand();
                SqlCmd.Connection = SqlCon;
                SqlCmd.CommandText = "speliminar_categoria";
                SqlCmd.CommandType = CommandType.StoredProcedure;

                SqlParameter ParamIdCategoria = new SqlParameter();
                ParamIdCategoria.ParameterName = "@idcategoria";
                ParamIdCategoria.SqlDbType = SqlDbType.Int;
                ParamIdCategoria.Value = Categoria.IdCategoria;
                SqlCmd.Parameters.Add(ParamIdCategoria);

                respuesta = SqlCmd.ExecuteNonQuery() == 1 ? "OK" : "No se elimino el registro";
            }
            catch (Exception ex)
            {
                respuesta = ex.Message;
            }
            finally
            {
                if (SqlCon.State == ConnectionState.Open)
                {
                    SqlCon.Close();
                }
            }
            return respuesta;
        }

        //methods-show
        public DataTable Mostrar()
        {
            DataTable DtResultado = new DataTable("categoria");
            SqlConnection SqlCon = new SqlConnection();
            try
            {
                SqlCon.ConnectionString = Conexion.Cn;
                SqlCommand SqlCmd = new SqlCommand();
                SqlCmd.Connection = SqlCon;
                SqlCmd.CommandText = "spmostrar_categoria";
                SqlCmd.CommandType = CommandType.StoredProcedure;

                SqlDataAdapter SqlDat = new SqlDataAdapter(SqlCmd);
                SqlDat.Fill(DtResultado);
            }
            catch (Exception ex)
            {
                DtResultado = null;
            }

            return DtResultado;
        }

        //methods-search(nombre)
        public DataTable BuscarNombre(mCategoria Categoria)
        {
            DataTable DtResultado = new DataTable("categoria");
            SqlConnection SqlCon = new SqlConnection();
            try
            {
                SqlCon.ConnectionString = Conexion.Cn;
                SqlCommand SqlCmd = new SqlCommand();
                SqlCmd.Connection = SqlCon;
                SqlCmd.CommandText = "spbuscar_categoria";
                SqlCmd.CommandType = CommandType.StoredProcedure;

                SqlParameter ParamTextoBuscar = new SqlParameter();
                ParamTextoBuscar.ParameterName = "@textobuscar";
                ParamTextoBuscar.SqlDbType = SqlDbType.VarChar;
                ParamTextoBuscar.Size = 50;
                ParamTextoBuscar.Value = Categoria.TextoBuscar;
                SqlCmd.Parameters.Add(ParamTextoBuscar);

                SqlDataAdapter SqlDat = new SqlDataAdapter(SqlCmd);
                SqlDat.Fill(DtResultado);
            }
            catch (Exception ex)
            {
                DtResultado = null;
            }

            return DtResultado;
        }
    }
}
