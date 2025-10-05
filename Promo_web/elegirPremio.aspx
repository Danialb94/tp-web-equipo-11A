<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.Master" AutoEventWireup="true" CodeBehind="elegirPremio.aspx.cs" Inherits="Promo_web.wfrmPremios" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <div>
        <div class="row row-cols-1 row-cols-md-3 g-4 justify-content-around" >

            <%foreach (dominio.Articulo articulo in ListaArticulo)
                { %>
            <div class="bg-dark-subtle col p-3 rounded" style="width: 320px;">
                <div class="card">

                    <div id="carrusel<%:articulo.IdArticulo %>" class="carousel slide">
                        <div class="carousel-inner ">

                            <%foreach (dominio.Imagen imagen in articulo.Imagenes)
                                {
                                    if (articulo.Imagenes[0].idImagen == imagen.idImagen)
                                    {%>
                                        <div class="carousel-item active">
                                            <img src="<%:imagen.urlImagen %>" class="img-fluid object-fit-contain" style="width: 300px; height: 300px" onerror="this.onerror=null; this.src='<%= ResolveUrl("~/images/placeholder.png") %>';">
                                            <%--Si el relativeUrl parámetro contiene una dirección URL absoluta, la dirección URL se devuelve sin cambios. Si el relativeUrl parámetro contiene una dirección URL relativa, esa dirección URL se cambia a una dirección URL relativa correcta para la ruta de acceso de solicitud actual, de modo que el explorador pueda resolver la dirección URL.--%>
                                        </div>
                                    <%}
                                    else
                                    {%>
                                        <div class="carousel-item">
                                            <img src="<%:imagen.urlImagen %>" class="img-fluid object-fit-contain" alt="..." style="width: 300px; height: 300px" onerror="this.onerror=null; this.src='<%= ResolveUrl("~/images/placeholder.png") %>';">
                                        </div>
                                    <%}%>

                            <% } %>
                        </div>
                    </div>

                    <%if(articulo.Imagenes.Count >1) { %>
                    <button class="carousel-control-prev" type="button" data-bs-target="#carrusel<%:articulo.IdArticulo %>" data-bs-slide="prev" >
                        <span class="carousel-control-prev-icon" aria-hidden="true"></span>
                        <span class="visually-hidden">Previous</span>
                    </button>
                    <button class="carousel-control-next" type="button" data-bs-target="#carrusel<%:articulo.IdArticulo %>" data-bs-slide="next">
                        <span class="carousel-control-next-icon" aria-hidden="true"></span>
                        <span class="visually-hidden">Next</span>
                    </button>
                    <% } %>


                </div>


                <%--<img src="<%:articulo.Imagenes[0].urlImagen %>" class="card-img-top" alt="...">--%>
                <div class="card-body pt-2">
                    <h5 class="card-title"><%:articulo.Nombre %></h5>
                    <p class="card-text overflow-auto" style="height: 100px;"><%:articulo.Descripcion %></p>
                    <a class="btn btn-primary w-100" href="Cliente.aspx?id=<%:articulo.IdArticulo %>">Seleccionar Premio</a>
                </div>
            </div>
            <% } %>
        </div>
    </div>


</asp:Content>
