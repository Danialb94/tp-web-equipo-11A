using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using negocio;
using dominio;

namespace Promo_web
{
    public partial class Exito : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
              
                string nombre = Session["NombreCliente"]?.ToString() ?? "Cliente";
                string premio = Session["NombrePremio"]?.ToString() ?? "Premio sorpresa";
                string urlImagen = Session["UrlImagenPremio"]?.ToString() ?? "https://http2.mlstatic.com/D_NQ_NP_703368-MLU76300898146_052024-O.webp";   
                imgPremio.ImageUrl = urlImagen;
                lblMensaje.Text = $"¡Felicitaciones {nombre}! 🎉";
                
            }
        }
    }
}