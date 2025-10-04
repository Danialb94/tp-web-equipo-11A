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
                try
                {
                    if (Session["IdPremio"] != null)
                    {
                        int idPremio = (int)Session["IdPremio"];
                        ArticuloNegocio negocio = new ArticuloNegocio();
                        Articulo articulo = negocio.listar().Find(a => a.IdArticulo == idPremio);

                        if (articulo != null && articulo.Imagenes != null && articulo.Imagenes.Count > 0)
                        {
                            imgPremio.ImageUrl = articulo.Imagenes[0].urlImagen;
                            lblPremio.Text = articulo.Nombre;
                        }
                        else
                        {
                            lblPremio.Text = "No se encontró la imagen del premio.";
                        }
                    }
                    else
                    {
                        lblPremio.Text = "No se encontró información del premio.";
                    }
                }
                catch (Exception ex)
                {
                    lblPremio.Text = "Error al cargar el premio: " + ex.Message;
                }
            }
        }
    }
}