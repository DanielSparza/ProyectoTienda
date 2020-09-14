using Bases;
using System.Data;

namespace AccesoDatosTienda
{
    public class ConexionTienda
    {
        Conectar c = new Conectar("localhost", "root", "1234567890", "Tienda");

        //Metodo para insertar, eliminar, modificar
        public string Comando(string q)
        {
            return c.Comando(q);
        }

        //Metodo para consultar
        public DataSet Mostrar(string q, string tabla)
        {
            return c.Consultar(q, tabla);
        }
    }
}
