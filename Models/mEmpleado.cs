using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;

namespace Models
{
    public class mEmpleado
    {
        private int _Idempleado;
        private string _Apeynom;
        private string _Dni;
        private DateTime _Fecha_Nac;
        private string _Direccion;
        private string _Telefono;
        private string _Email;
        private string _Acceso;
        private string _Usuario;
        private string _Password;
        private string _Textobuscar;

        public int Idempleado { get => _Idempleado; set => _Idempleado = value; }
        public string Apeynom { get => _Apeynom; set => _Apeynom = value; }
        public string Dni { get => _Dni; set => _Dni = value; }
        public DateTime Fecha_Nac { get => _Fecha_Nac; set => _Fecha_Nac = value; }
        public string Direccion { get => _Direccion; set => _Direccion = value; }
        public string Telefono { get => _Telefono; set => _Telefono = value; }
        public string Email { get => _Email; set => _Email = value; }
        public string Usuario { get => _Usuario; set => _Usuario = value; }
        public string Password { get => _Password; set => _Password = value; }
        public string Textobuscar { get => _Textobuscar; set => _Textobuscar = value; }
        public string Acceso { get => _Acceso; set => _Acceso = value; }

        public mEmpleado()
        {

        }

        public mEmpleado(int idempleado, string apeynom, string dni, DateTime fecha_nac, string direccion,
            string telefono, string email, string acceso, string usuario, string password, string textobuscar)
        {
            this.Idempleado = idempleado;
            this.Apeynom = apeynom;
            this.Dni = dni;
            this.Fecha_Nac = fecha_nac;
            this.Direccion = direccion;
            this.Telefono = telefono;
            this.Email = email;
            this.Acceso = acceso;
            this.Usuario = usuario;
            this.Password = password;
            this.Textobuscar = textobuscar;
        }


        //Metodos
        //methods-insert
        public string Insertar(mEmpleado Empleado)
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
                SqlCmd.CommandText = "spinsertar_empleado";
                SqlCmd.CommandType = CommandType.StoredProcedure;

                SqlParameter ParamIdEmpleado = new SqlParameter();
                ParamIdEmpleado.ParameterName = "@idempleado";
                ParamIdEmpleado.SqlDbType = SqlDbType.Int;
                ParamIdEmpleado.Direction = ParameterDirection.Output;
                SqlCmd.Parameters.Add(ParamIdEmpleado);

                SqlParameter ParamApeynom = new SqlParameter();
                ParamApeynom.ParameterName = "@apeynom";
                ParamApeynom.SqlDbType = SqlDbType.VarChar;
                ParamApeynom.Size = 50;
                ParamApeynom.Value = Empleado.Apeynom;
                SqlCmd.Parameters.Add(ParamApeynom);

                SqlParameter ParamDni = new SqlParameter();
                ParamDni.ParameterName = "@dni";
                ParamDni.SqlDbType = SqlDbType.VarChar;
                ParamDni.Size = 20;
                ParamDni.Value = Empleado.Dni;
                SqlCmd.Parameters.Add(ParamDni);

                SqlParameter ParamFecha_Nac = new SqlParameter();
                ParamFecha_Nac.ParameterName = "@fecha_nac";
                ParamFecha_Nac.SqlDbType = SqlDbType.Date;
                ParamFecha_Nac.Value = Empleado.Fecha_Nac;
                SqlCmd.Parameters.Add(ParamFecha_Nac);

                SqlParameter ParamDireccion = new SqlParameter();
                ParamDireccion.ParameterName = "@direccion";
                ParamDireccion.SqlDbType = SqlDbType.VarChar;
                ParamDireccion.Size = 50;
                ParamDireccion.Value = Empleado.Direccion;
                SqlCmd.Parameters.Add(ParamDireccion);

                SqlParameter ParamTelefono = new SqlParameter();
                ParamTelefono.ParameterName = "@telefono";
                ParamTelefono.SqlDbType = SqlDbType.VarChar;
                ParamTelefono.Size = 20;
                ParamTelefono.Value = Empleado.Telefono;
                SqlCmd.Parameters.Add(ParamTelefono);

                SqlParameter ParamEmail = new SqlParameter();
                ParamEmail.ParameterName = "@email";
                ParamEmail.SqlDbType = SqlDbType.VarChar;
                ParamEmail.Size = 50;
                ParamEmail.Value = Empleado.Email;
                SqlCmd.Parameters.Add(ParamEmail);

                SqlParameter ParamAcceso = new SqlParameter();
                ParamAcceso.ParameterName = "@acceso";
                ParamAcceso.SqlDbType = SqlDbType.VarChar;
                ParamAcceso.Size = 20;
                ParamAcceso.Value = Empleado.Acceso;
                SqlCmd.Parameters.Add(ParamAcceso);

                SqlParameter ParamUsuario = new SqlParameter();
                ParamUsuario.ParameterName = "@usuario";
                ParamUsuario.SqlDbType = SqlDbType.VarChar;
                ParamUsuario.Size = 20;
                ParamUsuario.Value = Empleado.Usuario;
                SqlCmd.Parameters.Add(ParamUsuario);

                SqlParameter ParamPassword = new SqlParameter();
                ParamPassword.ParameterName = "@password";
                ParamPassword.SqlDbType = SqlDbType.VarChar;
                ParamPassword.Size = 20;
                ParamPassword.Value = Empleado.Password;
                SqlCmd.Parameters.Add(ParamPassword);

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
        public string Editar(mEmpleado Empleado)
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
                SqlCmd.CommandText = "speditar_empleado";
                SqlCmd.CommandType = CommandType.StoredProcedure;

                SqlParameter ParamIdEmpleado = new SqlParameter();
                ParamIdEmpleado.ParameterName = "@idempleado";
                ParamIdEmpleado.SqlDbType = SqlDbType.Int;
                ParamIdEmpleado.Value = Empleado.Idempleado;
                SqlCmd.Parameters.Add(ParamIdEmpleado);

                SqlParameter ParamApeynom = new SqlParameter();
                ParamApeynom.ParameterName = "@apeynom";
                ParamApeynom.SqlDbType = SqlDbType.VarChar;
                ParamApeynom.Size = 50;
                ParamApeynom.Value = Empleado.Apeynom;
                SqlCmd.Parameters.Add(ParamApeynom);

                SqlParameter ParamDni = new SqlParameter();
                ParamDni.ParameterName = "@dni";
                ParamDni.SqlDbType = SqlDbType.VarChar;
                ParamDni.Size = 20;
                ParamDni.Value = Empleado.Dni;
                SqlCmd.Parameters.Add(ParamDni);

                SqlParameter ParamFecha_Nac = new SqlParameter();
                ParamFecha_Nac.ParameterName = "@fecha_nac";
                ParamFecha_Nac.SqlDbType = SqlDbType.Date;
                ParamFecha_Nac.Value = Empleado.Fecha_Nac;
                SqlCmd.Parameters.Add(ParamFecha_Nac);

                SqlParameter ParamDireccion = new SqlParameter();
                ParamDireccion.ParameterName = "@direccion";
                ParamDireccion.SqlDbType = SqlDbType.VarChar;
                ParamDireccion.Size = 50;
                ParamDireccion.Value = Empleado.Direccion;
                SqlCmd.Parameters.Add(ParamDireccion);

                SqlParameter ParamTelefono = new SqlParameter();
                ParamTelefono.ParameterName = "@telefono";
                ParamTelefono.SqlDbType = SqlDbType.VarChar;
                ParamTelefono.Size = 20;
                ParamTelefono.Value = Empleado.Telefono;
                SqlCmd.Parameters.Add(ParamTelefono);

                SqlParameter ParamEmail = new SqlParameter();
                ParamEmail.ParameterName = "@email";
                ParamEmail.SqlDbType = SqlDbType.VarChar;
                ParamEmail.Size = 50;
                ParamEmail.Value = Empleado.Email;
                SqlCmd.Parameters.Add(ParamEmail);

                SqlParameter ParamAcceso = new SqlParameter();
                ParamAcceso.ParameterName = "@acceso";
                ParamAcceso.SqlDbType = SqlDbType.VarChar;
                ParamAcceso.Size = 20;
                ParamAcceso.Value = Empleado.Acceso;
                SqlCmd.Parameters.Add(ParamAcceso);

                SqlParameter ParamUsuario = new SqlParameter();
                ParamUsuario.ParameterName = "@usuario";
                ParamUsuario.SqlDbType = SqlDbType.VarChar;
                ParamUsuario.Size = 20;
                ParamUsuario.Value = Empleado.Usuario;
                SqlCmd.Parameters.Add(ParamUsuario);

                SqlParameter ParamPassword = new SqlParameter();
                ParamPassword.ParameterName = "@password";
                ParamPassword.SqlDbType = SqlDbType.VarChar;
                ParamPassword.Size = 20;
                ParamPassword.Value = Empleado.Password;
                SqlCmd.Parameters.Add(ParamPassword);


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
        public string Eliminar(mEmpleado Empleado)
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
                SqlCmd.CommandText = "speliminar_empleado";
                SqlCmd.CommandType = CommandType.StoredProcedure;

                SqlParameter ParamIdempleado = new SqlParameter();
                ParamIdempleado.ParameterName = "@idempleado";
                ParamIdempleado.SqlDbType = SqlDbType.Int;
                ParamIdempleado.Value = Empleado.Idempleado;
                SqlCmd.Parameters.Add(ParamIdempleado);

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
            DataTable DtResultado = new DataTable("empleado");
            SqlConnection SqlCon = new SqlConnection();
            try
            {
                SqlCon.ConnectionString = Conexion.Cn;
                SqlCommand SqlCmd = new SqlCommand();
                SqlCmd.Connection = SqlCon;
                SqlCmd.CommandText = "spmostrar_empleado";
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
        public DataTable BuscarApeynom(mEmpleado Empleado)
        {
            DataTable DtResultado = new DataTable("empleado");
            SqlConnection SqlCon = new SqlConnection();
            try
            {
                SqlCon.ConnectionString = Conexion.Cn;
                SqlCommand SqlCmd = new SqlCommand();
                SqlCmd.Connection = SqlCon;
                SqlCmd.CommandText = "spbuscar_apeynom_empleado";
                SqlCmd.CommandType = CommandType.StoredProcedure;

                SqlParameter ParamTextoBuscar = new SqlParameter();
                ParamTextoBuscar.ParameterName = "@textobuscar";
                ParamTextoBuscar.SqlDbType = SqlDbType.VarChar;
                ParamTextoBuscar.Size = 50;
                ParamTextoBuscar.Value = Empleado.Textobuscar;
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

        public DataTable BuscarDni(mEmpleado Empleado)
        {
            DataTable DtResultado = new DataTable("empleado");
            SqlConnection SqlCon = new SqlConnection();
            try
            {
                SqlCon.ConnectionString = Conexion.Cn;
                SqlCommand SqlCmd = new SqlCommand();
                SqlCmd.Connection = SqlCon;
                SqlCmd.CommandText = "spbuscar_dni_empleado";
                SqlCmd.CommandType = CommandType.StoredProcedure;

                SqlParameter ParamTextoBuscar = new SqlParameter();
                ParamTextoBuscar.ParameterName = "@textobuscar";
                ParamTextoBuscar.SqlDbType = SqlDbType.VarChar;
                ParamTextoBuscar.Size = 50;
                ParamTextoBuscar.Value = Empleado.Textobuscar;
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


        public DataTable Login(mEmpleado Empleado)
        {
            DataTable DtResultado = new DataTable("empleado");
            SqlConnection SqlCon = new SqlConnection();
            try
            {
                SqlCon.ConnectionString = Conexion.Cn;
                SqlCommand SqlCmd = new SqlCommand();
                SqlCmd.Connection = SqlCon;
                SqlCmd.CommandText = "splogin";
                SqlCmd.CommandType = CommandType.StoredProcedure;

                SqlParameter ParamUsuario = new SqlParameter();
                ParamUsuario.ParameterName = "@usuario";
                ParamUsuario.SqlDbType = SqlDbType.VarChar;
                ParamUsuario.Size = 20;
                ParamUsuario.Value = Empleado.Usuario;
                SqlCmd.Parameters.Add(ParamUsuario);

                SqlParameter ParamPassword = new SqlParameter();
                ParamPassword.ParameterName = "@password";
                ParamPassword.SqlDbType = SqlDbType.VarChar;
                ParamPassword.Size = 20;
                ParamPassword.Value = Empleado.Password;
                SqlCmd.Parameters.Add(ParamPassword);

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
