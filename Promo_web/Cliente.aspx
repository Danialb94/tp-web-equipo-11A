<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.Master" AutoEventWireup="true" CodeBehind="Cliente.aspx.cs" Inherits="Promo_web.Cliente" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="container mt-4">

        <!-- Fila 1: Documento + Buscar -->
        <div class="row g-3 mb-3">
            <div class="col-md-4 position-relative">
                <label for="txtDocumento" class="form-label">Documento</label>
                <asp:TextBox ID="txtDocumento" runat="server" class="bg-dark-subtle border-dark-subtle form-control" placeholder="DNI 11222333" required="required" />
                <asp:RegularExpressionValidator ErrorMessage="No válido" ControlToValidate="txtDocumento" ValidationExpression="^\d{7,8}$" CssClass="text-danger" Display="Dynamic" runat="server" />
            </div>
            <div class="align-content-end">
                <asp:Button ID="btnBuscar" runat="server" Text="Buscar Cliente" CssClass="btn btn-primary" OnClick="btnBuscar_Click" />
            </div>
        </div>

        <!-- Fila 2: Datos del cliente (solo aparece después de buscar) -->
        <div id="divDatosCliente" class="row g-3" runat="server" visible="false">

            <!-- Nombre -->
            <div class="col-md-4 position-relative">
                <label for="txtNombre" class="form-label">Nombre</label>
                <asp:TextBox ID="txtNombre" runat="server" class="bg-dark-subtle border-dark-subtle form-control" placeholder="Nombre" required="required" />
                <asp:RegularExpressionValidator ErrorMessage="Solo se permiten letras" ControlToValidate="txtNombre" ValidationExpression="^[A-Za-zÁÉÍÓÚáéíóúÑñ\s]+$" CssClass="text-danger" Display="Dynamic" runat="server" />
            </div>

            <!-- Apellido -->
            <div class="col-md-4 position-relative">
                <label for="txtApellido" class="form-label">Apellido</label>
                <asp:TextBox ID="txtApellido" runat="server" class="bg-dark-subtle border-dark-subtle form-control" placeholder="Apellido" required="required" />
                <asp:RegularExpressionValidator ErrorMessage="Solo se permiten letras" ControlToValidate="txtApellido" ValidationExpression="^[A-Za-zÁÉÍÓÚáéíóúÑñ\s]+$" CssClass="text-danger" Display="Dynamic" runat="server" />
            </div>

            <!-- Email -->
            <div class="col-md-4 position-relative">
                <label for="txtEmail" class="form-label">Email</label>
                <asp:TextBox ID="txtEmail" runat="server" class="bg-dark-subtle border-dark-subtle form-control" placeholder="correo@email.com" required="required" />
                <asp:RegularExpressionValidator ErrorMessage="Email inválido" ControlToValidate="txtEmail" ValidationExpression="^[a-zA-Z0-9._%+-]+@[a-zA-Z0-9.-]+\.[a-zA-Z]{2,}$" CssClass="text-danger" Display="Dynamic" runat="server" />
            </div>

            <!-- Dirección -->
            <div class="col-md-6 position-relative">
                <label for="txtDireccion" class="form-label">Dirección</label>
                <asp:TextBox ID="txtDireccion" runat="server" class="bg-dark-subtle border-dark-subtle form-control" placeholder="Calle Siempreviva 123" required="required"/>
                <asp:RegularExpressionValidator ErrorMessage="Dirección inválida" ControlToValidate="txtDireccion" ValidationExpression="^([A-Za-z]{4,})+\s+(\d{1,5})$|^([A-Za-z]{4,})+\s+(\d{1,3})+\s+(\d{1,5})$|^([A-Za-z]{2,})+\s+([A-Za-z]{4,})+\s+(\d{1,5})$" CssClass="text-danger" Display="Dynamic" runat="server" />
            </div>

            <!-- Ciudad -->
            <div class="col-md-3 position-relative">
                <label for="txtCiudad" class="form-label">Ciudad</label>
                <asp:TextBox ID="txtCiudad" runat="server" class="bg-dark-subtle border-dark-subtle form-control" placeholder="Ciudad" required="required"/>
                <asp:RegularExpressionValidator ErrorMessage="Ciudad inválida" ControlToValidate="txtCiudad" ValidationExpression="(^([A-Za-z]{4,10})$|^([A-Za-z]{3,10}).*([A-Za-z]{3,10})$)|^([A-Za-z]{4,10}).*([1-9]{1,5})" CssClass="text-danger" Display="Dynamic" runat="server" />
            </div>

            <!-- Código Postal -->
            <div class="col-md-3 position-relative">
                <label for="txtCP" class="form-label">CP</label>
                <asp:TextBox ID="txtCP" runat="server" class="bg-dark-subtle border-dark-subtle form-control" placeholder="1234" required="required"/>
                <asp:RegularExpressionValidator ErrorMessage="Código Postal inválido" ControlToValidate="txtCP" ValidationExpression="^[0-9]{4}" CssClass="text-danger" Display="Dynamic" runat="server" />
            </div>

            <!-- Botones dinámicos -->
            <div class="col-12 mt-2">
                <asp:Button ID="btnGuardar" runat="server" Text="Guardar Cliente" CssClass="btn btn-success me-2" OnClick="btnGuardar_Click" />
                <asp:Button ID="btnCancelar" Text="Cancelar" runat="server" CssClass="btn btn-secondary" OnClick="btnCancelar_Click" Visible="false" />
            </div>
            <!-- Botón canjear -->
            <div class="col-12 mt-2">
                <asp:Button ID="btnCanjear" runat="server" Text="Canjear Voucher" CssClass="btn btn-success mt-3" OnClick="btnCanjear_Click" />
                <asp:Label ID="lblCanje" runat="server" CssClass="fw-bold mt-2" />
            </div>
        </div>

        <!-- Mensaje -->
        <div class="row mt-3">
            <div class="col-12">
                <asp:Label ID="lblMensaje" runat="server" CssClass="fw-bold"></asp:Label>
            </div>
        </div>

    </div>
</asp:Content>
