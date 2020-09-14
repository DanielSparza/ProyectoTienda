namespace EntidadesTienda
{
    public class EntidadProducto
    {
        public int IdProducto { get; set; }
        public string Nombre { get; set; }
        public string Descripcion { get; set; }
        public double Precio { get; set; }

        public EntidadProducto(int idproducto, string nombre, string descripcion, double precio)
        {
            IdProducto = idproducto;
            Nombre = nombre;
            Descripcion = descripcion;
            Precio = precio;
        }
    }
}
