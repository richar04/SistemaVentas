using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Models;
using System.Data;


namespace Controllers
{
    public class ArticuloController
    {
        public static string Insertar(string codigo, string nombre, string descripcion, byte[] imagen, int idcategoria)
        {
            mArticulo Obj = new mArticulo();
            Obj.Codigo = codigo;
            Obj.Nombre = nombre;
            Obj.Descripcion = descripcion;
            Obj.Imagen = imagen;
            Obj.Idcategoria = idcategoria;

            return Obj.Insertar(Obj);
        }

        public static string Editar(int idarticulo, string codigo, string nombre, string descripcion, byte[] imagen, int idcategoria)
        {
            mArticulo Obj = new mArticulo();
            Obj.Idarticulo = idarticulo;
            Obj.Codigo = codigo;
            Obj.Nombre = nombre;
            Obj.Descripcion = descripcion;
            Obj.Imagen = imagen;
            Obj.Idcategoria = idcategoria;

            return Obj.Editar(Obj);
        }

        public static string Eliminar(int idarticulo)
        {
            mArticulo Obj = new mArticulo();
            Obj.Idarticulo = idarticulo;

            return Obj.Eliminar(Obj);
        }

        public static DataTable Mostrar()
        {
            return new mArticulo().Mostrar();
        }

        public static DataTable BuscarNombre(string textoBuscar)
        {
            mArticulo Obj = new mArticulo();
            Obj.TextoBuscar = textoBuscar;

            return Obj.BuscarNombre(Obj);
        }
    }
}
