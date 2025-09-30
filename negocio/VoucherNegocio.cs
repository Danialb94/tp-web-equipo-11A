using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace negocio
{
    public class VoucherNegocio
    {

        public bool ExisteCodigo(string codigo)
        {
            AccesoDatos datos = new AccesoDatos();
            try
            {
                datos.setearConsulta("SELECT COUNT(*) AS Cantidad FROM Vouchers WHERE CodigoVoucher = @codigo AND IdCliente IS NULL");
                datos.setearParametro("@codigo", codigo);
                datos.ejecutarLectura();

                if (datos.Lector.Read())
                {
                    int cantidad = (int)datos.Lector["Cantidad"];
                    return cantidad > 0;
                    // cantidad > 0 == true : se puede reclamar el voucher
                }
                return false; 
            }
            catch(Exception ex) {
                {
                    throw ex;
                }
            }
            finally
            {
                datos.cerrarConexion();
            }
        }


        public void CanjearVoucher(string codigoVoucher, int idCliente, int idPremio)
        {
            AccesoDatos datos = new AccesoDatos();
            try
            {
                datos.setearConsulta("UPDATE Vouchers SET IdCliente = @idCliente, IdArticulo = @idPremio, FechaCanje = @fecha WHERE CodigoVoucher = @codigo");
                datos.setearParametro("@idCliente", idCliente);
                datos.setearParametro("@idPremio", idPremio);
                datos.setearParametro("@fecha", DateTime.Now);
                datos.setearParametro("@codigo", codigoVoucher);
                datos.ejecutarAccion();
            }
            catch (Exception ex)
            {
                throw;
            }
            finally
            {
                datos.cerrarConexion();
            }
        }

    }
}

