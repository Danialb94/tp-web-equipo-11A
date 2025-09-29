<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.Master" AutoEventWireup="true" CodeBehind="Cliente.aspx.cs" Inherits="Promo_web.Cliente" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="container mt-4">

        <!-- Fila 1: Documento + Buscar -->
        <div class="row g-3 mb-3">
            <div class="col-md-4 position-relative">
                <label for="txtDocumento" class="form-label">Documento</label>
                <asp:TextBox ID="txtDocumento" runat="server" CssClass="form-control" placeholder="DNI" required />
                <asp:RegularExpressionValidator ErrorMessage="No válido" ControlToValidate="txtDocumento" ValidationExpression="^\d{7,8}$" runat="server" />
            </div>
            <div class="col-md-2 align-self-end">
                <asp:Button ID="btnBuscar" runat="server" Text="Buscar Cliente" CssClass="btn btn-primary" OnClick="btnBuscar_Click" />
            </div>
        </div>

        <!-- Fila 2: Datos del cliente (solo aparece después de buscar) -->
        <div id="divDatosCliente" class="row g-3" runat="server" visible="false">

            <!-- Nombre -->
            <div class="col-md-4 position-relative">
                <label for="txtNombre" class="form-label">Nombre</label>
                <asp:TextBox ID="txtNombre" runat="server" CssClass="form-control" />
                 <asp:RegularExpressionValidator ErrorMessage="No se aceptan números" ControlToValidate="txtNombre" ValidationExpression="^[^0-9]*$" runat="server" />
            </div>

            <!-- Apellido -->
            <div class="col-md-4 position-relative">
                <label for="txtApellido" class="form-label">Apellido</label>
                <asp:TextBox ID="txtApellido" runat="server" CssClass="form-control" />
                <asp:RegularExpressionValidator ErrorMessage="No se aceptan números" ControlToValidate="txtApellido" ValidationExpression="^[^0-9]*$" runat="server" />
            </div>

            <!-- Email -->
            <div class="col-md-4 position-relative">
                <label for="txtEmail" class="form-label">Email</label>
                <asp:TextBox ID="txtEmail" runat="server" CssClass="form-control" />
                <asp:RegularExpressionValidator ErrorMessage="Email inválido" ControlToValidate="txtEmail" ValidationExpression="^[a-zA-Z0-9._%+-]+@[a-zA-Z0-9.-]+\.[a-zA-Z]{2,}$" runat="server" />
            </div>

            <!-- Dirección -->
            <div class="col-md-6 position-relative">
                <label for="txtDireccion" class="form-label">Dirección</label>
                <asp:TextBox ID="txtDireccion" runat="server" CssClass="form-control" />
            </div>

            <!-- Ciudad -->
            <div class="col-md-3 position-relative">
                <label for="txtCiudad" class="form-label">Ciudad</label>
                <asp:TextBox ID="txtCiudad" runat="server" CssClass="form-control" />
            </div>

            <!-- Código Postal -->
            <div class="col-md-3 position-relative">
                <label for="txtCP" class="form-label">CP</label>
                <asp:TextBox ID="txtCP" runat="server" CssClass="form-control" />
            </div>

            <!-- Botón dinámico -->
            <div class="col-12 mt-2">
                <asp:Button ID="btnGuardar" runat="server" Text="Participar!" CssClass="btn btn-success me-2" OnClick="btnGuardar_Click" />
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
