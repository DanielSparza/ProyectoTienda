using System;
using System.Windows.Forms;
using ManejadorTienda;
using EntidadesTienda;

namespace PresentacionTienda
{
    public partial class FrmProductosAdd : Form
    {
        ManejadorProductos mp = new ManejadorProductos();

        EntidadProducto producto;
        string id2 = null;

        public FrmProductosAdd()
        {

        }

        public FrmProductosAdd(EntidadProducto producto)
        {
            InitializeComponent();
            id2 = producto.IdProducto.ToString();

            txtNombre.Text = producto.Nombre.ToString();
            txtDescripcion.Text = producto.Descripcion.ToString();
            txtPrecio.Text = producto.Precio.ToString();
        }

        private void FrmProductosAdd_Load(object sender, EventArgs e)
        {

        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            try
            {
                if (id2 != null)
                {
                    producto = new EntidadProducto(int.Parse(id2), txtNombre.Text, txtDescripcion.Text,
                        double.Parse(txtPrecio.Text));
                    string rn = mp.Modificar(producto, id2);
                    Close();
                }
                else
                {
                    string rc = mp.Guardar(producto = new EntidadProducto(0, txtNombre.Text, txtDescripcion.Text,
                        double.Parse(txtPrecio.Text)));

                    MessageBox.Show("Dato guardado correctamente");
                    Close();
                }
            }
            catch (System.FormatException)
            {
                MessageBox.Show("Los campos requeridos no tienen el formato correcto.");
            }
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
