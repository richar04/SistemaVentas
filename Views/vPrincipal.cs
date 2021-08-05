using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Views
{
    public partial class vPrincipal : Form
    {
        private int childFormNumber = 0;
        public string IdEmpleado = "";
        public string Apeynom = "";
        public string Acceso = "";


        public vPrincipal()
        {
            InitializeComponent();
        }

        private void ShowNewForm(object sender, EventArgs e)
        {
            Form childForm = new Form();
            childForm.MdiParent = this;
            childForm.Text = "Ventana " + childFormNumber++;
            childForm.Show();
        }

        private void OpenFile(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.Personal);
            openFileDialog.Filter = "Archivos de texto (*.txt)|*.txt|Todos los archivos (*.*)|*.*";
            if (openFileDialog.ShowDialog(this) == DialogResult.OK)
            {
                string FileName = openFileDialog.FileName;
            }
        }

        private void SaveAsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SaveFileDialog saveFileDialog = new SaveFileDialog();
            saveFileDialog.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.Personal);
            saveFileDialog.Filter = "Archivos de texto (*.txt)|*.txt|Todos los archivos (*.*)|*.*";
            if (saveFileDialog.ShowDialog(this) == DialogResult.OK)
            {
                string FileName = saveFileDialog.FileName;
            }
        }

        private void ExitToolsStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void CutToolStripMenuItem_Click(object sender, EventArgs e)
        {
        }

        private void CopyToolStripMenuItem_Click(object sender, EventArgs e)
        {
        }

        private void PasteToolStripMenuItem_Click(object sender, EventArgs e)
        {
        }

        private void ToolBarToolStripMenuItem_Click(object sender, EventArgs e)
        {
        }

        private void StatusBarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            statusStrip.Visible = statusBarToolStripMenuItem.Checked;
        }

        private void CascadeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            LayoutMdi(MdiLayout.Cascade);
        }

        private void TileVerticalToolStripMenuItem_Click(object sender, EventArgs e)
        {
            LayoutMdi(MdiLayout.TileVertical);
        }

        private void TileHorizontalToolStripMenuItem_Click(object sender, EventArgs e)
        {
            LayoutMdi(MdiLayout.TileHorizontal);
        }

        private void ArrangeIconsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            LayoutMdi(MdiLayout.ArrangeIcons);
        }

        private void CloseAllToolStripMenuItem_Click(object sender, EventArgs e)
        {
            foreach (Form childForm in MdiChildren)
            {
                childForm.Close();
            }
        }

        private void moduloDeVentasToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void toolStripStatusLabel1_Click(object sender, EventArgs e)
        {

        }

        private void salirToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void statusStrip_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {

        }

        private void categoriaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            vCategoria view = new vCategoria();
            view.MdiParent = this;
            view.Show();

        }

        private void articulosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            vArticulo view = vArticulo.GetInstancia();
            view.MdiParent = this;
            view.Show();
        }

        private void proveedorToolStripMenuItem_Click(object sender, EventArgs e)
        {
            vProveedor view = new vProveedor();
            view.MdiParent = this;
            view.Show();
        }

        private void clientesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            vCliente view = new vCliente();
            view.MdiParent = this;
            view.Show();
        }

        private void empleadosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            vEmpleado view = new vEmpleado();
            view.MdiParent = this;
            view.Show();
        }

        private void GestionUsuario()
        {
            //Control de accesos
            if (Acceso=="Administrador")
            {
                this.menuVentas.Enabled = true;
                this.menuInventario.Enabled = true;
                this.menuCompras.Enabled = true;
                this.menuConsultas.Enabled = true;
                this.menuMantenimiento.Enabled = true;
                this.menuHerramientas.Enabled = true;

            }

            if (Acceso == "Empleado")
            {
                this.menuVentas.Enabled = true;
                this.menuInventario.Enabled = true;
                this.menuCompras.Enabled = false;
                this.menuConsultas.Enabled = false;
                this.menuMantenimiento.Enabled = false;
                this.menuHerramientas.Enabled = false;

            }
        }

        private void menuStrip_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {

        }

        private void vPrincipal_Load(object sender, EventArgs e)
        {
            GestionUsuario();

        }
    }
}
