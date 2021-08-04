using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;

namespace Models
{
    public class mProveedor
    {
        private int _IdProveedor;
        private string _Razonsocial;
        private string _Sectorcomercial;
        private string _Cuitcuil;
        private string _Direccion;
        private string _Telefono;
        private string _Email;
        private string _TextoBuscar;

        public int IdProveedor { get => _IdProveedor; set => _IdProveedor = value; }
        public string Razonsocial { get => _Razonsocial; set => _Razonsocial = value; }
        public string Sectorcomercial { get => _Sectorcomercial; set => _Sectorcomercial = value; }
        public string Cuitcuil { get => _Cuitcuil; set => _Cuitcuil = value; }
        public string Direccion { get => _Direccion; set => _Direccion = value; }
        public string Telefono { get => _Telefono; set => _Telefono = value; }
        public string Email { get => _Email; set => _Email = value; }
        public string TextoBuscar { get => _TextoBuscar; set => _TextoBuscar = value; }

        public mProveedor()
        {

        }

        public mProveedor(int idproveedor, string razonsocial, string sectorcomercial, string cuitcuil, string direccion,
            string telefono, string email, string textobuscar)
        {
            this.IdProveedor = idproveedor;
            this.Razonsocial = razonsocial;
            this.Sectorcomercial = sectorcomercial;
            this.Cuitcuil = cuitcuil;
            this.Direccion = direccion;
            this.Telefono = telefono;
            this.Email = email;
            this.TextoBuscar = textobuscar;
        }

        //Metodos
        //methods-insert
        public string Insertar(mProveedor Proveedor)
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
                SqlCmd.CommandText = "spinsertar_proveedor";
                SqlCmd.CommandType = CommandType.StoredProcedure;

                SqlParameter ParamIdProveedor = new SqlParameter();
                ParamIdProveedor.ParameterName = "@idproveedor";
                ParamIdProveedor.SqlDbType = SqlDbType.Int;
                ParamIdProveedor.Direction = ParameterDirection.Output;
                SqlCmd.Parameters.Add(ParamIdProveedor);

                SqlParameter ParamRazonSocial = new SqlParameter();
                ParamRazonSocial.ParameterName = "@razonsocial";
                ParamRazonSocial.SqlDbType = SqlDbType.VarChar;
                ParamRazonSocial.Size = 50;
                ParamRazonSocial.Value = Proveedor.Razonsocial;
                SqlCmd.Parameters.Add(ParamRazonSocial);

                SqlParameter ParamSectorComercial = new SqlParameter();
                ParamSectorComercial.ParameterName = "@sectorcomercial";
                ParamSectorComercial.SqlDbType = SqlDbType.VarChar;
                ParamSectorComercial.Size = 50;
                ParamSectorComercial.Value = Proveedor.Sectorcomercial;
                SqlCmd.Parameters.Add(ParamSectorComercial);

                SqlParameter ParamCuitCuil = new SqlParameter();
                ParamCuitCuil.ParameterName = "@cuitcuil";
                ParamCuitCuil.SqlDbType = SqlDbType.VarChar;
                ParamCuitCuil.Size = 20;
                ParamCuitCuil.Value = Proveedor.Cuitcuil;
                SqlCmd.Parameters.Add(ParamCuitCuil);

                SqlParameter ParamDireccion = new SqlParameter();
                ParamDireccion.ParameterName = "@direccion";
                ParamDireccion.SqlDbType = SqlDbType.VarChar;
                ParamDireccion.Size = 50;
                ParamDireccion.Value = Proveedor.Direccion;
                SqlCmd.Parameters.Add(ParamDireccion);

                SqlParameter ParamTelefono = new SqlParameter();
                ParamTelefono.ParameterName = "@telefono";
                ParamTelefono.SqlDbType = SqlDbType.VarChar;
                ParamTelefono.Size = 20;
                ParamTelefono.Value = Proveedor.Telefono;
                SqlCmd.Parameters.Add(ParamTelefono);

                SqlParameter ParamEmail = new SqlParameter();
                ParamEmail.ParameterName = "@email";
                ParamEmail.SqlDbType = SqlDbType.VarChar;
                ParamEmail.Size = 50;
                ParamEmail.Value = Proveedor.Email;
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
        public string Editar(mProveedor Proveedor)
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
                SqlCmd.CommandText = "speditar_proveedor";
                SqlCmd.CommandType = CommandType.StoredProcedure;

                SqlParameter ParamIdProveedor = new SqlParameter();
                ParamIdProveedor.ParameterName = "@idproveedor";
                ParamIdProveedor.SqlDbType = SqlDbType.Int;
                ParamIdProveedor.Direction = ParameterDirection.Output;
                SqlCmd.Parameters.Add(ParamIdProveedor);

                SqlParameter ParamRazonSocial = new SqlParameter();
                ParamRazonSocial.ParameterName = "@razonsocial";
                ParamRazonSocial.SqlDbType = SqlDbType.VarChar;
                ParamRazonSocial.Size = 50;
                ParamRazonSocial.Value = Proveedor.Razonsocial;
                SqlCmd.Parameters.Add(ParamRazonSocial);

                SqlParameter ParamSectorComercial = new SqlParameter();
                ParamSectorComercial.ParameterName = "@sectorcomercial";
                ParamSectorComercial.SqlDbType = SqlDbType.VarChar;
                ParamSectorComercial.Size = 50;
                ParamSectorComercial.Value = Proveedor.Sectorcomercial;
                SqlCmd.Parameters.Add(ParamSectorComercial);

                SqlParameter ParamCuitCuil = new SqlParameter();
                ParamCuitCuil.ParameterName = "@cuitcuil";
                ParamCuitCuil.SqlDbType = SqlDbType.VarChar;
                ParamCuitCuil.Size = 20;
                ParamCuitCuil.Value = Proveedor.Cuitcuil;
                SqlCmd.Parameters.Add(ParamCuitCuil);

                SqlParameter ParamDireccion = new SqlParameter();
                ParamDireccion.ParameterName = "@direccion";
                ParamDireccion.SqlDbType = SqlDbType.VarChar;
                ParamDireccion.Size = 50;
                ParamDireccion.Value = Proveedor.Direccion;
                SqlCmd.Parameters.Add(ParamDireccion);

                SqlParameter ParamTelefono = new SqlParameter();
                ParamTelefono.ParameterName = "@telefono";
                ParamTelefono.SqlDbType = SqlDbType.VarChar;
                ParamTelefono.Size = 20;
                ParamTelefono.Value = Proveedor.Telefono;
                SqlCmd.Parameters.Add(ParamTelefono);

                SqlParameter ParamEmail = new SqlParameter();
                ParamEmail.ParameterName = "@email";
                ParamEmail.SqlDbType = SqlDbType.VarChar;
                ParamEmail.Size = 50;
                ParamEmail.Value = Proveedor.Email;
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
        public string Eliminar(mProveedor Proveedor)
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
                SqlCmd.CommandText = "speliminar_proveedor";
                SqlCmd.CommandType = CommandType.StoredProcedure;

                SqlParameter ParamIdProveedor = new SqlParameter();
                ParamIdProveedor.ParameterName = "@idproveedor";
                ParamIdProveedor.SqlDbType = SqlDbType.Int;
                ParamIdProveedor.Value = Proveedor.IdProveedor;
                SqlCmd.Parameters.Add(ParamIdProveedor);

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
            DataTable DtResultado = new DataTable("proveedor");
            SqlConnection SqlCon = new SqlConnection();
            try
            {
                SqlCon.ConnectionString = Conexion.Cn;
                SqlCommand SqlCmd = new SqlCommand();
                SqlCmd.Connection = SqlCon;
                SqlCmd.CommandText = "spmostrar_proveedor";
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
        public DataTable BuscarRazonSocial(mProveedor Proveedor)
        {
            DataTable DtResultado = new DataTable("proveedor");
            SqlConnection SqlCon = new SqlConnection();
            try
            {
                SqlCon.ConnectionString = Conexion.Cn;
                SqlCommand SqlCmd = new SqlCommand();
                SqlCmd.Connection = SqlCon;
                SqlCmd.CommandText = "spbuscar_proveedor";
                SqlCmd.CommandType = CommandType.StoredProcedure;

                SqlParameter ParamTextoBuscar = new SqlParameter();
                ParamTextoBuscar.ParameterName = "@textobuscar";
                ParamTextoBuscar.SqlDbType = SqlDbType.VarChar;
                ParamTextoBuscar.Size = 50;
                ParamTextoBuscar.Value = Proveedor.TextoBuscar;
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

        public DataTable BuscarCuit(mProveedor Proveedor)
        {
            DataTable DtResultado = new DataTable("proveedor");
            SqlConnection SqlCon = new SqlConnection();
            try
            {
                SqlCon.ConnectionString = Conexion.Cn;
                SqlCommand SqlCmd = new SqlCommand();
                SqlCmd.Connection = SqlCon;
                SqlCmd.CommandText = "spbuscar_cuit_proveedor";
                SqlCmd.CommandType = CommandType.StoredProcedure;

                SqlParameter ParamTextoBuscar = new SqlParameter();
                ParamTextoBuscar.ParameterName = "@textobuscar";
                ParamTextoBuscar.SqlDbType = SqlDbType.VarChar;
                ParamTextoBuscar.Size = 20;
                ParamTextoBuscar.Value = Proveedor.TextoBuscar;
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
