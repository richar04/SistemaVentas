using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;

namespace Models
{
    public class mArticulo
    {
        private int _Idarticulo;
        private string _Codigo;
        private string _Nombre;
        private string _Descripcion;
        private byte[] _Imagen;
        private int _Idcategoria;
        private string _TextoBuscar;

        public int Idarticulo { get => _Idarticulo; set => _Idarticulo = value; }
        public string Codigo { get => _Codigo; set => _Codigo = value; }
        public string Nombre { get => _Nombre; set => _Nombre = value; }
        public string Descripcion { get => _Descripcion; set => _Descripcion = value; }
        public byte[] Imagen { get => _Imagen; set => _Imagen = value; }
        public int Idcategoria { get => _Idcategoria; set => _Idcategoria = value; }
        public string TextoBuscar { get => _TextoBuscar; set => _TextoBuscar = value; }

        //Constructores
        public mArticulo()
        {

        }

        public mArticulo(int idarticulo, string codigo, string nombre, string descripcion, byte[] imagen, int idcategoria, string textobuscar)
        {
            this.Idarticulo = idarticulo;
            this.Codigo = codigo;
            this.Nombre = nombre;
            this.Descripcion = descripcion;
            this.Imagen = imagen;
            this.Idcategoria = idcategoria;
            this.TextoBuscar = textobuscar;
        }

        //Metodos
        //methods-insert
        public string Insertar(mArticulo Articulo)
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
                SqlCmd.CommandText = "spinsertar_articulo";
                SqlCmd.CommandType = CommandType.StoredProcedure;

                SqlParameter ParamIdArticulo = new SqlParameter();
                ParamIdArticulo.ParameterName = "@idarticulo";
                ParamIdArticulo.SqlDbType = SqlDbType.Int;
                ParamIdArticulo.Direction = ParameterDirection.Output;
                SqlCmd.Parameters.Add(ParamIdArticulo);

                SqlParameter ParamCodigo = new SqlParameter();
                ParamCodigo.ParameterName = "@codigo";
                ParamCodigo.SqlDbType = SqlDbType.VarChar;
                ParamCodigo.Size = 50;
                ParamCodigo.Value = Articulo.Codigo;
                SqlCmd.Parameters.Add(ParamCodigo);

                SqlParameter ParamNombre = new SqlParameter();
                ParamNombre.ParameterName = "@nombre";
                ParamNombre.SqlDbType = SqlDbType.VarChar;
                ParamNombre.Size = 50;
                ParamNombre.Value = Articulo.Nombre;
                SqlCmd.Parameters.Add(ParamNombre);

                SqlParameter ParamDescripcion = new SqlParameter();
                ParamDescripcion.ParameterName = "@descripcion";
                ParamDescripcion.SqlDbType = SqlDbType.VarChar;
                ParamDescripcion.Size = 100;
                ParamDescripcion.Value = Articulo.Descripcion;
                SqlCmd.Parameters.Add(ParamDescripcion);

                SqlParameter ParamImagen = new SqlParameter();
                ParamImagen.ParameterName = "@imagen";
                ParamImagen.SqlDbType = SqlDbType.Image;
                ParamImagen.Value = Articulo.Imagen;
                SqlCmd.Parameters.Add(ParamImagen);

                SqlParameter ParamIdCategoria = new SqlParameter();
                ParamIdCategoria.ParameterName = "@idcategoria";
                ParamIdCategoria.SqlDbType = SqlDbType.Int;
                ParamIdCategoria.Value = Articulo.Idcategoria;
                SqlCmd.Parameters.Add(ParamIdCategoria);

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
        public string Editar(mArticulo Articulo)
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
                SqlCmd.CommandText = "speditar_articulo";
                SqlCmd.CommandType = CommandType.StoredProcedure;

                SqlParameter ParamIdArticulo = new SqlParameter();
                ParamIdArticulo.ParameterName = "@idarticulo";
                ParamIdArticulo.SqlDbType = SqlDbType.Int;
                ParamIdArticulo.Value = Articulo.Idcategoria;
                SqlCmd.Parameters.Add(ParamIdArticulo);

                SqlParameter ParamCodigo = new SqlParameter();
                ParamCodigo.ParameterName = "@codigo";
                ParamCodigo.SqlDbType = SqlDbType.VarChar;
                ParamCodigo.Size = 50;
                ParamCodigo.Value = Articulo.Codigo;
                SqlCmd.Parameters.Add(ParamCodigo);

                SqlParameter ParamNombre = new SqlParameter();
                ParamNombre.ParameterName = "@nombre";
                ParamNombre.SqlDbType = SqlDbType.VarChar;
                ParamNombre.Size = 50;
                ParamNombre.Value = Articulo.Nombre;
                SqlCmd.Parameters.Add(ParamNombre);

                SqlParameter ParamDescripcion = new SqlParameter();
                ParamDescripcion.ParameterName = "@descripcion";
                ParamDescripcion.SqlDbType = SqlDbType.VarChar;
                ParamDescripcion.Size = 100;
                ParamDescripcion.Value = Articulo.Descripcion;
                SqlCmd.Parameters.Add(ParamDescripcion);

                SqlParameter ParamImagen = new SqlParameter();
                ParamImagen.ParameterName = "@imagen";
                ParamImagen.SqlDbType = SqlDbType.Image;
                ParamImagen.Value = Articulo.Imagen;
                SqlCmd.Parameters.Add(ParamImagen);

                SqlParameter ParamIdCategoria = new SqlParameter();
                ParamIdCategoria.ParameterName = "@idcategoria";
                ParamIdCategoria.SqlDbType = SqlDbType.Int;
                ParamIdCategoria.Value = Articulo.Idcategoria;
                SqlCmd.Parameters.Add(ParamIdCategoria);


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
        public string Eliminar(mArticulo Articulo)
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
                SqlCmd.CommandText = "speliminar_articulo";
                SqlCmd.CommandType = CommandType.StoredProcedure;

                SqlParameter ParamIdarticulo = new SqlParameter();
                ParamIdarticulo.ParameterName = "@idarticulo";
                ParamIdarticulo.SqlDbType = SqlDbType.Int;
                ParamIdarticulo.Value = Articulo.Idarticulo;
                SqlCmd.Parameters.Add(ParamIdarticulo);

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
            DataTable DtResultado = new DataTable("articulo");
            SqlConnection SqlCon = new SqlConnection();
            try
            {
                SqlCon.ConnectionString = Conexion.Cn;
                SqlCommand SqlCmd = new SqlCommand();
                SqlCmd.Connection = SqlCon;
                SqlCmd.CommandText = "spmostrar_articulo";
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
        public DataTable BuscarNombre(mArticulo Articulo)
        {
            DataTable DtResultado = new DataTable("articulo");
            SqlConnection SqlCon = new SqlConnection();
            try
            {
                SqlCon.ConnectionString = Conexion.Cn;
                SqlCommand SqlCmd = new SqlCommand();
                SqlCmd.Connection = SqlCon;
                SqlCmd.CommandText = "spbuscar_articulo";
                SqlCmd.CommandType = CommandType.StoredProcedure;

                SqlParameter ParamTextoBuscar = new SqlParameter();
                ParamTextoBuscar.ParameterName = "@textobuscar";
                ParamTextoBuscar.SqlDbType = SqlDbType.VarChar;
                ParamTextoBuscar.Size = 50;
                ParamTextoBuscar.Value = Articulo.TextoBuscar;
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
