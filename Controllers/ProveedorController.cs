using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using Models;

namespace Controllers
{
    public class ProveedorController
    {
        public static string Insertar(string razonProveedor, string sectorComercial, string cuit, string direccion, string telefono, string email)
        {
            mProveedor Obj = new mProveedor();
            Obj.Razonsocial = razonProveedor;
            Obj.Sectorcomercial = sectorComercial;
            Obj.Cuitcuil = cuit;
            Obj.Direccion = direccion;
            Obj.Telefono = telefono;
            Obj.Email = email;

            return Obj.Insertar(Obj);
        }

        public static string Editar(int idproveedor, string razonProveedor, string sectorComercial, string cuit, string direccion, string telefono, string email)
        {
            mProveedor Obj = new mProveedor();
            Obj.IdProveedor = idproveedor;
            Obj.Razonsocial = razonProveedor;
            Obj.Sectorcomercial = sectorComercial;
            Obj.Cuitcuil = cuit;
            Obj.Direccion = direccion;
            Obj.Telefono = telefono;
            Obj.Email = email;

            return Obj.Editar(Obj);
        }

        public static string Eliminar(int idproveedor)
        {
            mProveedor Obj = new mProveedor();
            Obj.IdProveedor = idproveedor;

            return Obj.Eliminar(Obj);
        }

        public static DataTable Mostrar()
        {
            return new mProveedor().Mostrar();
        }

        public static DataTable BuscarRazonSocial(string textoBuscar)
        {
            mProveedor Obj = new mProveedor();
            Obj.TextoBuscar = textoBuscar;

            return Obj.BuscarRazonSocial(Obj);
        }

        public static DataTable BuscarCuit(string textoBuscar)
        {
            mProveedor Obj = new mProveedor();
            Obj.TextoBuscar = textoBuscar;

            return Obj.BuscarCuit(Obj);
        }
    }
}
