using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;

namespace Models
{
    public class mCliente
    {
        private int _Idcliente;
        private string _Apeynom;
        private string _Dni;
        private string _Direccion;
        private string _Telefono;
        private string _Email;
        private string _TextoBuscar;

        public int Idcliente { get => _Idcliente; set => _Idcliente = value; }
        public string Apeynom { get => _Apeynom; set => _Apeynom = value; }
        public string Dni { get => _Dni; set => _Dni = value; }
        public string Direccion { get => _Direccion; set => _Direccion = value; }
        public string Telefono { get => _Telefono; set => _Telefono = value; }
        public string Email { get => _Email; set => _Email = value; }
        public string TextoBuscar { get => _TextoBuscar; set => _TextoBuscar = value; }

        public mCliente()
        {

        }

        public mCliente (int idcliente, string apeynom, string dni, string direccion,
            string telefono, string email, string textobuscar)
        {
            this.Idcliente = idcliente;
            this.Apeynom = apeynom;
            this.Dni = dni;
            this.Direccion = direccion;
            this.Telefono = telefono;
            this.Email = email;
            this.TextoBuscar = textobuscar;
        }

        //Metodos
        //methods-insert
        public string Insertar(mCliente Cliente)
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
                SqlCmd.CommandText = "spinsertar_cliente";
                SqlCmd.CommandType = CommandType.StoredProcedure;

                SqlParameter ParamIdCliente = new SqlParameter();
                ParamIdCliente.ParameterName = "@idcliente";
                ParamIdCliente.SqlDbType = SqlDbType.Int;
                ParamIdCliente.Direction = ParameterDirection.Output;
                SqlCmd.Parameters.Add(ParamIdCliente);

                SqlParameter ParamApeynom = new SqlParameter();
                ParamApeynom.ParameterName = "@apeynom";
                ParamApeynom.SqlDbType = SqlDbType.VarChar;
                ParamApeynom.Size = 100;
                ParamApeynom.Value = Cliente.Apeynom;
                SqlCmd.Parameters.Add(ParamApeynom);

                SqlParameter ParamDni = new SqlParameter();
                ParamDni.ParameterName = "@dni";
                ParamDni.SqlDbType = SqlDbType.VarChar;
                ParamDni.Size = 20;
                ParamDni.Value = Cliente.Dni;
                SqlCmd.Parameters.Add(ParamDni);

                SqlParameter ParamDireccion = new SqlParameter();
                ParamDireccion.ParameterName = "@direccion";
                ParamDireccion.SqlDbType = SqlDbType.VarChar;
                ParamDireccion.Size = 50;
                ParamDireccion.Value = Cliente.Direccion;
                SqlCmd.Parameters.Add(ParamDireccion);

                SqlParameter ParamTelefono = new SqlParameter();
                ParamTelefono.ParameterName = "@telefono";
                ParamTelefono.SqlDbType = SqlDbType.VarChar;
                ParamTelefono.Size = 20;
                ParamTelefono.Value = Cliente.Telefono;
                SqlCmd.Parameters.Add(ParamTelefono);

                SqlParameter ParamEmail = new SqlParameter();
                ParamEmail.ParameterName = "@email";
                ParamEmail.SqlDbType = SqlDbType.VarChar;
                ParamEmail.Size = 50;
                ParamEmail.Value = Cliente.Email;
                SqlCmd.Parameters.Add(ParamEmail);

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
        public string Editar(mCliente Cliente)
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
                SqlCmd.CommandText = "speditar_cliente";
                SqlCmd.CommandType = CommandType.StoredProcedure;

                SqlParameter ParamIdCliente = new SqlParameter();
                ParamIdCliente.ParameterName = "@idcliente";
                ParamIdCliente.SqlDbType = SqlDbType.Int;
                SqlCmd.Parameters.Add(ParamIdCliente);

                SqlParameter ParamApeynom = new SqlParameter();
                ParamApeynom.ParameterName = "@apeynom";
                ParamApeynom.SqlDbType = SqlDbType.VarChar;
                ParamApeynom.Size = 100;
                ParamApeynom.Value = Cliente.Apeynom;
                SqlCmd.Parameters.Add(ParamApeynom);

                SqlParameter ParamDni = new SqlParameter();
                ParamDni.ParameterName = "@dni";
                ParamDni.SqlDbType = SqlDbType.VarChar;
                ParamDni.Size = 20;
                ParamDni.Value = Cliente.Dni;
                SqlCmd.Parameters.Add(ParamDni);

                SqlParameter ParamDireccion = new SqlParameter();
                ParamDireccion.ParameterName = "@direccion";
                ParamDireccion.SqlDbType = SqlDbType.VarChar;
                ParamDireccion.Size = 50;
                ParamDireccion.Value = Cliente.Direccion;
                SqlCmd.Parameters.Add(ParamDireccion);

                SqlParameter ParamTelefono = new SqlParameter();
                ParamTelefono.ParameterName = "@telefono";
                ParamTelefono.SqlDbType = SqlDbType.VarChar;
                ParamTelefono.Size = 20;
                ParamTelefono.Value = Cliente.Telefono;
                SqlCmd.Parameters.Add(ParamTelefono);

                SqlParameter ParamEmail = new SqlParameter();
                ParamEmail.ParameterName = "@email";
                ParamEmail.SqlDbType = SqlDbType.VarChar;
                ParamEmail.Size = 50;
                ParamEmail.Value = Cliente.Email;
                SqlCmd.Parameters.Add(ParamEmail);


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
        public string Eliminar(mCliente Cliente)
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
                SqlCmd.CommandText = "speliminar_cliente";
                SqlCmd.CommandType = CommandType.StoredProcedure;

                SqlParameter ParamIdcliente = new SqlParameter();
                ParamIdcliente.ParameterName = "@idcliente";
                ParamIdcliente.SqlDbType = SqlDbType.Int;
                ParamIdcliente.Value = Cliente.Idcliente;
                SqlCmd.Parameters.Add(ParamIdcliente);

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
            DataTable DtResultado = new DataTable("cliente");
            SqlConnection SqlCon = new SqlConnection();
            try
            {
                SqlCon.ConnectionString = Conexion.Cn;
                SqlCommand SqlCmd = new SqlCommand();
                SqlCmd.Connection = SqlCon;
                SqlCmd.CommandText = "spmostrar_cliente";
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
        public DataTable BuscarApeynom(mCliente Cliente)
        {
            DataTable DtResultado = new DataTable("cliente");
            SqlConnection SqlCon = new SqlConnection();
            try
            {
                SqlCon.ConnectionString = Conexion.Cn;
                SqlCommand SqlCmd = new SqlCommand();
                SqlCmd.Connection = SqlCon;
                SqlCmd.CommandText = "spbuscar_apeynom_cliente";
                SqlCmd.CommandType = CommandType.StoredProcedure;

                SqlParameter ParamTextoBuscar = new SqlParameter();
                ParamTextoBuscar.ParameterName = "@textobuscar";
                ParamTextoBuscar.SqlDbType = SqlDbType.VarChar;
                ParamTextoBuscar.Size = 50;
                ParamTextoBuscar.Value = Cliente.TextoBuscar;
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

        public DataTable BuscarDni(mCliente Cliente)
        {
            DataTable DtResultado = new DataTable("cliente");
            SqlConnection SqlCon = new SqlConnection();
            try
            {
                SqlCon.ConnectionString = Conexion.Cn;
                SqlCommand SqlCmd = new SqlCommand();
                SqlCmd.Connection = SqlCon;
                SqlCmd.CommandText = "spbuscar_dni_cliente";
                SqlCmd.CommandType = CommandType.StoredProcedure;

                SqlParameter ParamTextoBuscar = new SqlParameter();
                ParamTextoBuscar.ParameterName = "@textobuscar";
                ParamTextoBuscar.SqlDbType = SqlDbType.VarChar;
                ParamTextoBuscar.Size = 50;
                ParamTextoBuscar.Value = Cliente.TextoBuscar;
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
