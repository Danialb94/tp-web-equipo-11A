using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using negocio;
using dominio;
using System.ComponentModel.DataAnnotations;

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
                            if(Uri.TryCreate(articulo.Imagenes[0].urlImagen, UriKind.Absolute, out Uri uri) && Uri.IsWellFormedUriString(articulo.Imagenes[0].urlImagen, UriKind.Absolute))
                            {
                                imgPremio.ImageUrl = articulo.Imagenes[0].urlImagen;
                                lblPremio.Text = articulo.Nombre;
                            }
                            else
                            {
                                imgPremio.ImageUrl = ResolveUrl("~/images/caja-de-regalo.png");
                                lblPremio.Text = "Estas participando por: " + articulo.Nombre + ".";
                            }
                        }
                        else
                        {
                            imgPremio.ImageUrl = ResolveUrl("~/images/caja-de-regalo.png");
                            lblPremio.Text = "Estas participando por: "+articulo.Nombre+".";
                        }
                    }
                    else
                    {
                        lblPremio.Text = 
                            "No se encontró información del premio.";
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