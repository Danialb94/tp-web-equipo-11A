using negocio;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Promo_web
{
    public partial class Default : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnParticipar_Click(object sender, EventArgs e)
        {
            Page.Validate();
            if (!Page.IsValid)
                return;

            VoucherNegocio negocio = new VoucherNegocio();
            bool voucher = negocio.ExisteCodigo(txtVoucher.Text);

            if (voucher)
            {
                Response.Redirect("elegirPremio.aspx");
            }
            else
            {
                lblError.Text = "El código ingresado no es válido.";
                lblError.Visible = true;
            }
        }
    }
}