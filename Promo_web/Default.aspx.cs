using negocio;
using System;
using System.Collections.Generic;
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
            VoucherNegocio negocio = new VoucherNegocio();
            bool voucher = negocio.ExisteCodigo(txtVoucher.Text);

            if (voucher)
            {
                Response.Redirect("elegirPremio.aspx");
            }
            else
            {
                //alerta o algún error
            }
        }
    }
}