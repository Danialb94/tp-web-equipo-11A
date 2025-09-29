<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="Promo_web.Default" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <asp:ScriptManager runat="server" ID="sm1" />
    <div class="row justify-content-center mt-3">
        <div class="col-6">
            <h1>Participá y Ganá!</h1>
            <hr />
            <div class="align-items-center d-flex flex-column mb-3 rounded" style="background-color: #e0cbee; padding: 10px">
                <label for="txtVoucher" class="form-label">Ingresá el código de tu Voucher!</label>
                <asp:TextBox ID="txtVoucher" runat="server" CssClass="form-control w-75 p-3" placeholder="XXXXXXXXXXXX" MaxLength="20" />
                <asp:RequiredFieldValidator runat="server" ControlToValidate="txtVoucher" ErrorMessage="El voucher es obligatorio" CssClass="text-danger" Display="Dynamic" />
                <asp:RegularExpressionValidator runat="server" ControlToValidate="txtVoucher" ErrorMessage="Debe ser alfanumérico" ValidationExpression="^[a-zA-Z0-9]{1,20}$" CssClass="text-danger" Display="Dynamic" />
                <div class="w-75 d-flex align-items-end flex-column mt-2">
                    <asp:Button ID="btnParticipar" runat="server" Text="Participar" CssClass="btn btn-light" CausesValidation="true" OnClick="btnParticipar_Click" />
                </div>
                <asp:Label ID="lblError" runat="server" CssClass="text-danger mt-2" Visible="false" />
            </div>
        </div>
    </div>
</asp:Content>
