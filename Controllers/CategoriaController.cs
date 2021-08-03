using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using Models;

namespace Controllers
{
    public class CategoriaController
    {
        public static string Insertar(string nombre, string descripcion)
        {
            mCategoria Obj = new mCategoria();
            Obj.Nombre = nombre;
            Obj.Descripcion = descripcion;

            return Obj.Insertar(Obj);
        }

        public static string Editar(int idcategoria, string nombre, string descripcion)
        {
            mCategoria Obj = new mCategoria();
            Obj.IdCategoria = idcategoria;
            Obj.Nombre = nombre;
            Obj.Descripcion = descripcion;

            return Obj.Editar(Obj);
        }

        public static string Eliminar(int idcategoria)
        {
            mCategoria Obj = new mCategoria();
            Obj.IdCategoria = idcategoria;

            return Obj.Eliminar(Obj);
        }

        public static DataTable Mostrar()
        {
            return new mCategoria().Mostrar();
        }

        public static DataTable BuscarNombre(string textoBuscar)
        {
            mCategoria Obj = new mCategoria();
            Obj.TextoBuscar = textoBuscar;

            return Obj.BuscarNombre(Obj);
        }
    }
}
