using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using Models;

namespace Controllers
{
    public class ClienteController
    {
        public static string Insertar(string apeynom, string dni, string direccion, string telefono, string email)
        {
            mCliente Obj = new mCliente();
            Obj.Apeynom = apeynom;
            Obj.Dni = dni;
            Obj.Direccion = direccion;
            Obj.Telefono = telefono;
            Obj.Email = email;

            return Obj.Insertar(Obj);
        }

        public static string Editar(int idcliente, string apeynom, string dni, string direccion, string telefono, string email)
        {
            mCliente Obj = new mCliente();
            Obj.Apeynom = apeynom;
            Obj.Dni = dni;
            Obj.Direccion = direccion;
            Obj.Telefono = telefono;
            Obj.Email = email;

            return Obj.Insertar(Obj);
        }

        public static string Eliminar(int idcliente)
        {
            mCliente Obj = new mCliente();
            Obj.Idcliente = idcliente;

            return Obj.Eliminar(Obj);
        }

        public static DataTable Mostrar()
        {
            return new mCliente().Mostrar();
        }

        public static DataTable BuscarApeynom(string textoBuscar)
        {
            mCliente Obj = new mCliente();
            Obj.TextoBuscar = textoBuscar;

            return Obj.BuscarApeynom(Obj);
        }
        public static DataTable BuscarDni(string textoBuscar)
        {
            mCliente Obj = new mCliente();
            Obj.TextoBuscar = textoBuscar;

            return Obj.BuscarDni(Obj);
        }
    }
}
