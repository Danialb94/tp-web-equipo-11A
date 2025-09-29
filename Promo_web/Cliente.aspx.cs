using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using dominio;
using negocio;

namespace Promo_web
{
    public partial class Cliente : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }
        protected void btnBuscar_Click(object sender, EventArgs e)
        {
            ClienteNegocio negocio = new ClienteNegocio();
            dominio.Cliente cliente = negocio.BuscarPorDocumento(txtDocumento.Text);

            divDatosCliente.Visible = true;

            if (cliente != null)
            {
                // Precargar datos
                txtNombre.Text = cliente.Nombre;
                txtApellido.Text = cliente.Apellido;
                txtEmail.Text = cliente.Email;
                txtDireccion.Text = cliente.Direccion;
                txtCiudad.Text = cliente.Ciudad;
                txtCP.Text = cliente.CP.ToString();

                lblMensaje.Text = "Cliente encontrado ✅";
                lblMensaje.CssClass = "text-success fw-bold";

                btnGuardar.Text = "Modificar Cliente";

            }
            else
            {
                // Limpiar campos
                txtNombre.Text = "";
                txtApellido.Text = "";
                txtEmail.Text = "";
                txtDireccion.Text = "";
                txtCiudad.Text = "";
                txtCP.Text = "";

                lblMensaje.Text = "Cliente no encontrado ❌, complete los datos y guarde";
                lblMensaje.CssClass = "text-danger fw-bold";

                btnGuardar.Text = "Guardar Cliente";
            }
        }

        protected void btnGuardar_Click(object sender, EventArgs e)
        {
            ClienteNegocio negocio = new ClienteNegocio();
            dominio.Cliente nuevo = new dominio.Cliente();

            try
            {
                nuevo.Documento = txtDocumento.Text;
                nuevo.Nombre = txtNombre.Text;
                nuevo.Apellido = txtApellido.Text;
                nuevo.Email = txtEmail.Text;
                nuevo.Direccion = txtDireccion.Text;
                nuevo.Ciudad = txtCiudad.Text;
                nuevo.CP = int.Parse(txtCP.Text);

                if (negocio.ExisteCliente(nuevo.Documento))
                {
                    negocio.Modificar(nuevo);
                    lblMensaje.Text = "Cliente actualizado ✅";
                    lblMensaje.CssClass = "text-warning fw-bold";
                }
                else
                {
                    negocio.Agregar(nuevo);
                    lblMensaje.Text = "Cliente registrado correctamente ✅";
                    lblMensaje.CssClass = "text-success fw-bold";
                }
            }
            catch (Exception ex)
            {
                lblMensaje.Text = "Error: " + ex.Message;
                lblMensaje.CssClass = "text-danger fw-bold";
            }

          
        }
    }
}