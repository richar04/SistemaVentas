using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Controllers;

namespace Views
{
    public partial class vCliente : Form
    {
        private bool IsNuevo = false;
        private bool IsEditar = false;
        public vCliente()
        {
            InitializeComponent();
            this.ttMensaje.SetToolTip(this.txtApeynom, "Ingrese Apellido y Nombre del Cliente");
            this.ttMensaje.SetToolTip(this.txtDni, "Ingrese DNI del Cliente");
            this.ttMensaje.SetToolTip(this.txtDireccion, "Ingrese la Dirección del Cliente");
            this.ttMensaje.SetToolTip(this.txtEmail, "Ingrese el Emain del Cliente");
            this.ttMensaje.SetToolTip(this.txtTelefono, "Ingrese el Numero de Telefono del Cliente");

        }

        //Mensaje de confirmacion
        private void MensajeOk(string mensaje)
        {
            MessageBox.Show(mensaje, "Sistema de Ventas", MessageBoxButtons.OK, MessageBoxIcon.Information);

        }

        //Mensaje de error
        private void MensajeError(string mensaje)
        {
            MessageBox.Show(mensaje, "Sistema de Ventas", MessageBoxButtons.OK, MessageBoxIcon.Error);

        }

        //Limpiar todos los controles del form
        private void Limpiar()
        {
            this.txtApeynom.Text = string.Empty;
            this.txtDni.Text = string.Empty;
            this.txtDireccion.Text = string.Empty;
            this.txtTelefono.Text = string.Empty;
            this.txtEmail.Text = string.Empty;
            this.errorIcono.Clear();
        }

        //Habilitar los controles del form
        private void Habilitar(bool valor)
        {
            this.txtApeynom.ReadOnly = !valor;
            this.txtDni.ReadOnly = !valor;
            this.txtDireccion.ReadOnly = !valor;
            this.txtTelefono.ReadOnly = !valor;
            this.txtEmail.ReadOnly = !valor;

        }

        //Habilitar los botones
        private void Botones()
        {
            if (this.IsNuevo || this.IsEditar)
            {
                this.Habilitar(true);
                this.btnNuevo.Enabled = false;
                this.btnGuardar.Enabled = true;
                this.btnEditar.Enabled = false;
                this.btnCancelar.Enabled = true;
            }

            else
            {
                this.Habilitar(false);
                this.btnNuevo.Enabled = true;
                this.btnGuardar.Enabled = false;
                this.btnEditar.Enabled = true;
                this.btnCancelar.Enabled = false;
            }
        }

        //Ocultar Columnas
        private void OcultarColumnas()
        {
            this.dataListado.Columns[0].Visible = false;
            this.dataListado.Columns[1].Visible = false;
        }

        //Metodo Mostrar
        private void Mostrar()
        {
            this.dataListado.DataSource = ClienteController.Mostrar();
            this.OcultarColumnas();
            lblTotal.Text = "Total de Registros: " + Convert.ToString(dataListado.Rows.Count);
        }

        //Metodo Buscar por razon social
        private void BuscarApeynom()
        {
            this.dataListado.DataSource = ClienteController.BuscarApeynom(this.txtBuscar.Text);
            this.OcultarColumnas();
            lblTotal.Text = "Total de Registros: " + Convert.ToString(dataListado.Rows.Count);
        }

        //Metodo Buscar por cuit
        private void BuscarDni()
        {
            this.dataListado.DataSource = ClienteController.BuscarDni(this.txtBuscar.Text);
            this.OcultarColumnas();
            lblTotal.Text = "Total de Registros: " + Convert.ToString(dataListado.Rows.Count);
        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void vCliente_Load(object sender, EventArgs e)
        {
            this.Top = 0;
            this.Left = 0;

            this.Mostrar();
            this.Habilitar(false);
            this.Botones();
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            if (cbBuscar.Text.Equals("Apellido y Nombre")) this.BuscarApeynom();
            else if (cbBuscar.Text.Equals("DNI")) this.BuscarDni();
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            try
            {
                DialogResult Opcion;
                Opcion = MessageBox.Show("Desea eliminar los registros seleccionados?", "Sistema de Ventas", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);

                if (Opcion == DialogResult.OK)
                {
                    string Codigo;
                    String Respuesta = "";
                    bool erroreliminado = false;
                    String RespuestaError = "";

                    foreach (DataGridViewRow row in dataListado.Rows)
                    {
                        if (Convert.ToBoolean(row.Cells[0].Value))
                        {
                            Codigo = Convert.ToString(row.Cells[1].Value);
                            Respuesta = ClienteController.Eliminar(Convert.ToInt32(Codigo));
                            if (!Respuesta.Equals("OK"))
                            {
                                erroreliminado = true;
                                RespuestaError = Respuesta;
                            }
                        }
                    }

                    if (erroreliminado == false) this.MensajeOk("Se eliminaron los registros");
                    else MensajeError(RespuestaError);
                    this.Mostrar();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message + ex.StackTrace);
            }
        }

        private void chkEliminar_CheckedChanged(object sender, EventArgs e)
        {
            if (chkEliminar.Checked) this.dataListado.Columns[0].Visible = true;
            else this.dataListado.Columns[0].Visible = false;
        }

        private void dataListado_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == dataListado.Columns["Eliminar"].Index)
            {
                DataGridViewCheckBoxCell ChkEliminar = (DataGridViewCheckBoxCell)dataListado.Rows[e.RowIndex].Cells["Eliminar"];
                ChkEliminar.Value = !Convert.ToBoolean(ChkEliminar.Value);
            }
        }

        private void dataListado_DoubleClick(object sender, EventArgs e)
        {
            this.txtIdcliente.Text = Convert.ToString(this.dataListado.CurrentRow.Cells["idcliente"].Value);
            this.txtApeynom.Text = Convert.ToString(this.dataListado.CurrentRow.Cells["apeynom"].Value);
            this.txtDni.Text = Convert.ToString(this.dataListado.CurrentRow.Cells["dni"].Value);
            this.txtDireccion.Text = Convert.ToString(this.dataListado.CurrentRow.Cells["direccion"].Value);
            this.txtTelefono.Text = Convert.ToString(this.dataListado.CurrentRow.Cells["telefono"].Value);
            this.txtEmail.Text = Convert.ToString(this.dataListado.CurrentRow.Cells["email"].Value);

            this.tabControl1.SelectedIndex = 1;
        }

        private void btnNuevo_Click(object sender, EventArgs e)
        {
            this.IsNuevo = true;
            this.IsEditar = false;
            this.Botones();
            this.Limpiar();
            this.Habilitar(true);
            this.txtApeynom.Focus();
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            try
            {
                string respuesta = "";
                if (this.txtApeynom.Text == string.Empty || this.txtDni.Text == string.Empty || 
                    this.txtDireccion.Text == string.Empty || this.txtEmail.Text == string.Empty || this.txtTelefono.Text == string.Empty)
                {
                    MensajeError("Faltan ingresar datos");
                    errorIcono.SetError(txtApeynom, "Ingrese un valor");
                    errorIcono.SetError(txtDni, "Ingrese un valor");
                    errorIcono.SetError(txtDireccion, "Ingrese un valor");
                    errorIcono.SetError(txtEmail, "Ingrese un valor");
                    errorIcono.SetError(txtTelefono, "Ingrese un valor");
                }
                else
                {
                    if (this.IsNuevo)
                    {
                        respuesta = ClienteController.Insertar(this.txtApeynom.Text.Trim().ToUpper(), 
                        this.txtDni.Text.Trim(), this.txtDireccion.Text, this.txtTelefono.Text.Trim(),this.txtEmail.Text.Trim());
                    }
                    else
                    {
                        respuesta = ClienteController.Editar(Convert.ToInt32(this.txtIdcliente.Text),
                           this.txtApeynom.Text.Trim().ToUpper(), this.txtDni.Text.Trim(), this.txtDireccion.Text, 
                           this.txtTelefono.Text.Trim(), this.txtEmail.Text.Trim());
                    }

                    if (respuesta.Equals("OK"))
                    {
                        if (this.IsNuevo) this.MensajeOk("Se creó el registro correctamente");

                        else this.MensajeOk("Se editó el registro correctamente");
                    }
                    else
                    {
                        this.MensajeError(respuesta);
                    }

                    this.IsNuevo = false;
                    this.IsEditar = false;
                    this.Botones();
                    this.Limpiar();
                    this.Mostrar();

                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message + ex.StackTrace);
            }
        }

        private void btnEditar_Click(object sender, EventArgs e)
        {
            if (!this.txtIdcliente.Text.Equals(""))
            {
                this.IsEditar = true;
                this.Botones();
                this.Habilitar(true);
            }
            else this.MensajeError("Debe seleccionar el registro a editar.");
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.IsNuevo = false;
            this.IsEditar = false;
            this.Botones();
            this.Limpiar();
            this.Habilitar(false);

            this.txtIdcliente.Text = string.Empty;
        }
    }
}
