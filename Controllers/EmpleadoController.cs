using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using Models;

namespace Controllers
{
    public class EmpleadoController
    {
        public static string Insertar(string apeynom, string dni, DateTime fecha_nac, string direccion, 
            string telefono, string email, string acceso, string usuario, string password)
        {
            mEmpleado Obj = new mEmpleado();
            Obj.Apeynom = apeynom;
            Obj.Dni = dni;
            Obj.Fecha_Nac = fecha_nac;
            Obj.Direccion = direccion;
            Obj.Telefono = telefono;
            Obj.Email = email;
            Obj.Acceso = acceso;
            Obj.Usuario = usuario;
            Obj.Password = password;


            return Obj.Insertar(Obj);
        }

        public static string Editar(int idempleado, string apeynom, string dni, DateTime fecha_nac, string direccion,
            string telefono, string email, string acceso, string usuario, string password)
        {
            mEmpleado Obj = new mEmpleado();
            Obj.Idempleado = idempleado;
            Obj.Apeynom = apeynom;
            Obj.Dni = dni;
            Obj.Fecha_Nac = fecha_nac;
            Obj.Direccion = direccion;
            Obj.Telefono = telefono;
            Obj.Email = email;
            Obj.Acceso = acceso;
            Obj.Usuario = usuario;
            Obj.Password = password;

            return Obj.Editar(Obj);
        }

        public static string Eliminar(int idempleado)
        {
            mEmpleado Obj = new mEmpleado();
            Obj.Idempleado = idempleado;

            return Obj.Eliminar(Obj);
        }

        public static DataTable Mostrar()
        {
            return new mEmpleado().Mostrar();
        }

        public static DataTable BuscarApeynom(string textoBuscar)
        {
            mEmpleado Obj = new mEmpleado();
            Obj.Textobuscar = textoBuscar;

            return Obj.BuscarApeynom(Obj);
        }
        public static DataTable BuscarDni(string textoBuscar)
        {
            mEmpleado Obj = new mEmpleado();
            Obj.Textobuscar = textoBuscar;

            return Obj.BuscarDni(Obj);
        }

        public static DataTable Login(string usuario, string password)
        {
            mEmpleado Obj = new mEmpleado();
            Obj.Usuario = usuario;
            Obj.Password = password;

            return Obj.Login(Obj);
        }
    }
}
