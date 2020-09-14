using EntidadesTienda;
using AccesoDatosTienda;
using System.Data;

namespace ManejadorTienda
{
    public class ManejadorProductos
    {
        ConexionTienda ct = new ConexionTienda();

        //Guardar producto
        public string Guardar(EntidadProducto producto)
        {
            return ct.Comando(string.Format("insert into producto values" +
                "(null, '{0}', '{1}', {2})", producto.Nombre, producto.Descripcion, producto.Precio));
        }

        //Borrar producto
        public string Borrar(EntidadProducto producto)
        {
            return ct.Comando(string.Format("delete from producto where Id_Producto={0}", producto.IdProducto));
        }

        //Modificar producto
        public string Modificar(EntidadProducto producto, string id2)
        {
            return ct.Comando(string.Format("update producto set Nombre='{0}'," +
                " Descripcion='{1}', Precio={2} where Id_Producto={3}",
                producto.Nombre, producto.Descripcion, producto.Precio, id2));
        }

        //Mostrar Informacion
        public DataSet Listado(string q, string tabla)
        {
            return ct.Mostrar(q, tabla);
        }
    }
}
