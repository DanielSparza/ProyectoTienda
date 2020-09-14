using System;
using System.Windows.Forms;
using ManejadorTienda;
using EntidadesTienda;

namespace PresentacionTienda
{
    public partial class FrmProductosView : Form
    {
        ManejadorProductos mp;
        EntidadProducto producto = new EntidadProducto(0, "", "", 0.0);
        int fila = 0;
        string r = "";

        public FrmProductosView()
        {
            InitializeComponent();
            mp = new ManejadorProductos();
        }

        void Actualizar()
        {
            dgvProductos.DataSource = mp.Listado(string.Format(
                "select * from Producto where Nombre like '%{0}%'", txtBuscar.Text), "Producto").Tables[0];

            for (int i = 0; i < dgvProductos.Columns.Count; i++)
            {
                dgvProductos.Columns[i].ReadOnly = true;
            }
        }

        private void FrmProductosView_Load(object sender, EventArgs e)
        {
            Actualizar();
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            FrmProductosAdd pa = new FrmProductosAdd();
            pa.ShowDialog();
            Actualizar();
        }

        private void dgvProductos_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                fila = e.RowIndex;
                producto.IdProducto = int.Parse(dgvProductos.Rows[fila].Cells[0].Value.ToString());
                producto.Nombre = dgvProductos.Rows[fila].Cells[1].Value.ToString();
                producto.Descripcion = dgvProductos.Rows[fila].Cells[3].Value.ToString();
                producto.Precio = double.Parse(dgvProductos.Rows[fila].Cells[2].Value.ToString());
            }
            catch (FormatException)
            {
                MessageBox.Show("La fila seleccionada esta vacia.");
            }
        }

        private void btnBorrar_Click(object sender, EventArgs e)
        {
            if (fila != 0)
            {
                DialogResult rs = MessageBox.Show("¿Esta seguro de que desea borrar el producto " + producto.Nombre +
                "?", "!ATENCION¡", MessageBoxButtons.YesNo);

                if (rs == DialogResult.Yes)
                {
                    r = mp.Borrar(producto);
                    Actualizar();
                }
            }
            else
            {
                MessageBox.Show("No seleccionaste ningún producto para borrar.");
            }
        }

        private void btnModificar_Click(object sender, EventArgs e)
        {
            if (fila != 0)
            {
                FrmProductosAdd fp = new FrmProductosAdd(producto);
                fp.ShowDialog();
                Actualizar();
            }
            else
            {
                MessageBox.Show("No seleccionaste ningún producto para modificar.");
            }
        }

        private void txtBuscar_TextChanged(object sender, EventArgs e)
        {
            Actualizar();
        }
    }
}
