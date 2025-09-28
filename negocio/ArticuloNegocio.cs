using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using dominio;
using System.Net;
using System.Windows.Documents;

namespace negocio
{
    public class ArticuloNegocio
    {
        public List<Articulo> listar()

        {
            List<Articulo>lista = new List<Articulo>();
            AccesoDatos datos = new AccesoDatos();
            AccesoDatos datosIMG = new AccesoDatos();
           


            try
            {
                datos.setearConsulta("SELECT Art.Id,Art.Codigo,Art.Nombre,Art.Descripcion,M.Descripcion AS Marca,C.Descripcion AS Categoria, Art.Precio, Art.IdMarca, Art.IdCategoria FROM ARTICULOS ART, MARCAS M, CATEGORIAS C WHERE Art.IdMarca = M.Id AND Art.IdCategoria = C.Id");
                datos.ejecutarLectura();
                while (datos.Lector.Read())
                {
                    Articulo articulo = new Articulo();
                    articulo.IdArticulo = (int)datos.Lector["Id"];
                    if (!(datos.Lector["Codigo"] is DBNull))
                    articulo.Codigo = (string)datos.Lector["Codigo"];
                    if (!(datos.Lector["Nombre"] is DBNull))
                    articulo.Nombre = (string)datos.Lector["Nombre"];
                    if (!(datos.Lector["Descripcion"] is DBNull))
                    articulo.Descripcion = (string)datos.Lector["Descripcion"];
                    articulo.Marca = new Marca();
                    if (!(datos.Lector["Marca"] is DBNull))
                    articulo.Marca.IdMarca = (int)datos.Lector["IdMarca"];
                    articulo.Marca.Descripcion = (string)datos.Lector["Marca"];
                    articulo.Categoria = new Categoria();
                    articulo.Categoria.IDCategoria = (int)datos.Lector["IdCategoria"];
                    if (!(datos.Lector["Categoria"] is DBNull))
                    articulo.Categoria.Descripcion = (string)datos.Lector["Categoria"];
                    if (!(datos.Lector["Precio"] is DBNull))
                    articulo.Precio = (decimal)datos.Lector["Precio"];

                    
                    //IMAGENES
                        ImagenNegocio negocio = new ImagenNegocio();
                    if (negocio.listarXArticulo(articulo.IdArticulo) != null)
                    {
                        articulo.Imagenes = negocio.listarXArticulo(articulo.IdArticulo);
                    }

                    

                    lista.Add(articulo);
                }


                return lista;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally {
                datos.cerrarConexion();

            }

       
        }

        public void agregar(Articulo nuevo, List<Imagen> listaImg)
        {
            AccesoDatos datos = new AccesoDatos();
            try
            {
                datos.setearConsulta("Insert into ARTICULOS (Codigo, Nombre, Descripcion, Precio,IdMarca, IdCategoria)values('" + nuevo.Codigo + "','" + nuevo.Nombre + "','" + nuevo.Descripcion + "'," + nuevo.Precio + ",@IdMarca, @IdCategoria) SELECT SCOPE_IDENTITY() AS[IdArticulo]");
                datos.setearParametro("@IdMarca", nuevo.Marca.IdMarca);
                datos.setearParametro("@IdCategoria", nuevo.Categoria.IDCategoria);

                datos.ejecutarLectura();
                if (listaImg.Count != 0)
                {
                    datos.Lector.Read();
                    for (int x = 0; x < listaImg.Count; x++)
                    {
                        Imagen imagen = new Imagen();
                        imagen.urlImagen = listaImg[x].urlImagen;
                        imagen.idArticulo = Convert.ToInt32(datos.Lector["IdArticulo"]);
                        ImagenNegocio negocio = new ImagenNegocio();
                        negocio.agregar(imagen);
                    }

                }


            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                datos.cerrarConexion();
            }
        }

        public void modificarArticulo(Articulo articulo, List<Imagen> listaImg, bool existiaImg)
        {
            AccesoDatos datos = new AccesoDatos();
            try
            {
                //FALTA AGREGAR LA MODIFICACIÓN PARA URLIMAGEN
                datos.setearConsulta("update articulos set Codigo = @codigo, Nombre = @nombre, Descripcion = @descripcion, IdMarca = @idMarca, IdCategoria = @idCategoria, Precio = @precio where Id = @id");
                datos.setearParametro("@codigo", articulo.Codigo);
                datos.setearParametro("@nombre", articulo.Nombre);
                datos.setearParametro("@descripcion", articulo.Descripcion);
                datos.setearParametro("@idMarca", articulo.Marca.IdMarca);
                datos.setearParametro("@idCategoria", articulo.Categoria.IDCategoria);
                datos.setearParametro("@precio", articulo.Precio);
                datos.setearParametro("@id", articulo.IdArticulo);

                datos.ejecutarAccion();
                if (listaImg.Count != 0)
                {
                    for (int x = 0; x < listaImg.Count; x++)
                    {
                        Imagen imagen = new Imagen();
                        imagen.urlImagen = listaImg[x].urlImagen;
                        ImagenNegocio negocio = new ImagenNegocio();
                        if (existiaImg)
                        {
                            imagen.idImagen = listaImg[x].idImagen;
                            negocio.modificar(imagen);
                        }
                        else
                        {
                            imagen.idArticulo = articulo.IdArticulo;
                            negocio.agregar(imagen);
                        }
                    }

                }

            }
            catch (Exception ex)
            {

                throw ex;
            }
            finally
            {
                datos.cerrarConexion();

            }

        }


        public void eliminarArticulo(int id)
        {
                AccesoDatos datos = new AccesoDatos();
            try
            {
                ImagenNegocio neg = new ImagenNegocio();
                datos.setearConsulta("delete from ARTICULOS where id = @id");
                datos.setearParametro("@id", id);
                datos.ejecutarAccion();
                neg.eliminarXArticulo(id);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                datos.cerrarConexion();
            }
        }

        public List<Articulo> filtrar(string campo, string criterio, string filtro)
        {
            List<Articulo> lista = new List<Articulo>();
            AccesoDatos datos = new AccesoDatos();

            try
            {
                string consulta = "SELECT Art.Id, Art.Codigo, Art.Nombre, Art.Descripcion,M.Descripcion AS Marca, C.Descripcion AS Categoria,Art.Precio, Art.IdMarca, Art.IdCategoria FROM ARTICULOS ART, MARCAS M, CATEGORIAS C WHERE Art.IdMarca = M.Id AND Art.IdCategoria = C.Id AND ";
                if (campo == "Código") {
                    switch (criterio)
                    {
                        case "Comienza con":
                            consulta += "Art.Codigo like '" + filtro+"%'";
                            break;
                        case "Termina con":
                            consulta += "Art.Codigo like '%" + filtro+"'";
                            break;
                        default:
                            consulta += "Art.Codigo like '%"+filtro+"%'";
                            break;
                    }
                }
                else if (campo == "Nombre")
                {
                    switch (criterio)
                    {
                        case "Comienza con":
                            consulta += "Art.Nombre like '" + filtro + "%'";
                            break;
                        case "Termina con":
                            consulta += "Art.Nombre like '%" + filtro + "'";
                            break;
                        default:
                            consulta += "Art.Nombre like '%" + filtro + "%'";
                            break;
                    }
                }
                else if (campo == "Marca")
                {
                    switch (criterio)
                    {
                        case "Comienza con":
                            consulta += "M.Descripcion like '" + filtro + "%'";
                            break;
                        case "Termina con":
                            consulta += "M.Descripcion like '%" + filtro + "'";
                            break;
                        default:
                            consulta += "M.Descripcion like '%" + filtro + "%'";
                            break;
                    }
                }
                else if (campo == "Categoria")
                {
                    switch (criterio)
                    {
                        case "Comienza con":
                            consulta += "C.Descripcion like '" + filtro + "%'";
                            break;
                        case "Termina con":
                            consulta += "C.Descripcion like '%" + filtro + "'";
                            break;
                        default:
                            consulta += "C.Descripcion like '%" + filtro + "%'";
                            break;
                    }
                }else if (campo == "Precio")
                {
                    switch (criterio)
                    {
                        case "Mayor a":
                            consulta += "Precio > " + filtro;
                            break;
                        case "Menor a":
                            consulta += "Precio < " + filtro;
                            break;
                        default:
                            consulta += "Precio = " + filtro;
                            break;
                    }
                }
                else
                {
                    switch (criterio)
                    {
                        case "Comienza con":
                            consulta += "Art.Descripcion like '" + filtro + "%'";
                            break;
                        case "Termina con":
                            consulta += "Art.Descripcion like '%" + filtro + "'";
                            break;
                        default:
                            consulta += "Art.Descripcion like '%" + filtro + "%'";
                            break;
                    }
                }
                    datos.setearConsulta(consulta);
                    datos.ejecutarLectura();

                while (datos.Lector.Read())
                {
                    Articulo articulo = new Articulo();
                    articulo.IdArticulo = (int)datos.Lector["Id"];
                    if (!(datos.Lector["Codigo"] is DBNull))
                        articulo.Codigo = (string)datos.Lector["Codigo"];
                    if (!(datos.Lector["Nombre"] is DBNull))
                        articulo.Nombre = (string)datos.Lector["Nombre"];
                    if (!(datos.Lector["Descripcion"] is DBNull))
                        articulo.Descripcion = (string)datos.Lector["Descripcion"];
                    articulo.Marca = new Marca();
                    if (!(datos.Lector["Marca"] is DBNull))
                        articulo.Marca.IdMarca = (int)datos.Lector["Id"];
                    articulo.Marca.Descripcion = (string)datos.Lector["Marca"];
                    articulo.Categoria = new Categoria();
                    articulo.Categoria.IDCategoria = (int)datos.Lector["Id"];
                    if (!(datos.Lector["Categoria"] is DBNull))
                        articulo.Categoria.Descripcion = (string)datos.Lector["Categoria"];
                    if (!(datos.Lector["Precio"] is DBNull))
                        articulo.Precio = (decimal)datos.Lector["Precio"];
                   
                    ImagenNegocio negocio = new ImagenNegocio();
                    if (negocio.listarXArticulo(articulo.IdArticulo) != null)
                    {
                        articulo.Imagenes = negocio.listarXArticulo(articulo.IdArticulo);
                    }

                    lista.Add(articulo);
                }


                return lista;
            }
            catch (Exception ex)
            {

                throw ex;
            }
            ;
        }

        public bool existeArticulo(string codigo, string nombre)
        {
            AccesoDatos datos = new AccesoDatos();
            try
            {
                datos.setearConsulta("SELECT COUNT(*) AS Cantidad FROM ARTICULOS WHERE Codigo = @codigo OR Nombre = @nombre");
                datos.setearParametro("@codigo", codigo);
                datos.setearParametro("@nombre", nombre);
                datos.ejecutarLectura();
                if (datos.Lector.Read())
                {
                    return (int)datos.Lector["Cantidad"] > 0;
                }
                return false;
            }
            catch
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
